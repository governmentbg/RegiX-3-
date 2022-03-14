using SBCustomCertStorage;
using SBHTTPSClient;
using SBHTTPTSPClient;
using SBWinCertStorage;
using SBX509;
using SBXMLAdESIntf;
using SBXMLSec;
using SBXMLSig;
using SBXMLTransform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.Utils;
using TechnoLogica.RegiX.Common.DataContracts;
using SBXMLCore;
using SBTypes;
using TechnoLogica.RegiX.BaseSigner;
using System.ComponentModel.Composition;
using SBPDF;
using System.IO;
using SBPAdES;
using SBXMLAdES;

namespace TechnoLogica.RegiX.SecureBlackBoxSigner
{
    /// <summary>
    /// Implementation of the abstract ABaseSigner class with the secure
    /// black box library
    /// </summary>
    [Export(typeof(ISigner))]
    public class Signer : ABaseSigner
    {
        /// <summary>
        /// Certificate finder
        /// </summary>
        [Import]
        private ICertificateFinder<TElX509Certificate> TElX509CertificateFinder { get; set; }

        /// <summary>
        /// Timestamp properties
        /// </summary>
        [Import]
        private IAddTimestamp Timestamp { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        [ImportingConstructor]
        public Signer([Import] ISecureBlackBoxLicenseKeyResolver keyResolver)
        {
            SBUtils.Unit.SetLicenseKey(keyResolver.LicenseKey);
        }

        public override XmlElement Sign(XmlElement documentToSign)
        {
            // Creating an instance of the XML-DSig signer.
            TElXMLSigner Signer = new TElXMLSigner();
            // Creating an instance of the XAdES signer.
            TElXAdESSigner XAdESSigner = new TElXAdESSigner();

            if (Timestamp.AddTimestamp)
            {
                //Timestamping
                var tspClient = new TElHTTPTSPClient();
                var httpClient = new TElHTTPSClient();

                tspClient.HTTPClient = httpClient;
                tspClient.URL = Timestamp.TimestampServer;
                tspClient.HashAlgorithm = SBConstants.Unit.SB_ALGORITHM_DGST_SHA1;
                XAdESSigner.TSPClient = tspClient;
                XAdESSigner.IgnoreTimestampFailure = true;
            }

            // Setup the XAdES processor
            Signer.XAdESProcessor = XAdESSigner;
            TElXMLDOMDocument document = new TElXMLDOMDocument();

            // TElXAdESIncludedProperties values 
            // f_xipSignerRoleV2 = 4
            // f_xipProductionPlaceV2 = 8
            XAdESSigner.Included = 4 | 8;
            XAdESSigner.SignerRoleV2.ClaimedRoles.AddText(XAdESSigner.XAdESVersion, document, "ПОДПИСАН ОТ");
            XAdESSigner.ProductionPlaceV2.CountryName = "BG";

            try
            {
                // Adding references. For example, adding a reference for a document element.
                TElXMLReference Ref = new TElXMLReference();
                Ref.TransformChain.Add(new TElXMLEnvelopedSignatureTransform());
                Ref.URI = "#data";
                Ref.ID = $"r-id-{Guid.NewGuid()}";
                document.InnerXML = documentToSign.OuterXml;
                Ref.URINode = document.DocumentElement;
                Signer.References.Add(Ref);

                var cert = TElX509CertificateFinder.GetCertificate();

                // Setup signer key data
                Signer.KeyData =
                    new TElXMLKeyInfoX509Data(true)
                    {
                        Certificate = cert
                    };

                // Calculate the digest value for references
                Signer.UpdateReferencesDigest();

                // Filling XAdES info
                // Setting the XAdES version
                XAdESSigner.XAdESVersion = SBXMLAdES.Unit.XAdES_v1_4_1;

                // Generating the XAdES structure. Specify the desired XAdES form as a parameter
                XAdESSigner.Generate(
                    Timestamp.AddTimestamp ? SBXMLAdES.Unit.XAdES_T : SBXMLAdES.Unit.XAdES_BES
                );

                // Adding SignaturePolicy
                XAdESSigner.QualifyingProperties.SignedProperties.SignedSignatureProperties.SignaturePolicyIdentifier.SignaturePolicyImplied = true;
                // Adding SignedTime
                XAdESSigner.QualifyingProperties.SignedProperties.SignedSignatureProperties.SignedTimeUTC = DateTime.UtcNow;
                // Adding SigningCertificate
                XAdESSigner.QualifyingProperties.SignedProperties.SignedSignatureProperties.SigningCertificateV2.AddCertificate(
                    cert,
                    SBXMLAdES.Unit.XAdES_v1_4_1);
                // Adding SignedDataObjectProperties
                // XAdES_v1_4_1 = 4
                XAdESSigner.QualifyingProperties.SignedProperties.SignedDataObjectProperties.DataObjectFormats.Add(
                    new TElXMLDataObjectFormat(4) { MimeType = "text/xml", ObjectReference = $"#{Ref.ID}" }
                    );

                // Generating the signature structure
                Signer.GenerateSignature();

                // Signing and saving the signature into the document element
                var signature = Signer.SaveEnveloped(document.DocumentElement);
                return signature.OuterXML.ToXmlElement();
            }
            finally
            {
                Signer.Dispose();
                XAdESSigner.Dispose();
                document.Dispose();
            }
        }

        /// <summary>
        /// Digitally signs a CommonSignedResponse object. The signature is stored in the Signature
        /// property of the CommonSignedResponse argument.
        /// </summary>
        /// <typeparam name="A">Request type</typeparam>
        /// <typeparam name="R">Response Type</typeparam>
        /// <param name="arg">A CommonSignedResponse object</param>
        public override void SignXmlDocumentWithCertificate<A, R>(CommonSignedResponse<A, R> arg)
        {
            DataContainer data = SigningUtils.GetDataContainer(arg.Data.Request.XmlSerialize().ToXmlElement(), arg.Data.Response.XmlSerialize().ToXmlElement(), arg.Data.Matrix);
            XmlElement dataElement = SigningUtils.DataContainerToXmlElement(data);
            var signature = Sign(dataElement);
            AddSignature(arg, signature);
        }

        /// <summary>
        /// Digitally signs a PDF document
        /// </summary>
        /// <param name="pdf">PDF document to be ditially signed</param>
        /// <returns>Digitally signed PDF document</returns>
        public override byte[] SignPDF(byte[] pdf)
        {
            using (var memoryStream = new MemoryStream())
            {
                memoryStream.Write(pdf, 0, pdf.Length);
                TElPDFDocument doc = new TElPDFDocument();
                try
                {
                    // Opening the document.
                    doc.Open(memoryStream);

                    // Adding new signature.
                    int index = doc.AddSignature();
                    TElPDFSignature sig = doc.get_Signatures(index);
                    sig.SigningTime = DateTime.UtcNow;
                    sig.Invisible = false;

                    int padding = 5;
                    sig.WidgetProps.AutoPos = false;
                    sig.WidgetProps.OffsetX = doc.get_PageInfos(doc.PageInfoCount - 1).Width - sig.WidgetProps.Width - padding;
                    sig.WidgetProps.OffsetY = padding;

                    sig.WidgetProps.BackgroundStyle = TSBPDFWidgetBackgroundStyle.pbsNoBackground;
                    sig.Page = doc.PageInfoCount - 1;

                    // Creating a handler and assigning it to the new signature object.
                    TElPDFAdvancedPublicKeySecurityHandler handler = new TElPDFAdvancedPublicKeySecurityHandler();
                    var tspClient = new TElHTTPTSPClient();
                    var httpClient = new TElHTTPSClient();
                    try
                    {
                        sig.Handler = handler;
                        // certStorage should contain at least one certificate
                        // with an associated private key.

                        var certStorage = new TElMemoryCertStorage();
                        var cert = TElX509CertificateFinder.GetCertificate();
                        certStorage.Clear();
                        certStorage.Add(cert, true);
                        handler.CertStorage = certStorage;
                        handler.IgnoreChainValidationErrors = true;

                        if (Timestamp.AddTimestamp)
                        {
                            tspClient.HTTPClient = httpClient;
                            tspClient.URL = Timestamp.TimestampServer;
                            tspClient.HashAlgorithm = SBConstants.Unit.SB_ALGORITHM_DGST_SHA1;
                            handler.TSPClient = tspClient;
                            handler.IgnoreTimestampFailure = true;
                        }

                        // Basic signature type.
                        handler.SignatureType = SBPDFSecurity.TSBPDFPublicKeySignatureType.pstPKCS7SHA1;

                        // Adobe PDF security filter name.
                        handler.CustomName = "Adobe.PPKMS";

                        // Saving and closing the document.
                        doc.Close(true);
                    }
                    finally
                    {
                        handler.Dispose();
                        tspClient.Dispose();
                        httpClient.Dispose();
                    }
                }
                finally
                {
                    doc.Dispose();
                }
                return memoryStream.ToArray();
            }
        }

    }
}
