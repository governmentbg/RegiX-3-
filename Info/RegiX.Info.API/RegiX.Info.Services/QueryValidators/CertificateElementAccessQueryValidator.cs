using System.Collections.Generic;
using RegiX.Info.Infrastructure.Models;
using TechnoLogica.API.Services.QueryValidators;

namespace RegiX.Info.Services.QueryValidators
{
    public class CertificateElementAccessQueryValidator : DefaultQueryValidator<CertificateElementAccess>
    {
        public override HashSet<string> GetAllowedProperties()
        {
            var allowedProperties = base.GetAllowedProperties();
            allowedProperties.Add("ConsumerCertificate/ConsumerCertificateId");
            return allowedProperties;
        }
    }
}