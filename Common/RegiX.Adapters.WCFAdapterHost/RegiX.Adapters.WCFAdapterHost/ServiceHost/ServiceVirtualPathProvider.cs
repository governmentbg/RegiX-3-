using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Caching;
using System.Web.Hosting;
using TechnoLogica.RegiX.Common;

namespace TechnoLogica.RegiX.Adapters.WCFAdapterHost.ServiceHost
{
    public class ServiceVirtualPathProvider : VirtualPathProvider
    {
        private static List<string> _cashedServiceNames;

        public static List<string> CashedServiceNames
        {
            get
            {
                if (_cashedServiceNames == null)
                {
                    var adapters = Composition.CompositionContainer.GetExportedValues<IAdapterService>();
                    _cashedServiceNames =
                        adapters
                        .Select(a => a.AdapterServiceName.ToLower())
                        .ToList();
                }
                return _cashedServiceNames;
            }
        }

        /// <summary>
        /// Determines if the file exists at the virtual path.
        /// </summary>
        /// <param name="virtualPath">The virtual path.</param>
        /// <returns>True if the file exists, otherwise false.</returns>
        public override bool FileExists(string virtualPath)
        {
            if (IsServiceCall(virtualPath))
            {
                return true;
            }
            return Previous.FileExists(virtualPath);
        }

        /// <summary>
        /// Creates a cache dependency based on the specified virtual paths.
        /// </summary>
        /// <param name="virtualPath">The path to the primary virtual resource.</param>
        /// <param name="virtualPathDependencies">An array of paths to other resources required by the primary virtual resource.</param>
        /// <param name="utcStart">The UTC time at which the virtual resources were read.</param>
        /// <returns>A <see cref="CacheDependency"/> object for the specified virtual resources</returns>
        public override CacheDependency GetCacheDependency(string virtualPath, IEnumerable virtualPathDependencies, DateTime utcStart)
        {
            if (IsServiceCall(virtualPath))
            {
                return null;
            }
            else
            {
                return Previous.GetCacheDependency(virtualPath, virtualPathDependencies, utcStart);
            }
        }

        /// <summary>
        /// Gets the virtual file that is represented by the virtual path.
        /// </summary>
        /// <param name="virtualPath">The virtual file path.</param>
        /// <returns>The <see cref="VirtualFile"/> instance.</returns>
        public override VirtualFile GetFile(string virtualPath)
        {
            if (IsServiceCall(virtualPath))
            {
                return new ServiceVirtualFile(virtualPath);
            }
            else
            {
                return Previous.GetFile(virtualPath);
            }
        }

        /// <summary>
        /// Determines whether the current virtual path is a service call.
        /// </summary>
        /// <param name="virtualPath">The virtual file path.</param>
        /// <returns>True if the current virtual path is a service call, otherwise false.</returns>
        private static bool IsServiceCall(string virtualPath)
        {
            string serviceName = GetServiceName(virtualPath).ToLower();
            return CashedServiceNames.Exists((s) => s == serviceName);
        }

        private static bool ServiceInterfaceFilter(Type typeObj, Object criteriaObj)
        {
            if (typeObj.ToString() == criteriaObj.ToString())
                return true;
            else
                return false;
        }

        /// <summary>
        /// Gets the name of the service from the virtual file path.
        /// </summary>
        /// <param name="virtualFile">The virtual file path.</param>
        /// <returns>The service name.</returns>
        private static string GetServiceName(string virtualFile)
        {
            string name = virtualFile.Substring(
                virtualFile.LastIndexOf("/") + 1);
            name = name.Substring(0, name.LastIndexOf("."));

            return name;
        }
    }
}