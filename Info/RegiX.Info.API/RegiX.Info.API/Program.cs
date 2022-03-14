using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using TechnoLogica.Common.DataProtection;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.Composition.Hosting;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace RegiX.Info.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var webHost = CreateWebHostBuilder(args).Build();
            if (IsConfigure(args))
            {
                var container = webHost.Services.GetService<CompositionContainer>();
                foreach (var authenticationProvider in container.GetExportedValues<IProtectedSettingsProvider>())
                {
                    authenticationProvider.ConfigureProtectedSettings();
                }
                Console.WriteLine("Configuration finished!");
            }
            else
            {
                webHost.Run();
            }
        }

        private static bool IsConfigure(string[] args)
        {
            return args != null && args.Length == 1 && args[0].ToLowerInvariant() == "-config";
        }


        /// <summary>
        /// Creates web host builder
        /// </summary>
        /// <param name="args">Console arguments</param>
        /// <returns>Instance of the web host builder</returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var result = WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
            if (IsConfigure(args))
            {
                result = result.ConfigureAppConfiguration(
                     config => config.Add<WritableJsonConfigurationSource>(
                           s =>
                           {
                               s.FileProvider = null;
                               s.Path = "appsettings.json";
                               s.Optional = true;
                               s.ReloadOnChange = true;
                               s.ResolveFileProvider();
                           }
                     )
                 );
            }
            return result;
        }
    }
}
