using System;
using System.Collections.Generic;
using System.Text;
using TechnoLogica.API.Services.QueryValidators;
using TechnoLogica.RegiX.Client.Infrastructure.Models;

namespace TechnoLogica.RegiX.Client.Services.QueryValidators
{
    public class UsersQueryValidator : DefaultQueryValidator<Users>
    {
        public override HashSet<string> GetAllowedProperties()
        {
            var allowedProperties = base.GetAllowedProperties();
            allowedProperties.Add("FederationUsers/UserAuthority/DisplayName");
            allowedProperties.Add("FederationUsers/UserAuthority/Id");
            allowedProperties.Add("FederationUsers/Position");
            return allowedProperties;
        }
    }
}
