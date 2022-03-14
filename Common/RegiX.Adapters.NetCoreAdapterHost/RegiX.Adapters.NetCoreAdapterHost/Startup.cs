using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Adapters.NetCoreAdapterHost.DynamicControllers;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using HealthChecks.UI.Client;
using TechnoLogica.RegiX.Common.DataContracts.Health;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;
using TechnoLogica.RegiX.Adapters.Common;
using System;
using TechnoLogica.RegiX.Adapters.Common.Interfaces;
using TechnoLogica.RegiX.Common.Utils;
using TechnoLogica.RegiX.Common.DataContracts;

namespace TechnoLogica.RegiX.Adapters.NetCoreAdapterHost
{
    public class Startup
    {
        ILogger _logger;
        ILoggerFactory _loggerFactory;

        public Startup(IConfiguration configuration, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
            _logger = loggerFactory.CreateLogger<Startup>();
            Configuration = configuration;

            AggregateCatalog catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(env.ContentRootPath, "RegiX.*.dll"));
            CompositionContainer result = new CompositionContainer(catalog, true);
            result.ComposeExportedValue(result);
            Composition.CompositionContainer = result;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDataProtection();

            Composition.CompositionContainer.ComposeExportedValue<IServiceProvider>(services.BuildServiceProvider());

            AddAdapterLogger(services);

            var adapters = Composition.CompositionContainer.GetExportedValues<IAdapterService>();
            foreach (var adapter in adapters)
            {
                bool isMock = false;
                if (typeof(IAdapterServiceNETCore).IsAssignableFrom(adapter.AdapterServiceType))
                {
                    services.AddSingleton(adapter.AdapterServiceType, adapter);
                }
                else
                {
                    isMock = true;
                    services.AddSingleton(adapter.AdapterServiceInterface, adapter);
                }
                _logger.LogInformation($"Adding adapter: {adapter.AdapterServiceName}");
                if (!isMock && typeof(IAsynchronousAdapterService).IsAssignableFrom(adapter.AdapterServiceInterface))
                {
                    var asyncProcessorType = typeof(IAsynchronousProcessor<>).MakeGenericType(adapter.GetType());
                    var genericMethod = typeof(CompositionContainer).GetMethod(nameof(CompositionContainer.GetExportedValue), new Type[] { }).MakeGenericMethod(asyncProcessorType);
                    var result = genericMethod.Invoke(Composition.CompositionContainer, new object[] { });
                    _logger.LogInformation($"Async processor added: {result}");
                }
            }
            services
                .AddMvc(
                    a =>
                    {
                        a.Conventions.Add(new AdapterServiceControllerModelConvention(_loggerFactory, services.BuildServiceProvider()));
                        a.EnableEndpointRouting = false;
                    }
                )
                .AddXmlSerializerFormatters()
                .ConfigureApplicationPartManager(
                    a => a.FeatureProviders.Add(new AdapterServiceControllerFeatureProvider(_loggerFactory))
                )
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            var healthChecks = services.AddHealthChecks();

            var adaptersHealthChecks = Composition.CompositionContainer.GetExportedValues<HealthInfo>();
            foreach (var adapterHealthCheck in adaptersHealthChecks)
            {
                healthChecks.AddCheck(
                    adapterHealthCheck.Key,
                    () =>
                    {
                        return new HealthCheckResult(HealthStatus.Healthy);
                    }
                );
            }
        }

        private void AddAdapterLogger(IServiceCollection services)
        {
            var logstashLogger = Composition.CompositionContainer.GetExportedValueOrDefault<IAdapterLogger>();
            if (logstashLogger != null)
            {
                _logger.LogInformation($"Adding composed logstash logger: {logstashLogger}");
                services.AddSingleton(typeof(IAdapterLogger), logstashLogger);
            }
            else
            {
                _logger.LogInformation($"Adding No Operation logstash adapter logger");
                services.AddSingleton(typeof(IAdapterLogger), new NOPAdapterLogger());
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime applicationLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHealthChecks("/hc");

            app.UseHealthChecks("/hc-details",
                new HealthCheckOptions()
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                }
            );

            app.UseHttpsRedirection();
            app.UseMvc();

            applicationLifetime.ApplicationStopping.Register(OnShutdown);
        }

        private void OnShutdown()
        {
            var adapters = Composition.CompositionContainer.GetExportedValues<IAdapterService>();
            foreach (var adapter in adapters)
            {
                bool isNotMock = typeof(IAdapterServiceNETCore).IsAssignableFrom(adapter.AdapterServiceType);

                if (isNotMock && typeof(IAsynchronousAdapterService).IsAssignableFrom(adapter.AdapterServiceInterface))
                {
                    var asyncProcessorType = typeof(IAsynchronousProcessor<>).MakeGenericType(adapter.GetType());
                    var genericMethod = typeof(CompositionContainer).GetMethod(nameof(CompositionContainer.GetExportedValue), new Type[] { }).MakeGenericMethod(asyncProcessorType);
                    var result = genericMethod.Invoke(Composition.CompositionContainer, new object[] { });
                    (result as IDisposable).Dispose();
                }
            }
        }
    }
}
