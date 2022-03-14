using System;
using System.Collections.Generic;
using System.Text;
using TechnoLogica.API.Services.QueryValidators;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Services.QueryValidators
{
    public class ConsumerCertificateQueryValidator : DefaultQueryValidator<ConsumerCertificates>
    {
        public override HashSet<string> GetAllowedProperties()
        {
            var allowedProperties = base.GetAllowedProperties();
            allowedProperties.Add("ApiServiceConsumer/ApiServiceConsumerId");            
            return allowedProperties;
        }
    }
}
