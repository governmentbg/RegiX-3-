using System;
using System.Collections.Generic;
using System.Text;
using TechnoLogica.API.Services.QueryValidators;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Services.QueryValidators
{
    public class CertificateOperationAccessQueryValidator : DefaultQueryValidator<CertificateOperationAccess>
    {
        public override HashSet<string> GetAllowedProperties()
        {
            var allowedProperties = base.GetAllowedProperties();
            allowedProperties.Add("ConsumerCertificate/ConsumerCertificateId");
            allowedProperties.Add("AdapterOperation/RegisterObjectId");
            allowedProperties.Add("AdapterOperation/Name");
            allowedProperties.Add("AdapterOperation/Description");
            return allowedProperties;
        }
    }
}
