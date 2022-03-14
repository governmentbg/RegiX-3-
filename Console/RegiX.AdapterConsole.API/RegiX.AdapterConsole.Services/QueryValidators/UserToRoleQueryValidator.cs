using System.Collections.Generic;
using TechnoLogica.API.Services.QueryValidators;
using TechnoLogica.RegiX.AdapterConsole.Infrastructure.Models;

namespace TechnoLogica.RegiX.AdapterConsole.Services.QueryValidators
{
    public class UserToRoleQueryValidator : DefaultQueryValidator<AspNetUserRoles>
    {
        public override HashSet<string> GetAllowedProperties()
        {
            var allowedProperties = base.GetAllowedProperties();
            allowedProperties.Add("User/Id");
            return allowedProperties;
        }
    }
}