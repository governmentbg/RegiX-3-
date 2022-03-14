using System;
using System.Collections.Generic;
using System.Text;
using RegiX.Info.Infrastructure.Models;
using TechnoLogica.API.Services.QueryValidators;

namespace RegiX.Info.Services.QueryValidators
{
    public class AdapterOperationQueryValidator : DefaultQueryValidator<AdapterOperations>
    {
        public override HashSet<string> GetAllowedProperties()
        {
            var allowedProperties = base.GetAllowedProperties();
            allowedProperties.Add("RegisterAdapter/RegisterAdapterId");
            return allowedProperties;
        }
    }
}
