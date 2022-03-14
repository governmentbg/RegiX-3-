using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;

namespace TechnoLogica.RegiX.Adapters.NetCoreAdapterHost
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }
        
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseUrls("http://0.0.0.0:80")
                .ConfigureAppConfiguration((builderContext, config) =>
                {
                     config.Add<WritableJsonConfigurationSource>(
                          s =>
                          {
                              s.FileProvider = null;
                              s.Path = "settings.json";
                              s.Optional = true;
                              s.ReloadOnChange = true;
                              s.ResolveFileProvider();
                          }
                    );
                })
                .UseStartup<Startup>();
                // .ConfigureLogging(logging => logging.SetMinimumLevel(LogLevel.Trace));
    }
}
