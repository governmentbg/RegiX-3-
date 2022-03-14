using RegiX.Info.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;
using TechnoLogica.API.Services.QueryValidators;

namespace RegiX.Info.Services.QueryValidators
{
    class RegisterObjectElementQueryValidator : DefaultQueryValidator<RegisterObjectElements>
    {
        public override HashSet<string> GetAllowedProperties()
        {
            var allowedProperties = base.GetAllowedProperties();
            allowedProperties.Add("RegisterObject/RegisterObjectId");
            return allowedProperties;
        }
    }
}
