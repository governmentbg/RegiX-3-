using RegiX.Info.Infrastructure.Models;
using System.Collections.Generic;
using TechnoLogica.API.Services.QueryValidators;

namespace RegiX.Info.Services.QueryValidators
{
    public class ConsumerRequestsQueryValidator : DefaultQueryValidator<ConsumerRequests>
    {
        public override HashSet<string> GetAllowedProperties()
        {
            var allowedProperties = base.GetAllowedProperties();
            allowedProperties.Add("ConsumerSystem/ConsumerSystemId");
            return allowedProperties;
        }
    }
}
