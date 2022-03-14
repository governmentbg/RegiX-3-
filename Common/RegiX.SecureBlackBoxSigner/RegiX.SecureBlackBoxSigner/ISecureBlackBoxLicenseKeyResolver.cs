using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoLogica.RegiX.SecureBlackBoxSigner
{
    /// <summary>
    /// Defines method for resolving the needed Secure Black Box License Key
    /// </summary>
    public interface ISecureBlackBoxLicenseKeyResolver
    {
        /// <summary>
        /// Secure Black Box license key
        /// <summary>
        string LicenseKey { get; }
    }
}
