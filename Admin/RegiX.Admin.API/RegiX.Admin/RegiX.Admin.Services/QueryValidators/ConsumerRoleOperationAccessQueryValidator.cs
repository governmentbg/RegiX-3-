using System.Collections.Generic;
using TechnoLogica.API.Services.QueryValidators;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Services.QueryValidators
{
    public class ConsumerRoleOperationAccessQueryValidator : DefaultQueryValidator<ConsumerRoleOperationAccess>
    {
        public override HashSet<string> GetAllowedProperties()
        {
            var allowedProperties = base.GetAllowedProperties();
            allowedProperties.Add("ConsumerRole/Id");
            allowedProperties.Add("AdapterOperation/Description");
            allowedProperties.Add("AdapterOperation/RegisterAdapter/Register/Name");
            allowedProperties.Add("AdapterOperation/RegisterAdapter/Register/Administration/Name");
            allowedProperties.Add("AdapterOperation/RegisterAdapter/Description");
            return allowedProperties;
        }
    }
}