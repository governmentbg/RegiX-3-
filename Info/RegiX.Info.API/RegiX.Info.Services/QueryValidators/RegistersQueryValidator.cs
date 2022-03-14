using System.Collections.Generic;
using RegiX.Info.Infrastructure.Models;
using TechnoLogica.API.Services.QueryValidators;

namespace RegiX.Info.Services.QueryValidators
{
    public class RegistersQueryValidator : DefaultQueryValidator<Registers>
    {
        public override HashSet<string> GetAllowedProperties()
        {
            var allowedProperties = base.GetAllowedProperties();
            allowedProperties.Add("Administration/AdministrationId");
            allowedProperties.Add("Administration/Name");
            return allowedProperties;
        }
    }
}