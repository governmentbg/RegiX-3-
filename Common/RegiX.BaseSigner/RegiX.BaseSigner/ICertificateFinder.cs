using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("RegiX.BaseSigner.Test")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace TechnoLogica.RegiX.BaseSigner
{
    /// <summary>
    /// Locates a certificate of type T
    /// </summary>
    /// <typeparam name="T">Type of the certificate</typeparam>
    public interface ICertificateFinder<T>
    {
        /// <summary>
        /// Locates the certificate and returns an instance
        /// </summary>
        /// <returns>Instance of a certificate</returns>
        T GetCertificate();
    }
}
