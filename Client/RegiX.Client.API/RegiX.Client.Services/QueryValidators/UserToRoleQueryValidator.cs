using System.Collections.Generic;
using TechnoLogica.API.Services.QueryValidators;
using TechnoLogica.RegiX.Client.Infrastructure.Models;

namespace TechnoLogica.RegiX.Client.Services.QueryValidators
{
    public class UserToRoleQueryValidator : DefaultQueryValidator<UsersToRoles>
    {
        public override HashSet<string> GetAllowedProperties()
        {
            var allowedProperties = base.GetAllowedProperties();
            allowedProperties.Add("User/Id");
            allowedProperties.Add("Role/Id");
            allowedProperties.Add("User/FederationUsers/UserAuthority/Id");
            return allowedProperties;
        }
    }
}
