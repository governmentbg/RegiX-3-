using System.Collections.Generic;
using TechnoLogica.API.Services.QueryValidators;
using TechnoLogica.RegiX.Client.Infrastructure.Models;

namespace TechnoLogica.RegiX.Client.Services.QueryValidators
{
    public class ReportsQueryValidator : DefaultQueryValidator<Reports>
    {
        public override HashSet<string> GetAllowedProperties()
        {
            var allowedProperties = base.GetAllowedProperties();
            allowedProperties.Add("Authority/Id");
            allowedProperties.Add("Authority/Name");
            allowedProperties.Add("AdapterOperation/DisplayOperationName");
            return allowedProperties;
        }
    }
}
