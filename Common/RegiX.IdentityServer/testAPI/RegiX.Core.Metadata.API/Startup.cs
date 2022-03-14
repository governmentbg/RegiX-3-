using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace RegiX.Core.Metadata.API
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options
                    .AddPolicy(
                        "CORSPolicy",
                        builder =>
                        {
                            builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
                        }
                    );
            });
            services
                .AddMvc();
            ConfigureAuthorization(services);
        }

        private void ConfigureAuthorization(IServiceCollection services)
        {
            services
                .AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = "https://regix2-adapters.regix.tlogica.com:8091/regix.identityserver";
                    options.ApiName = "regixcoremetadataapi";
                    options.ApiSecret = "###";
                    options.EnableCaching = false;// Do not cache credentials - always rely on identity server
                });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseCors("CORSPolicy");
            app.UseMvc();
        }
    }
}
