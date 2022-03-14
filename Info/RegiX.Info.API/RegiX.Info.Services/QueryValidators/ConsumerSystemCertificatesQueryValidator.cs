using System.Collections.Generic;
using RegiX.Info.Infrastructure.Models;
using TechnoLogica.API.Services.QueryValidators;

namespace RegiX.Info.Services.QueryValidators
{
    public class ConsumerSystemCertificatesQueryValidator : DefaultQueryValidator<ConsumerSystemCertificates>
    {
        public override HashSet<string> GetAllowedProperties()
        {
            var allowedProperties = base.GetAllowedProperties();
            allowedProperties.Add("ConsumerSystem/ConsumerSystemId");
            return allowedProperties;
        }
    }
}
