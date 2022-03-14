using AuthServer.Infrastructure.Data.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.Composition;
using TechnoLogica.Authentication.Common;

namespace RegiX.IdentityServer.AdapterConsoleAppCredentials.Services
{
    [Export(typeof(IAuthenticationProfile))]
    public class IdentityClaimsAuthenticationProfile : IAuthenticationProfile
    {
        public void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("RegiXAdapterConsoleConnection")));

            services.AddTransient<IProfileClientService, IdentityClaimsProfileService>();
            services.AddTransient<IProfileClientService, LocalIdentityClaimsProfileService>();
        }
    }
}
