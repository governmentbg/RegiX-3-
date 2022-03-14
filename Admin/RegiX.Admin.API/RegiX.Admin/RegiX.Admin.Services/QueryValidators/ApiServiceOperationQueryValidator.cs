﻿using System.Collections.Generic;
using TechnoLogica.API.Services.QueryValidators;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Services.QueryValidators
{
    public class ApiServiceOperationQueryValidator : DefaultQueryValidator<ApiServiceOperations>
    {
        public override HashSet<string> GetAllowedProperties()
        {
            var allowedProperties = base.GetAllowedProperties();
            allowedProperties.Add("ApiService/ApiServiceId");
            return allowedProperties;
        }
    }
}


