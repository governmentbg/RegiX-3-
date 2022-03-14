using System.Collections.Generic;
using TechnoLogica.API.Services.QueryValidators;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Services.QueryValidators
{
    public class ConsumerAccessRequestsQueryValidator : DefaultQueryValidator<ConsumerAccessRequests>
    {
        public override HashSet<string> GetAllowedProperties()
        {
            var allowedProperties = base.GetAllowedProperties();
            allowedProperties.Add("ConsumerSystemCertificate/ConsumerSystemCertificateId");
            allowedProperties.Add("ConsumerRequest/ConsumerRequestId");
            return allowedProperties;
        }
    }
}