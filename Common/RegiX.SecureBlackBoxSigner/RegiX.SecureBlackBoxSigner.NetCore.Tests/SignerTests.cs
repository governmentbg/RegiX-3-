using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SBX509;
using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using TechnoLogica.RegiX.BaseSigner;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.Utils;
using TechnoLogica.RegiX.SecureBlackBoxSigner.NetCore;

namespace RegiX.SecureBlackBox.NetCore.Tests
{
    [TestClass]
    public class SignerTests
    {
        private static string TIMESTAMP_SERVER = null;

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
            certificateFinderMock.Setup(c => c.GetCertificate()).Returns(CreateSelfSignedCertificate());
            certificateFinderMock2.Setup(c => c.GetCertificate()).Returns(CreateSelfSignedCertificate2());
            result.ComposeExportedValue(certificateFinderMock.Object);
            result.ComposeExportedValue(certificateFinderMock2.Object);
            Mock<IAddTimestamp> addTimestamp = new Mock<IAddTimestamp>();
            addTimestamp.SetupGet(c => c.TimestampServer).Returns(TIMESTAMP_SERVER);
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
        public void TestMethodWithTimestamp()
        {
            TIMESTAMP_SERVER = "http://tsa.swisssign.net";
            SignXML();
        }

        //[TestMethod]
        //public void TestMultipleSignWithTimestamp()
        //{
        //    TIMESTAMP_SERVER = "http://tsa.swisssign.net";
        //    MultiSignXML();
        //}

        private static void SignXML()
        {
            ISigner signer = Composition.CompositionContainer.GetExportedValue<ISigner>();
            var signObject = new TechnoLogica.RegiX.Common.DataContracts.CommonSignedResponse<string, string>() { Data = new TechnoLogica.RegiX.Common.DataContracts.DataContainer<string, string>() { Request = "Ooops", Response = "Opa" } };
            signer.SignXmlDocumentWithCertificate(signObject);
            var signature = signObject.ToServiceResultDataSigned().XmlSerialize().ToXmlElement().OuterXml;
            Console.WriteLine(signature);
        }
        private static void MultiSignXML()
        {
            ISigner signer = Composition.CompositionContainer.GetExportedValue<ISigner>();
            var signObject = new TechnoLogica.RegiX.Common.DataContracts.CommonSignedResponse<string, string>() { Data = new TechnoLogica.RegiX.Common.DataContracts.DataContainer<string, string>() { Request = "Ooops", Response = "Opa" } };
            signer.SignXmlDocumentWithCertificate(signObject);
            signer.SignXmlDocumentWithCertificate(signObject);
            var signature = signObject.ToServiceResultDataSigned().XmlSerialize().ToXmlElement().OuterXml;
            Console.WriteLine(signature);
        }

        [TestMethod]
        public void CertificateFinder()
        {
            Assert.IsNull(new BlackBoxSettings().TimestampServer);
            Assert.IsFalse(new BlackBoxSettings().AddTimestamp);
        }
    }
}
