using System.Collections.Generic;
using TechnoLogica.API.Services.QueryValidators;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Services.QueryValidators
{
    public class CertificateConsumerRoleQueryValidator : DefaultQueryValidator<CertificateConsumerRole>
    {
        public override HashSet<string> GetAllowedProperties()
        {
            var allowedProperties = base.GetAllowedProperties();
            allowedProperties.Add("ConsumerCertificate/ConsumerCertificateId");
            return allowedProperties;
        }
    }
}