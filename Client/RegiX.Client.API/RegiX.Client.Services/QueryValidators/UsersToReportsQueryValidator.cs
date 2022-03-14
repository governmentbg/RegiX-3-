using System;
using System.Collections.Generic;
using System.Text;
using TechnoLogica.API.Services.QueryValidators;
using TechnoLogica.RegiX.Client.Infrastructure.Models;

namespace TechnoLogica.RegiX.Client.Services.QueryValidators
{
    public class UsersToReportsQueryValidator : DefaultQueryValidator<UsersToReports>
    {
        public override HashSet<string> GetAllowedProperties()
        {
            var allowedProperties = base.GetAllowedProperties();
            allowedProperties.Add("Report/Id");
            allowedProperties.Add("User/Id");
            allowedProperties.Add("User/FederationUsers/UserAuthority/Id");
            return allowedProperties;
        }
    }
}
