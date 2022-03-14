using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SBTypes;
using SBWinCertStorage;
using SBX509;
using TechnoLogica.RegiX.BaseSigner;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Common.Utils;

namespace TechnoLogica.RegiX.SecureBlackBoxSigner.Tests
{
    [TestClass]
    public class SignerTests
    {
        private static string TIMESTAMP_SERVER = "http://tsa.swisssign.net";
        private static bool ADD_TIME_STAMP = true;

        [ClassInitialize]
        public static void SignerTestInitialize(TestContext context)
        {
            AggregateCatalog catalog = new AggregateCatalog();
            CompositionContainer result = new CompositionContainer(catalog, true);
            Mock<ISecureBlackBoxLicenseKeyResolver> keyResolverMock = new Mock<ISecureBlackBoxLicenseKeyResolver>();
            keyResolverMock.Setup(k => k.LicenseKey).Returns("###");
            var signer = new Signer(keyResolverMock.Object);
            Mock<ICertificateFinder<TElX509Certificate>> certificateFinderMock = new Mock<ICertificateFinder<TElX509Certificate>>();
            Mock<ICertificateFinder<X509Certificate2>> certificateFinderMock2 = new Mock<ICertificateFinder<X509Certificate2>>();
            certificateFinderMock.Setup(c => c.GetCertificate()).Returns(GetPersonalCertificate());
            certificateFinderMock2.Setup(c => c.GetCertificate()).Returns(CreateSelfSignedCertificate2());
            result.ComposeExportedValue(certificateFinderMock.Object);
            result.ComposeExportedValue(certificateFinderMock2.Object);
            Mock<IAddTimestamp> addTimestamp = new Mock<IAddTimestamp>();
            addTimestamp.SetupGet(c => c.TimestampServer).Returns(TIMESTAMP_SERVER);
            addTimestamp.SetupGet(c => c.AddTimestamp).Returns(ADD_TIME_STAMP);
            result.ComposeExportedValue(addTimestamp.Object);
            result.ComposeExportedValue<ISigner>(signer);
            result.SatisfyImportsOnce(signer);
            Composition.CompositionContainer = result;
        }

        private static TElX509Certificate CreateSelfSignedCertificate()
        {
            TElX509Certificate telCertificate = new TElX509Certificate();
            telCertificate.LoadFromBufferPFX(File.ReadAllBytes("RegiX3Certificate.pfx"), "P@ssw0rd");
            return telCertificate;
        }

        public static TElX509Certificate GetPersonalCertificate()
        {
            var systemStore = new TElWinCertStorage();
            systemStore.AccessType = TSBStorageAccessType.atCurrentUser;

            // Read from Store
            systemStore.SystemStores.BeginUpdate();
            try
            {
                systemStore.SystemStores.Clear();
                systemStore.SystemStores.Add("MY");
            }
            finally
            {
                systemStore.SystemStores.EndUpdate();
            }

            TMessageDigest160 Digest = new TMessageDigest160();
            byte[] bytes = StringToByteArray("c6fb1b6df3777a973801585397eb86ea16263165");
            SBUtils.Unit.ByteArrayToDigest160(bytes, 0, ref Digest);

            int Index = systemStore.FindByHashSHA1(Digest);
            return systemStore.get_Certificates(Index);
        }

        private static byte[] StringToByteArray(string hexValues)
        {
            //Cleaning string from app setting
            hexValues = ToAscii(hexValues);

            List<byte> byteList = new List<byte>();
            for (int i = 0; i < hexValues.Length - 1; i = i + 2)
            {
                // Convert the number expressed in base-16 to an integer and cast to byte. 
                byteList.Add((byte)(Convert.ToInt32(hexValues.Substring(i, 2), 16)));
            }
            return byteList.ToArray();
        }


        private static string ToAscii(string dirty)
        {
            //Cleans the string
            var encoder =
                ASCIIEncoding.GetEncoding(
                    "us-ascii",
                    new EncoderReplacementFallback(string.Empty),
                    new DecoderExceptionFallback()
                );
            return encoder.GetString(encoder.GetBytes(dirty));
        }

