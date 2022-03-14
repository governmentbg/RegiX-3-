using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RegiX.IdentityServer.RegiXClientUsers;
using System.ComponentModel.Composition;
using TechnoLogica.Authentication.Common;
using TechnoLogica.Mail;

namespace TechnoLogica.RegiX.IdentityServer.ClientAppCredentials
{
    [Export(typeof(IAuthenticationProfile))]
    public class ClientAuthenticationProfile : IAuthenticationProfile
    {
        public void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RegiXClientContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("RegiXClientConnection")));

            services.AddDbContext<RegiXClientCitizensContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("RegiXClientCitizensConnection")));

            services.AddTransient<IProfileClientService, ClientProfileService>();
            services.AddTransient<IProfileClientService, CitizensClientProfileService>();            
            services.AddTransient<IProfileClientService, LocalClientProfileService>(); 
            services.AddTransient<IMailService, MailService>();
        }
    }
}
