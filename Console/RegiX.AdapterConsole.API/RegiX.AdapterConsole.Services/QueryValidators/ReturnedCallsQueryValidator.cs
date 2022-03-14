using System.Collections.Generic;
using TechnoLogica.API.Services.QueryValidators;
using TechnoLogica.RegiX.AdapterConsole.Infrastructure.Models;

namespace TechnoLogica.RegiX.AdapterConsole.Services.QueryValidators
{
    public class ReturnedCallsQueryValidator : DefaultQueryValidator<ReturnedCalls>
    {
        public override HashSet<string> GetAllowedProperties()
        {
            var allowedProperties = base.GetAllowedProperties();
            allowedProperties.Add("AdapterOperation/Description");
            allowedProperties.Add("ReturnedByNavigation/Name");
            return allowedProperties;
        }
    }
}