        private static X509Certificate2 CreateSelfSignedCertificate2()
        {
            X509Certificate2 result = new X509Certificate2("RegiX3Certificate.pfx", "P@ssw0rd");
            return result;
        }

        [TestMethod]
        public void SignXmlDocumentWithCertificateTest()
        {
            TIMESTAMP_SERVER = null;
            SignXML();
        }

        [TestMethod]
        public void SignXmlDocumentWithCertificateTest1()
        {
            TIMESTAMP_SERVER = null;
            var sginedServiceResult = SignXMLAndReturnServiceResult();
            var signer = Composition.CompositionContainer.GetExportedValue<ISigner>() as Signer;
            var signature = signer.Sign(sginedServiceResult);
        }

        [TestMethod]
        public void TestMethodWithTimestamp()
        {
            TIMESTAMP_SERVER = "http://tsa.swisssign.net";
            SignXML();
        }

        [TestMethod]
        public void SignPDFTest()
        {
            ADD_TIME_STAMP = true;
            TIMESTAMP_SERVER = "http://tsa.swisssign.net";
            ISigner signer = Composition.CompositionContainer.GetExportedValue<ISigner>();
            var signedPDF = signer.SignPDF(File.ReadAllBytes(@"D:\Projects\RegiX-AzureDevOps\RegiX.Processors.FOPResponseProcessor\RegiX.Processors.FOPResponseProcessor.Test\bin\Debug\netcoreapp2.1\output3-signed.pdf"));
            File.WriteAllBytes(@"D:\Projects\RegiX-AzureDevOps\RegiX.Processors.FOPResponseProcessor\RegiX.Processors.FOPResponseProcessor.Test\bin\Debug\netcoreapp2.1\output3-signed2.pdf", signedPDF);
        }

        [TestMethod]
        public void SignPDFTest1()
        {
            ADD_TIME_STAMP = true;
            TIMESTAMP_SERVER = "http://tsa.swisssign.net";
            ISigner signer = Composition.CompositionContainer.GetExportedValue<ISigner>();
            var signedPDF = signer.SignPDF(File.ReadAllBytes(@"D:\Projects\RegiX-AzureDevOps\RegiX.Processors.FOPResponseProcessor\RegiX.Processors.FOPResponseProcessor.Test\bin\Debug\netcoreapp2.1\output.pdf"));
            File.WriteAllBytes(@"D:\Projects\RegiX-AzureDevOps\RegiX.Processors.FOPResponseProcessor\RegiX.Processors.FOPResponseProcessor.Test\bin\Debug\netcoreapp2.1\output3-signed-new.pdf", signedPDF);
        }

        private static void SignXML()
        {
            ISigner signer = Composition.CompositionContainer.GetExportedValue<ISigner>();
            var signObject = new TechnoLogica.RegiX.Common.DataContracts.CommonSignedResponse<string, string>() { Data = new TechnoLogica.RegiX.Common.DataContracts.DataContainer<string, string>() { Request = "Ooops", Response = "Opa" } };
            Console.WriteLine(signObject.XmlSerialize().ToXmlElement().OuterXml);
            signer.SignXmlDocumentWithCertificate(signObject);
            var signature = signObject.ToServiceResultDataSigned().XmlSerialize().ToXmlElement().OuterXml;
            Console.WriteLine(signature);
        }

        private static XmlElement SignXMLAndReturnServiceResult()
        {
            ISigner signer = Composition.CompositionContainer.GetExportedValue<ISigner>();
            var signObject = new TechnoLogica.RegiX.Common.DataContracts.CommonSignedResponse<string, string>() { Data = new TechnoLogica.RegiX.Common.DataContracts.DataContainer<string, string>() { Request = "Ooops", Response = "Opa" } };
            Console.WriteLine(signObject.XmlSerialize().ToXmlElement().OuterXml);
            signer.SignXmlDocumentWithCertificate(signObject);
            var signature = signObject.ToServiceResultDataSigned().XmlSerialize().ToXmlElement();
            return signature;
        }

        [TestMethod]
        public void BlackBoxSettings()
        {
            Assert.IsNull(new BlackBoxSettings().TimestampServer);
            Assert.IsFalse(new BlackBoxSettings().AddTimestamp);
        }
    }
}
