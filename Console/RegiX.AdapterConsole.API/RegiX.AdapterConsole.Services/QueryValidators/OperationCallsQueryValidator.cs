using System.Collections.Generic;
using TechnoLogica.API.Services.QueryValidators;
using TechnoLogica.RegiX.AdapterConsole.Infrastructure.Models;

namespace TechnoLogica.RegiX.AdapterConsole.Services.QueryValidators
{
    public class OperationCallsQueryValidator : DefaultQueryValidator<OperationCalls>
    {
        public override HashSet<string> GetAllowedProperties()
        {
            var allowedProperties = base.GetAllowedProperties();
            allowedProperties.Add("AdapterOperation/Description");
            allowedProperties.Add("AssignedToNavigation/Name");
            return allowedProperties;
        }
    }
}