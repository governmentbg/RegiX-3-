using System;
using System.Collections.Generic;
using System.Text;
using TechnoLogica.API.Services.QueryValidators;
using TechnoLogica.RegiX.Client.Infrastructure.Models;

namespace TechnoLogica.RegiX.Client.Services.QueryValidators
{
    public class RegistryQueryValidator : DefaultQueryValidator<Registers>
    {
        public override HashSet<string> GetAllowedProperties()
        {
            var allowedProperties = base.GetAllowedProperties();
            allowedProperties.Add("Authority/Id");
            return allowedProperties;
        }
    }
}
