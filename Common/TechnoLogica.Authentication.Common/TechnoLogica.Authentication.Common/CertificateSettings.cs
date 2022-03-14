using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace TechnoLogica.Authentication.Common
{
    public enum CertificatePlatform
    {
        Windows,
        Linux
    }

    public class CertificateSettings : ValidateSettings
    {
        public CertificatePlatform Platfrom { get; set; }
        public string CertificateFileName { get; set; }
        public string CertificatePassword { get; set; }
        public StoreName CertificateStoreName { get; set; }
        public StoreLocation CertificateStoreLocation { get; set; }
        public X509FindType CertificateX509FindType { get; set; }
        public object CertificateFindValue { get; set; }

        public override void Validate()
        {
            switch (Platfrom)
            {
                case CertificatePlatform.Linux:
                    {
                        if (string.IsNullOrEmpty(CertificateFileName))
                        {
                            throw new ArgumentException("Option CertificateFileName for CertificateSettings is mandatory when Liux platform is specified!");
                        }
                        break;
                    }
                case CertificatePlatform.Windows:
                    {
                        if (CertificateFindValue == null)
                        {
                            throw new ArgumentException("Option CertificateFindValue for CertificateSettings is mandatory when Windows platform is specified!");
                        }
                        break;
                    }
            }
        }

        public X509Certificate2 GetX509Certificate2()
        {
            switch (Platfrom)
            {
                case CertificatePlatform.Windows:
                    {
                        return SigningUtils.GetX509Certificate(
                            CertificateStoreName,
                            CertificateStoreLocation,
                            CertificateX509FindType,
                            CertificateFindValue);
                    }
                case CertificatePlatform.Linux:
                default:
                    {
                        if (string.IsNullOrEmpty(CertificatePassword))
                        {
                            return new X509Certificate2(CertificateFileName);
                        }
                        else
                        {
                            return new X509Certificate2(CertificateFileName, CertificatePassword);
                        }
                    }
            }
        }
    }
}
