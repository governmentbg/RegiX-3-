using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RegiX.IdentityServer;
using System.ComponentModel.Composition;
using TechnoLogica.Authentication.Common;
using TechnoLogica.Mail;

namespace TechnoLogica.RegiX.IdentityServer.AdminAppCredentials
{
    [Export(typeof(IAuthenticationProfile))]
    public class AdminAuthenticationProfile : IAuthenticationProfile
    {
        public void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RegiXAdminContext>(options =>
                 options.UseSqlServer(configuration.GetConnectionString("RegiXAdminConnection")));

            services.AddTransient<IProfileClientService, AdminProfileService>();
            services.AddTransient<IProfileClientService, LocalAdminProfileService>();
            services.AddTransient<IProfileClientService, LocalShortAdminProfileService>();
            services.AddTransient<IMailService, MailService>();
        }
    }
}
