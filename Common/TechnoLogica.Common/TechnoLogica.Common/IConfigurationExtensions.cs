using Microsoft.Extensions.Configuration;

namespace TechnoLogica.Common
{
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
            var section = configuration.GetSection(typeof(T).Name);
            if (section != null)
            {
                return section.Get<T>();
            }
            else
            {
                return null;
            }
        }
    }
}
