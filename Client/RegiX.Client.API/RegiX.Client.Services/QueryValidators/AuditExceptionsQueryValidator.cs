using System.Collections.Generic;
using TechnoLogica.API.Services.QueryValidators;
using TechnoLogica.RegiX.Client.Infrastructure.Models;

namespace TechnoLogica.RegiX.Client.Services.QueryValidators
{
    public class AuditExceptionsQueryValidator : DefaultQueryValidator<AuditExceptions>
    {
        public override HashSet<string> GetAllowedProperties()
        {
            var allowedProperties = base.GetAllowedProperties();
            allowedProperties.Add("Authority/Name");
            return allowedProperties;
        }
    }
}