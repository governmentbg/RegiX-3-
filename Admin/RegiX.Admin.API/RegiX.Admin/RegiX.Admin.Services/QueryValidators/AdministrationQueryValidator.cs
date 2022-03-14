using System;
using System.Collections.Generic;
using System.Text;
using TechnoLogica.API.Services.QueryValidators;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Services.QueryValidators
{
    public class AdministrationQueryValidator : DefaultQueryValidator<Administrations>
    {
        public override HashSet<string> GetAllowedProperties()
        {
            var allowedProperties = base.GetAllowedProperties();
            allowedProperties.Add("Administration/AdministrationId");
            allowedProperties.Add("AdministrationType/Name");
            return allowedProperties;
        }
    }
}
