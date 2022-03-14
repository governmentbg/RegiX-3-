using System.Collections.Generic;
using TechnoLogica.API.Services.QueryValidators;
using TechnoLogica.RegiX.AdapterConsole.Infrastructure.Models;

namespace TechnoLogica.RegiX.AdapterConsole.Services.QueryValidators
{
    public class OperationsToRoleQueryValidator : DefaultQueryValidator<OperationsToRoles>
    {
        public override HashSet<string> GetAllowedProperties()
        {
            var allowedProperties = base.GetAllowedProperties();
            allowedProperties.Add("Role/Id");
            return allowedProperties;
        }
    }
}