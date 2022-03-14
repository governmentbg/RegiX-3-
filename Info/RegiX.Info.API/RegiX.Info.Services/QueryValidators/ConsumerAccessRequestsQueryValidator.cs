using RegiX.Info.Infrastructure.Models;
using System.Collections.Generic;
using TechnoLogica.API.Services.QueryValidators;

namespace RegiX.Info.Services.QueryValidators
{
    public class ConsumerAccessRequestsQueryValidator : DefaultQueryValidator<ConsumerAccessRequests>
    {
        public override HashSet<string> GetAllowedProperties()
        {
            var allowedProperties = base.GetAllowedProperties();
            allowedProperties.Add("ConsumerRequest/Name");
            allowedProperties.Add("AdapterOperation/Description");
            allowedProperties.Add("ConsumerSystemCertificate/ConsumerSystemCertificateId");
            allowedProperties.Add("ConsumerRequest/Id");            
            return allowedProperties;
        }
    }
}
