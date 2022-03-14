using SBTypes;
using SBWinCertStorage;
using SBX509;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TechnoLogica.RegiX.BaseSigner;

namespace TechnoLogica.RegiX.SecureBlackBoxSigner
{
    /// <summary>
    /// Implements a timestamp server information and licensekey.
    /// </summary>
    [Export(typeof(IAddTimestamp))]
    [Export(typeof(ISecureBlackBoxLicenseKeyResolver))]
    public class BlackBoxSettings : IAddTimestamp, ISecureBlackBoxLicenseKeyResolver
    {
        /// <summary>
        /// If timestamp should be added
        /// </summary>
        public bool AddTimestamp => !string.IsNullOrEmpty(TimestampServer);

        /// <summary>
        /// Timestamp server. Retrieved from the application settings
        /// </summary>
        public string TimestampServer => ConfigurationManager.AppSettings["TimestampServer"];
               
        /// <summary>
        /// Secure Black Box license key form Application configuration
        /// <summary>
        public string LicenseKey => ConfigurationManager.AppSettings["SecureBlackBoxLicenseKey"];
    }
}
