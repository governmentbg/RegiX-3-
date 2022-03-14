using System.Collections.Generic;
using TechnoLogica.API.Services.QueryValidators;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Services.QueryValidators
{
    public class ConsumerProfileQueryValidator : DefaultQueryValidator<ConsumerProfiles>
    {
        public override HashSet<string> GetAllowedProperties()
        {
            var allowedProperties = base.GetAllowedProperties();
            allowedProperties.Add("ConsumerProfile/ConsumerProfileId");
            return allowedProperties;
        }
    }
}