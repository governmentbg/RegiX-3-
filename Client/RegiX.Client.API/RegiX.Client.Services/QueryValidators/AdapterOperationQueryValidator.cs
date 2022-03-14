using System.Collections.Generic;
using TechnoLogica.API.Services.QueryValidators;
using TechnoLogica.RegiX.Client.Infrastructure.Models;

namespace TechnoLogica.RegiX.Client.Services.QueryValidators
{
    public class AdapterOperationQueryValidator : DefaultQueryValidator<AdapterOperations>
    {
        public override HashSet<string> GetAllowedProperties()
        {
            var allowedProperties = base.GetAllowedProperties();
            allowedProperties.Add("Register/Id");
            return allowedProperties;
        }
    }
}
