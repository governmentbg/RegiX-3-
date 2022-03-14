using System.Collections.Generic;
using TechnoLogica.API.Services.QueryValidators;
using TechnoLogica.RegiX.Client.Infrastructure.Models;

namespace TechnoLogica.RegiX.Client.Services.QueryValidators
{
    public class RolesToReportsQueryValidator : DefaultQueryValidator<RolesToReports>
    {
        public override HashSet<string> GetAllowedProperties()
        {
            var allowedProperties = base.GetAllowedProperties();
            allowedProperties.Add("Report/Id");
            allowedProperties.Add("Role/Id");
            allowedProperties.Add("Report/AuthorityId");
            return allowedProperties;
        }
    }
}
