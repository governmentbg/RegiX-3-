using RegiX.Info.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;
using TechnoLogica.API.Services.QueryValidators;

namespace RegiX.Info.Services.QueryValidators
{
    public class ConsumerRequestOperationsQueryValidator : DefaultQueryValidator<ConsumerRequestOperations>
    {
        public override HashSet<string> GetAllowedProperties()
        {
            var allowedProperties = base.GetAllowedProperties();
            allowedProperties.Add("ConsumerAccessRequest/ConsumerAccessRequestId");
            return allowedProperties;
        }
    }
}
