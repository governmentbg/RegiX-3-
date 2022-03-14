// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using TechnoLogica.Common.DataProtection;

namespace TechnoLogica.IdentityServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Start<Startup>("TechnoLogica Identity Server", args);
        }

        public static void Start<ST>(string title, string[] args)
            where ST : Startup
        {
            Console.Title = title;
            Title = title;
            if (IsConfigure(args))
            {
                var webHost = CreateWebHostBuilder<ST>(args).Build();
                var container = webHost.Services.GetService<CompositionContainer>();
                foreach (var authenticationProvider in container.GetExportedValues<IProtectedSettingsProvider>())
                {
                    authenticationProvider.ConfigureProtectedSettings();
                }
                Console.WriteLine("Configuration finished!");
            }
            else
            {
                CreateWebHostBuilder<ST>(args).Build().Run();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder<ST>(string[] args)
            where ST : Startup
        {
            var result = WebHost.CreateDefaultBuilder(args)
                    .UseStartup<ST>()
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .UseIISIntegration()
                    .UseSerilog((context, configuration) =>
                    {
                        configuration
                            .MinimumLevel.Debug()
                            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                            .MinimumLevel.Override("System", LogEventLevel.Warning)
                            .MinimumLevel.Override("Microsoft.AspNetCore.Authentication", LogEventLevel.Information)
                            .Enrich.FromLogContext()
                            .WriteTo.File(@"identityserver4_log.txt")
                            .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}", theme: AnsiConsoleTheme.Literate);
                    });
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

        private static bool IsConfigure(string[] args)
        {
            return args != null && args.Length == 1 && args[0].ToLowerInvariant() == "-config";
        }

        public static string Title { get; set; }
    }
}
