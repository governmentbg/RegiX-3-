using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegiX.Processors.PDFResponseProcessor;
using SBX509;
using System;
using System.ComponentModel.Composition;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using TechnoLogica.RegiX.Adapters.Common.Interfaces;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.BaseSigner;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Common.Utils;
using TechnoLogica.RegiX.MFANotariesAdapter.APIService;
using TechnoLogica.RegiX.MFANotariesAdapter.Helpers;
using TechnoLogica.RegiX.MFANotariesAdapter.Integration;
using TechnoLogica.RegiX.SecureBlackBoxSigner;

namespace TechnoLogica.RegiX.MFANotariesAdapter.Tests
{
    [TestClass]
    [Export(typeof(ICertificateFinder<TElX509Certificate>))]
    public class MFANotariesIntegrationUtilsTests : ICertificateFinder<TElX509Certificate>, ICertificateFinder<X509Certificate2>
    {
        private const string CERTIFICATE_FIND_VALUE = "C9C0FEB532740F8C0CE893F24C81EB12483E484B";
        private const StoreLocation CERTIFICATE_STORE_LOCATION = StoreLocation.LocalMachine;
        private const X509FindType CERTIFICATE_FIND_TYPE = X509FindType.FindByThumbprint;
        private const StoreName CERTIFICATE_STORE_NAME = StoreName.My;

        private static MFANotariesIntegrationUtilsTests certificateFinderInstance = new MFANotariesIntegrationUtilsTests();

        [ClassInitialize]
        public static void UnitTest1Initialize(TestContext context)
        {
            ConfigurationManager.AppSettings["SecureBlackBoxLicenseKey"] = "###";
            ConfigurationManager.AppSettings["EOPdfLicenseKey"] = "###";

            // The following values should be provided when the provideExternalCertificateFinder is not set to true
            //ConfigurationManager.AppSettings["CertificateFindValue"] = CERTIFICATE_FIND_VALUE;
            //ConfigurationManager.AppSettings["CertificateStoreLocation"] = Enum.GetName(typeof(StoreLocation), CERTIFICATE_STORE_LOCATION);
            //ConfigurationManager.AppSettings["CertificateStoreName"] = Enum.GetName(typeof(StoreName), CERTIFICATE_STORE_NAME);
            //ConfigurationManager.AppSettings["CertificateX509FindType"] = Enum.GetName(typeof(X509FindType), CERTIFICATE_FIND_TYPE);

            Util.Initialize(AppDomain.CurrentDomain.BaseDirectory, true);
            Composition.CompositionContainer.ComposeExportedValue<ICertificateFinder<X509Certificate2>>(certificateFinderInstance);
            Composition.CompositionContainer.ComposeExportedValue<ICertificateFinder<TElX509Certificate>>(certificateFinderInstance);
        }

        [TestMethod]
        public void InitializeTest()
        {
            Assert.IsNotNull(Composition.CompositionContainer.GetExportedValue<IEOPdfLicenseKeyResolver>());
            Assert.IsNotNull(Composition.CompositionContainer.GetExportedValue<ISecureBlackBoxLicenseKeyResolver>());
            Assert.IsNotNull(Composition.CompositionContainer.GetExportedValue<ICertificateFinder<TElX509Certificate>>());
            Assert.IsNotNull(Composition.CompositionContainer.GetExportedValue<ISigner>());
            Assert.IsNotNull(Composition.CompositionContainer.GetExportedValue<IResponseProcessor>(nameof(ResponseProcessing.TransformToPDF)));
            Assert.IsNotNull(Composition.CompositionContainer.GetExportedValue<IResponseProcessor>(Enum.GetName(typeof(ResponseProcessing), ResponseProcessing.TransformToPDF)));
            ;
        }

