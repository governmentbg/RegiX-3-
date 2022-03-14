using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnoLogica.RegiX.Client.API
{
    //TODO: Use the class in Common.API when updated to version 3.*.*
    /// <summary>
    /// IConfiguration extensions
    /// </summary>
    public static class IConfigurationExtensions
    {
        /// <summary>
        /// Loads specific section from the configuration
        /// </summary>
        /// <typeparam name="T">Descriptino of the sectin to be loaded</typeparam>
        /// <param name="configuration">Configuration</param>
        /// <returns>Retrieved configuration section object</returns>
        public static T GetSettings<T>(this IConfiguration configuration)
            where T : class
        {
            var regiXClientSettingsSection = configuration.GetSection(typeof(T).Name);
            if (regiXClientSettingsSection != null)
            {
                return regiXClientSettingsSection.Get<T>();
            }
            else
            {
                return null;
            }
        }
    }
}
