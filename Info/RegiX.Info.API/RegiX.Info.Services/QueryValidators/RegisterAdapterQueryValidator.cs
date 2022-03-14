using System.Collections.Generic;
using RegiX.Info.Infrastructure.Models;
using TechnoLogica.API.Services.QueryValidators;

namespace RegiX.Info.Services.QueryValidators
{
    public class RegisterAdapterQueryValidator : DefaultQueryValidator<RegisterAdapters>
    {
        public override HashSet<string> GetAllowedProperties()
        {
            var allowedProperties = base.GetAllowedProperties();
            allowedProperties.Add("Register/RegisterId");
            return allowedProperties;
        }
    }
}