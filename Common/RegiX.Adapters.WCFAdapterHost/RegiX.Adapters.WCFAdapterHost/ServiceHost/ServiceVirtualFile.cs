using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using TechnoLogica.RegiX.Common;

namespace TechnoLogica.RegiX.Adapters.WCFAdapterHost.ServiceHost
{
    /// <summary>
    /// Defines a virtual file for a dynamic service.
    /// </summary>
    public class ServiceVirtualFile : VirtualFile
    {

        #region Constructor

        /// <summary>
        /// Initialises a new instance of <see cref="ServiceVirtualFile"/>.
        /// </summary>
        /// <param name="virtualFile">The virtual file path.</param>
        public ServiceVirtualFile(string virtualFile)
            : base(virtualFile) { }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the name of the service from the virtual file path.
        /// </summary>
        /// <param name="virtualFile">The virtual file path.</param>
        /// <returns>The service name.</returns>
        private static string GetName(string virtualFile)
        {
            string name = virtualFile.Substring(
                virtualFile.LastIndexOf("/") + 1);
            name = name.Substring(0, name.LastIndexOf("."));

            return name;
        }

        /// <summary>
        /// Opens the stream containing the virtual file content.
        /// </summary>
        /// <returns>The stream.</returns>
        public override Stream Open()
        {
            string serviceName = GetName(VirtualPath);
            var serviceImplementation = Composition.CompositionContainer.GetExportedValue<IAdapterService>(serviceName);
            string factory = typeof(AdapterServiceHostFactory).FullName;

            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);

            writer.Write($"<%@ ServiceHost Language=\"C#\" Debug=\"true\" Service=\"{serviceImplementation.AdapterServiceType.FullName}\" Factory=\"{factory}\" %>");

            writer.Flush();

            stream.Position = 0;
            return stream;
        }

        #endregion
    }
}