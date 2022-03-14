using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;

namespace TechnoLogica.RegiX.BaseSigner.Test
{
    [TestClass]
    public class BaseSignerTests
    {
        [ClassInitialize]
        public static void SignerTestInitialize(TestContext context)
        {
            AggregateCatalog catalog = new AggregateCatalog();
            CompositionContainer result = new CompositionContainer(catalog, true);
            var signer = new SimpleImplementation();
            Mock<ICertificateFinder<X509Certificate2>> certificateFinderMock = new Mock<ICertificateFinder<X509Certificate2>>();
            certificateFinderMock.Setup(c => c.GetCertificate()).Returns(CreateSelfSignedCertificate());
            result.ComposeExportedValue(certificateFinderMock.Object);
            result.ComposeExportedValue<ISigner>(signer);
            result.SatisfyImportsOnce(signer);
            Composition.CompositionContainer = result;
        }

        private static X509Certificate2 CreateSelfSignedCertificate()
        {
            var rsa = RSA.Create(2048); // generate asymmetric key pair
            var req = new CertificateRequest("cn=test-cer", rsa, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
            var cert = req.CreateSelfSigned(DateTimeOffset.Now, DateTimeOffset.Now.AddYears(5));
            return cert;
        }

        [TestMethod]
        public void GenerateSymeticKeyTest()
        {
            ISigner signer = Composition.CompositionContainer.GetExportedValue<ISigner>();
            byte[] key1 = signer.GenerateSymeticKey();
            byte[] key2 = signer.GenerateSymeticKey();
            Assert.IsFalse(key1.SequenceEqual(key2));
        }

        [TestMethod]
        public void EncryptKeyTest()
        {
            ISigner signer = Composition.CompositionContainer.GetExportedValue<ISigner>();
            byte[] key = signer.GenerateSymeticKey();
            byte[] encrtypedKey = signer.EncryptKey(key);
            byte[] decryptedKey = signer.DecryptKey(encrtypedKey);
            Assert.IsTrue(key.SequenceEqual(decryptedKey));
        }

        [TestMethod]
        public void EncryptData()
        {
            ISigner signer = Composition.CompositionContainer.GetExportedValue<ISigner>();
            byte[] key = signer.GenerateSymeticKey();
            byte[] encrtypedKey = signer.EncryptKey(key);
            string message = "Palin Text";
            byte[] data = Encoding.UTF8.GetBytes(message);
            Console.WriteLine(Convert.ToBase64String(data));
            byte[] encryptedData = signer.Encrypt(key, data);
            Console.WriteLine(Convert.ToBase64String(encryptedData));
            byte[] decryptedData = signer.Decrypt(key, encryptedData);
            Console.WriteLine(Convert.ToBase64String(decryptedData));
            string decryptedMessage = Encoding.UTF8.GetString(decryptedData);
            Assert.IsTrue(message.Equals(decryptedMessage));
        }
        [TestMethod]
        public void GetPublicKeyTest()
        {
            ISigner signer = Composition.CompositionContainer.GetExportedValue<ISigner>();
            Console.WriteLine(signer.GetPublicKeyString());
        }
    }

    [Export(typeof(ISigner))]
    public class SimpleImplementation : ABaseSigner
    {
        public override XmlElement Sign(XmlElement element)
        {
            throw new NotImplementedException();
        }

        public override byte[] SignPDF(byte[] pdf)
        {
            throw new NotImplementedException();
        }

        public override void SignXmlDocumentWithCertificate<A, R>(CommonSignedResponse<A, R> arg)
        {
            throw new NotImplementedException();
        }
    }
}
