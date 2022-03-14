using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace TechnoLogica.RegiX.BaseSigner.Test
{
    [TestClass]
    public class CertificateFinderTests
    {
        private const string CERTIFICATE_FIND_VALUE = "054FD12C0B1CCCD9897E0F9DBD6AB88607448709";
        private const StoreLocation CERTIFICATE_STORE_LOCATION = StoreLocation.LocalMachine;
        private const X509FindType CERTIFICATE_FIND_TYPE = X509FindType.FindByThumbprint;
        private const StoreName CERTIFICATE_STORE_NAME = StoreName.My;

        [ClassInitialize]
        public static void CertificateFinderTestsInitialize(TestContext context)
        {
            ConfigurationManager.AppSettings["CertificateFindValue"] = CERTIFICATE_FIND_VALUE;
            ConfigurationManager.AppSettings["CertificateStoreLocation"] = Enum.GetName(typeof(StoreLocation), CERTIFICATE_STORE_LOCATION);
            ConfigurationManager.AppSettings["CertificateStoreName"] = Enum.GetName(typeof(StoreName), CERTIFICATE_STORE_NAME);
            ConfigurationManager.AppSettings["CertificateX509FindType"] = Enum.GetName(typeof(X509FindType), CERTIFICATE_FIND_TYPE);
        }

        [TestMethod]
        public void GetCertificateStoreNameTest()
        {
            Assert.AreEqual(CertificateFinder.GetCertificateStoreName(), CERTIFICATE_STORE_NAME);
        }

        [TestMethod]
        public void GetCertificateX509FindTypeTest()
        {
            Assert.AreEqual(CertificateFinder.GetCertificateX509FindType(), CERTIFICATE_FIND_TYPE);
        }

        [TestMethod]
        public void GetCertificateStoreLocationTest()
        {
            Assert.AreEqual(CertificateFinder.GetCertificateStoreLocation(), CERTIFICATE_STORE_LOCATION);
        }

        [TestMethod]
        public void GetCertificateFindValueTest()
        {
            Assert.AreEqual(CertificateFinder.GetCertificateFindValue(), CERTIFICATE_FIND_VALUE);
        }
    }
}
