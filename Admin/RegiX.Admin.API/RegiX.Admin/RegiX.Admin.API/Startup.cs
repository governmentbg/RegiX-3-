using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Reflection;
using TechnoLogica.API.Common;
using TechnoLogica.Common.DataProtection;
using TechnoLogica.Mail;
using TechnoLogica.RegiX.Admin.API.RegiXInfo;
using TechnoLogica.RegiX.Admin.Infrastructure;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.IoC.Configuration.AutoMapper;
using TechnoLogica.RegiX.Admin.Repositories;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;
using TechnoLogica.RegiX.Admin.Repositories.Contracts.DatabaseOperationsRepositoriesInterfaces;
using TechnoLogica.RegiX.Admin.Repositories.Impl;
using TechnoLogica.RegiX.Admin.Repositories.Impl.DatabaseOperationsRepositories;
using TechnoLogica.RegiX.Admin.Services.Contracts;
using TechnoLogica.RegiX.Admin.Services.Contracts.DatabaseOperationsServicesInterfaces;
using TechnoLogica.RegiX.Admin.Services.Services.DatabaseOperationService;
using TechnoLogica.SQLDataProtectionKeyStoreProvider;

namespace TechnoLogica.RegiX.Admin.API
{
    public class Startup : BaseStartup<IAdministrationService, IAdministrationsRepository>
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env) : base(configuration, env)
        {
        }

        public override Assembly[] CompositionAssemblies => 
            new Assembly[]
            { 
                typeof(SQLStoreProvider).Assembly,
                typeof(IMailService).Assembly
            };

        // This method gets called by the runtime. Use this method to add services to the container.
        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IUserContext>(
                s => new UserContext(s.GetService<IHttpContextAccessor>().HttpContext.User)
            );
            services.AddDbContext<RegiXContext>(
                options => options.UseSqlServer(
                    Configuration.GetConnectionString("RegiXDatabase"),
                    sqlServerOptions => sqlServerOptions.CommandTimeout(90))
            );
            services.AddTransient<IMailService, MailService>();
            services.AddTransient<IInfoAPIClient, InfoAPIClient>();
            services.AddTransient<IDatabaseOperationRepository, DatabaseOperationRepository>();
            services.AddTransient<IDatabaseOperationService, DatabaseOperationService>();

            new MappingConfigurationsHelper().ConfigureMapper();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory, IApiVersionDescriptionProvider provider)
        {
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
