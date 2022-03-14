using System.Collections.Generic;
using TechnoLogica.API.Services.QueryValidators;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.API.Controllers.V1.DatabaseOperationsControllers
{
    public class ConsumerSystemCertificatesQueryValidator : DefaultQueryValidator<ConsumerSystemCertificates>
    {
        public override HashSet<string> GetAllowedProperties()
        {
            var allowedProperties = base.GetAllowedProperties();
            allowedProperties.Add("ConsumerSystem/ConsumerSystemId");
            return allowedProperties;
        }
    }
}