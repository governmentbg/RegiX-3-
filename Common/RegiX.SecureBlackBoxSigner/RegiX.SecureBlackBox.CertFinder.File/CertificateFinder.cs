using SBX509;
using System;
using System.ComponentModel.Composition;
using System.Configuration;
using TechnoLogica.RegiX.BaseSigner;

namespace TechnoLogica.RegiX.SecureBlackBox.CertFinder.File
{
    /// <summary>
    /// Implements a certificate finder and timestamp server information.
    /// </summary>
    [Export(typeof(ICertificateFinder<TElX509Certificate>))]
    public class CertificateFinder : ICertificateFinder<TElX509Certificate>
    {
        /// <summary>
        /// Retrieves the certificate
        /// </summary>
        /// <returns>Retrieved certificate</returns>
        public TElX509Certificate GetCertificate()
        {
            TElX509Certificate telCertificate = new TElX509Certificate();
            string certificateFile = ConfigurationManager.AppSettings["CertificateFile"];
            string certificatePassword = ConfigurationManager.AppSettings["CertificatePassword"];
            telCertificate.LoadFromBufferPFX(System.IO.File.ReadAllBytes(certificateFile), certificatePassword);
            return telCertificate;
        }
    }
}
