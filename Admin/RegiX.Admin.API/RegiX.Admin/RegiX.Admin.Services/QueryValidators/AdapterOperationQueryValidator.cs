using System;
using System.Collections.Generic;
using System.Text;
using TechnoLogica.API.Services.QueryValidators;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Services.QueryValidators
{
    public class AdapterOperationQueryValidator : DefaultQueryValidator<AdapterOperations>
    {
        public override HashSet<string> GetAllowedProperties()
        {
            var allowedProperties = base.GetAllowedProperties();
            allowedProperties.Add("RegisterAdapter/RegisterAdapterId");
            allowedProperties.Add("RegisterAdapter/Name");
            return allowedProperties;
        }
    }
}
