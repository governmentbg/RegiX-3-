using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RegiX.IdentityServer.ConsumerProfileCredentials.Context;
using System.ComponentModel.Composition;
using TechnoLogica.Authentication.Common;
using TechnoLogica.Mail;
using TechnoLogica.RegiX.Reporting;

namespace RegiX.IdentityServer.ConsumerProfileCredentials
{
    [Export(typeof(IAuthenticationProfile))]
    public class ConsumerProfileAuthenticationProfile : IAuthenticationProfile
    {
        public void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ConsumerProfilesContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ConsumerProfilesConnection")), 
                ServiceLifetime.Transient);

            services.AddTransient<IProfileClientService, ConsumerProfileService>();
            services.AddTransient<IProfileClientService, LocalConsumerProfileService>();
            services.AddTransient<IReportingService, ReportingService>();
            services.AddTransient<IMailService, MailService>();
        }
    }
}
