using System;
using System.Collections.Generic;
using System.Text;

namespace TechnoLogica.RegiX.SecureBlackBoxSigner.NetCore
{
    public interface ISecureBlackBoxLicenseKeyResolver
    {
        /// <summary>
        /// Secure Black Box license key
        /// <summary>
        string LicenseKey { get; }
    }
}
