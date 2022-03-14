using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using SoapCore;
using System.IO;
using System.ServiceModel;
using TechnoLogica.API.Common;
using TechnoLogica.HybridCache;
using TechnoLogica.RegiX.Client.API.CoreCallback;
using TechnoLogica.RegiX.Client.AutoMapper.AutoMapper;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Repositories;
using TechnoLogica.RegiX.Client.Repositories.Contracts;
using TechnoLogica.RegiX.Client.Repositories.Contracts.DatabaseOperations;
using TechnoLogica.RegiX.Client.Repositories.Impl.DatabaseOperations;
using TechnoLogica.RegiX.Client.Services.Contracts;
using TechnoLogica.RegiX.Client.Services.Services;

namespace TechnoLogica.RegiX.Client.API
{
    public class Startup : BaseStartup<IAuthoritiesService, IAuthoritiesRepository>
    {
        RegiXClientSettings regiXClientSettings = null;

        public Startup(IConfiguration configuration, IWebHostEnvironment env) 
            : base(configuration, env)
        {
            this.regiXClientSettings = configuration.GetSettings<RegiXClientSettings>();
            RegiXCoreClient.ENDPOINT_ADDRESS = regiXClientSettings?.RegiXCoreURL;
            MetadataSyncService.REGIX_INFO_URL = regiXClientSettings?.RegiXInfoURL;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IUserContext>(
                s => new UserContext(s.GetService<IHttpContextAccessor>().HttpContext?.User)
            );
            services.AddDbContext<RegiXClientContext>( 
                options => options.UseSqlServer(this.Configuration.GetConnectionString("RegiXClientDatabase"))
            );

            services.AddTransient<IClearFavouriteReportsRepository, ClearFavouriteReportsRepository>();
            services.AddTransient( s => this.regiXClientSettings);
            new MappingConfigurationsHelper().ConfigureMapper();

            services.AddDistributedSqlServerCache(options =>
            {
                options.ConnectionString = Configuration.GetConnectionString("DistributedCache");
                options.SchemaName = "dbo";
                options.TableName = "DistributedCache";
            });
            services.AddTransient<IHybridCache, HybridCache.HybridCache>();

            // Add CoreCallback service
            services.AddSoapCore();
            services.TryAddSingleton<CallbackService>();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory, IApiVersionDescriptionProvider provider)
        {
            var binding = 
                new BasicHttpBinding() { 
                    MaxReceivedMessageSize = regiXClientSettings.CallBackService.MaxReceivedMessageSize, 
                    MaxBufferSize = regiXClientSettings.CallBackService.MaxBufferSize
                };
            binding.ReaderQuotas.MaxDepth = regiXClientSettings.CallBackService.MaxDepth;
            binding.ReaderQuotas.MaxStringContentLength = regiXClientSettings.CallBackService.MaxStringContentLength;
            binding.ReaderQuotas.MaxArrayLength = regiXClientSettings.CallBackService.MaxArrayLength;
            binding.ReaderQuotas.MaxBytesPerRead = regiXClientSettings.CallBackService.MaxBytesPerRead;
            binding.ReaderQuotas.MaxNameTableCharCount = regiXClientSettings.CallBackService.MaxNameTableCharCount;

            app.UseSoapEndpoint<CallbackService>("/CallbackService.svc", binding, SoapSerializer.XmlSerializer);
            base.Configure(app, env, loggerFactory, provider);
            app.UseStaticFiles();
            app.UseFileServer(new FileServerOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(env.ContentRootPath, "marked")),
                RequestPath = "/api/marked",
                EnableDirectoryBrowsing = false
            });
        }
    }
}