        [DataTestMethod]
        [DataRow(ResponseProcessing.TransformToPDF)]
        [DataRow(0)]
        public void PrepareResultTest(ResponseProcessing responseProcessing)
        {
            string result = PrepareResult(responseProcessing);

            Console.WriteLine(result);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CheckNotSignedWhenPDFTest()
        {
            string result = PrepareResult(ResponseProcessing.TransformToPDF);
            var serviceResultData = result.XmlDeserialize<ServiceResultData>();
            Assert.IsNull(serviceResultData.Signature);
        }

        [TestMethod]
        public void ExtractPDFResponseTest()
        {
            string result = PrepareResult(ResponseProcessing.TransformToPDF);
            var pdf = Util.ExtractPDFResponse(result);
            File.WriteAllBytes("PrepareResultTest.Output.pdf", pdf);
            Assert.IsTrue(pdf.Length > 0);
        }

        [TestMethod]
        public void ReplaceResponseTest()
        {
            string result = PrepareResult(ResponseProcessing.TransformToPDF);
            var pdf = Util.ExtractPDFResponse(result);
            var pdfSigned = Composition.CompositionContainer.GetExportedValue<ISigner>().SignPDF(pdf);
            var replacedResult = Util.ReplaceResponse(result, pdfSigned);
            var pdfSignedFromResult = Util.ExtractPDFResponse(replacedResult);
            File.WriteAllBytes("ReplaceResponseTest.Output.pdf", pdfSignedFromResult);
            Assert.IsTrue(pdf.Length > 0);
        }


        private string PrepareResult(ResponseProcessing responseProcessing)
        {
            var api = Composition.CompositionContainer.GetExportedValue<IAPIService>(typeof(IMFANotariesAPI).FullName);
            var sampleRequestXML = api.GetSampleRequest(nameof(IMFANotariesAPI.SendNotaryDocuments));
            var sampleRequest = sampleRequestXML.XmlDeserialize<SendNotaryDocumentsRequest>();
            var operationRequest = new OperationRequest();
            operationRequest.Request = sampleRequest;
            operationRequest.AccessMatrix = AccessMatrix.CreateForType(typeof(SendNotaryDocumentsResponse));
            operationRequest.AdapterAdditionalParameters = new AdapterAdditionalParameters()
            {
                ApiServiceCallId = 3,
                ResponseProcessing = responseProcessing,
                ReturnAccessMatrix = true,
                SignResult = true
            };
            PrepareProcessingData(operationRequest.AdapterAdditionalParameters);

            string rawRequest = operationRequest.XmlSerialize();

            var sampleResponseXml = api.GetSampleResponse(nameof(IMFANotariesAPI.SendNotaryDocuments));
            var sampleResponse = sampleResponseXml.XmlDeserialize<SendNotaryDocumentsResponse>();

            var result = Util.PrepareResult(rawRequest, sampleResponseXml);
            return result;
        }

        public void PrepareProcessingData(AdapterAdditionalParameters additionalParameters)
        {
            var salt = new byte[64];
            using (var random = new RNGCryptoServiceProvider())
            {
                random.GetNonZeroBytes(salt);
            }
            string verificationCode = $"{additionalParameters.ApiServiceCallId}.{Convert.ToBase64String(salt)}";

            var persitanceProvider = Composition.CompositionContainer.GetExportedValue<IPersistanceProvider>();
            persitanceProvider.PersistProcessing(additionalParameters.ApiServiceCallId, verificationCode);

            if (additionalParameters.ProcessingData.Count(pd => pd.Key == "OperationName") == 0)
            {
                additionalParameters.ProcessingData.Add(
                    new ProcessingDataEntry()
                    {
                        Key = "OperationName",
                        Value = nameof(IMFANotariesAPI.SendNotaryDocuments).XmlSerialize().ToXmlElement()
                    }
                );
            }
            additionalParameters.ProcessingData.Add(
                new ProcessingDataEntry()
                {
                    Key = "VerificationCode",
                    Value = verificationCode.XmlSerialize().ToXmlElement()
                }
            );
            additionalParameters.ProcessingData.AddRange(
               new ProcessingDataEntry[] {
                    new ProcessingDataEntry()
                    {
                        Key = "APIServiceInterface",
                        Value = "TechnoLogica.RegiX.MFANotariesAdapter.APIService.IMFANotariesAPI".XmlSerialize().ToXmlElement()
                    }
               }
           );
        }
        [TestMethod]
        public void CreateSelfSignedCertificateTest()
        {
            Assert.IsNotNull(CreateSelfSignedCertificate());
        }


        public X509Certificate2 GetSelfSignedCertificateX509()
        {
            var rsa = RSA.Create(2048); // generate asymmetric key pair
            var req = new CertificateRequest("cn=test-cer", rsa, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
            var cert = req.CreateSelfSigned(DateTimeOffset.Now, DateTimeOffset.Now.AddYears(5));
            return cert;
        }

        public TElX509Certificate CreateSelfSignedCertificate()
        {
            var cert = GetSelfSignedCertificateX509();
            // Needed for the loading of the license
            var signer = Composition.CompositionContainer.GetExportedValue<ISigner>();
            TElX509Certificate telCertificate = new TElX509Certificate();
            var pfxExport = cert.Export(X509ContentType.Pfx, "password");
            telCertificate.LoadFromBufferPFX(pfxExport, "password");
            return telCertificate;
        }

        public TElX509Certificate GetCertificate()
        {
            return CreateSelfSignedCertificate();
        }

        X509Certificate2 ICertificateFinder<X509Certificate2>.GetCertificate()
        {
            return GetSelfSignedCertificateX509();
        }
    }
}
