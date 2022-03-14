using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace RegiX.IdentityServer.Common
{
    public enum CertificatePlatform
    {
        Windows,
        Linux
    }

    public class CertificateSettings
    {
        public CertificatePlatform Platfrom { get; set; }
        public string FileName { get; set; }
        public string Password { get; set; }
        public StoreName EAuthCertificateStoreName { get; set; }
        public StoreLocation EAuthCertificateStoreLocation { get; set; }
        public X509FindType EAuthCertificateX509FindType { get; set; }
        public object EAuthCertificateFindValue { get; set; }
    }

    public class EAuthSettings
    {
        public CertificateSettings CertificateSettings { get; set; }


        public StoreName EAuthCertificateStoreName { get; set; }
        public StoreLocation EAuthCertificateStoreLocation { get; set; }
        public X509FindType EAuthCertificateX509FindType { get; set; }
        public object EAuthCertificateFindValue { get; set; }

        public string SystemProviderOID { get; set; }
        public string RequestServiceOID { get; set; }
        public string CallbackPath { get; set; }
        public string InformationSystemName { get; set; }
        public string RedirectConsumerServiceURL { get; set; }
    }
}
