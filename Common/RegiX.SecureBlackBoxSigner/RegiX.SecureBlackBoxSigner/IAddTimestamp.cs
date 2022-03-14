using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RegiX.SecureBlackBoxSigner.Tests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
[assembly: InternalsVisibleTo("ConsoleTester")]

namespace TechnoLogica.RegiX.SecureBlackBoxSigner
{
    /// <summary>
    /// Defines information for the timestamp server and if a timestamp should be added
    /// </summary>
    interface IAddTimestamp
    {
        /// <summary>
        /// If a timestamp should be added
        /// </summary>
        bool AddTimestamp { get; }

        /// <summary>
        /// Timestamp server
        /// </summary>
        string TimestampServer { get; }
    }
}
