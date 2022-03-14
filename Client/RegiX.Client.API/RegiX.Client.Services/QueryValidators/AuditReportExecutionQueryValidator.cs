using System;
using System.Collections.Generic;
using System.Text;
using TechnoLogica.API.Services.QueryValidators;
using TechnoLogica.RegiX.Client.Infrastructure.Models;

namespace TechnoLogica.RegiX.Client.Services.QueryValidators
{
    public class AuditReportExecutionQueryValidator : DefaultQueryValidator<AuditReportExecutions>
    {
        public override HashSet<string> GetAllowedProperties()
        {
            var allowedProperties = base.GetAllowedProperties();
            allowedProperties.Add("Report/Name");
            allowedProperties.Add("User/UserName");
            allowedProperties.Add("Authority/Name");
            return allowedProperties;
        }
    }
}
