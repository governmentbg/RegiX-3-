using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TechnoLogica.API.Common;
using TechnoLogica.RegiX.AdapterConsole.AutoMapper;
using TechnoLogica.RegiX.AdapterConsole.Infrastructure.Models;
using TechnoLogica.RegiX.AdapterConsole.Repositories;
using TechnoLogica.RegiX.AdapterConsole.Repositories.Contracts;
using TechnoLogica.RegiX.AdapterConsole.Services.Contracts;

namespace TechnoLogica.RegiX.AdapterConsole.API
{
    public class Startup : BaseStartup<IUsersService, IUsersRepository>
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
            : base(configuration, env)
        {
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            services.AddDbContext<RegiXAdapterConsoleContext>(
                options => options.UseSqlServer(this.Configuration.GetConnectionString("RegiXAdapterConsoleDatabase"))
            );
            services.AddDbContext<DbContext>();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IUserContext>(
                s => new UserContext(s.GetService<IHttpContextAccessor>().HttpContext?.User)
            );
            new MappingConfigurationsHelper().ConfigureMapper();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory, IApiVersionDescriptionProvider provider)
        {
            base.Configure(app, env, loggerFactory, provider);
        }
    }
}
