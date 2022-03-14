using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.DataContracts;
using TechnoLogica.RegiX.Adapters.Common.Interfaces;
using TechnoLogica.RegiX.Common.DataContracts.Parameter;

namespace RegiX.Adapters.NetCoreParameterStore
{
    [Export(typeof(IParameterStore))]
    public class ParameterStore : BaseParameterStore
    {
        [Import(typeof(IServiceProvider))]
        private IServiceProvider ServiceProvider { get; set; }

        protected IConfiguration Configuration
        {
            get
            {
                IConfiguration configuration = ServiceProvider.GetService(typeof(IConfiguration)) as IConfiguration;
                return configuration;
            }
        }

        protected IDataProtector DataProtector
        {
            get
            {
                IDataProtectionProvider dataProtectionProvider = ServiceProvider.GetService(typeof(IDataProtectionProvider)) as IDataProtectionProvider;
                var protector = dataProtectionProvider.CreateProtector("Settings encryption");
                return protector;
            }
        }

        protected override string GetParameterValue(string key)
        {
            string result = Configuration[key];
            if (!string.IsNullOrEmpty(result))
            {
                return DataProtector.Unprotect(result);
            }
            else
            {
                return null;
            }
        }

        protected override void SetParameterValue(string key, string value)
        {
            Configuration[key] = DataProtector.Protect(value);
        }
    }
}
