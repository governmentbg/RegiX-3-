using MetaDataService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using RegiX.Info.API.Services;
using RegiX.Info.AutoMapper;
using RegiX.Info.Infrastructure.Models;
using RegiX.Info.Repositories;
using RegiX.Info.Repositories.Contracts;
using RegiX.Info.Services.Contracts;
using RegiX.Info.Services.Helpers;
using System.IO;
using System.Reflection;
using TechnoLogica.API.Common;
using TechnoLogica.API.Common.Attributes;
using TechnoLogica.Mail;
using TechnoLogica.SQLDataProtectionKeyStoreProvider;

namespace RegiX.Info.API
{
    public interface IStartup
    {
    }

    // CustomFilterAttribute as IRepository argument is a workaround preventing multiple registration of instances
    public class Startup : BaseStartup<IConsumerProfileService, IConsumerProfileRepository>
    {
        private ILogger<Startup> Logger { get; set; }

        public Startup(ILogger<Startup> logger, IConfiguration configuration, IWebHostEnvironment env) : base(configuration, env)
        {
            Logger = logger;
        }

        public override Assembly[] CompositionAssemblies =>
            new Assembly[]
            {
                typeof(SQLStoreProvider).Assembly,
                typeof(IMailService).Assembly
            };

        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            services.AddDbContext<RegiXContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("RegiXDatabase"))
            );

            services.AddSingleton<DownloadAdaptersInfoService>();
            // Services are automatically registered from the base class functionality
            services.AddHostedService<AdapterInformationService>();
            services.AddTransient<IAdapterInformationLoader, AdapterInformationLoader>();
            services.AddTransient<IRegiXMetaDataService, RegiXMetaDataServiceClient> ();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IConsumerContext>(
                s => new ConsumerContext(s.GetService<IHttpContextAccessor>().HttpContext.User)
            );
            services.AddDistributedSqlServerCache(options =>
            {
                options.ConnectionString = Configuration.GetConnectionString("DistributedCache");
                options.SchemaName = "dbo";
                options.TableName = "DistributedCache";
            });
            services.AddTransient<IMailService, MailService>();
            services.Configure<ReportSettings>(Configuration.GetSection("ReportSettings"));

            new MappingConfigurationsHelper().ConfigureMapper();
        }

        public override void Configure(
            IApplicationBuilder app, 
            IWebHostEnvironment env, 
            ILoggerFactory loggerFactory,
            IApiVersionDescriptionProvider provider)
        {
            
            app.UseStaticFiles();
            app.UseFileServer(new FileServerOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(env.ContentRootPath, "marked")),
                RequestPath = "/api/marked",
                EnableDirectoryBrowsing = false
            });
            base.Configure(app, env, loggerFactory, provider);
        }
    }
}