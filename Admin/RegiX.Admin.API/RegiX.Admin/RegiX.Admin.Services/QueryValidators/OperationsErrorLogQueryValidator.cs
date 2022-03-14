using System.Collections.Generic;
using TechnoLogica.API.Services.QueryValidators;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Services.QueryValidators
{
    public class OperationsErrorLogQueryValidator : DefaultQueryValidator<OperationsErrorLog>
    {
        public override HashSet<string> GetAllowedProperties()
        {
            var allowedProperties = base.GetAllowedProperties();
            allowedProperties.Add("ApiServiceCall/ApiServiceOperation/ApiService/Name");
            allowedProperties.Add("AdapterOperation/Name");
            allowedProperties.Add("ApiServiceCall/ConsumerCertificate/Name");
            allowedProperties.Add("ApiServiceCall/ConsumerCertificate/ApiServiceConsumer/Name");
            allowedProperties.Add("ApiServiceCall/ConsumerCertificate/ApiServiceConsumer/Administration/Name");

            return allowedProperties;
        }
    }
}