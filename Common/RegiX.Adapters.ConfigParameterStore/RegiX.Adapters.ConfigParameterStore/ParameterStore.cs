using System;
using System.ComponentModel.Composition;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.Interfaces;

namespace RegiX.Adapters.ConfigParameterStore
{
    [Export(typeof(IParameterStore))]
    public class ConfigurationParameterStore : BaseParameterStore
    {
        private Configuration Config { get; set; }

        public ConfigurationParameterStore()
        {
            ExeConfigurationFileMap configMap = new ExeConfigurationFileMap();
            configMap.ExeConfigFilename = $"{HttpRuntime.BinDirectory}{Path.DirectorySeparatorChar}settings.config";
            Config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
        }
        protected override string GetParameterValue(string key)
        {
            if (Config.AppSettings.Settings.AllKeys.Contains(key))
            {
                string result = Config.AppSettings.Settings[key].Value;
                return result;
            }
            else
            {
                return null;
            }
        }

        protected override void SetParameterValue(string key, string value)
        {
            if (Config.AppSettings.Settings.AllKeys.Contains(key))
            {
                Config.AppSettings.Settings[key].Value = value;
            }
            else
            {
                Config.AppSettings.Settings.Add(key, value);
            }
            Config.AppSettings.SectionInformation.ProtectSection("RSAProtectedConfigurationProvider");
            Config.Save(ConfigurationSaveMode.Modified);
        }
    }
}
