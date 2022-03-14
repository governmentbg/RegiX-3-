using System;
using System.Collections.Generic;
using System.Text;
using TechnoLogica.API.Services.QueryValidators;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Services.QueryValidators
{
    public class CertificateElementAccessQueryValidator : DefaultQueryValidator<CertificateElementAccess>
    {
        public override HashSet<string> GetAllowedProperties()
        {
            var allowedProperties = base.GetAllowedProperties();
            allowedProperties.Add("ConsumerCertificate/ConsumerCertificateId");
            allowedProperties.Add("RegisterObjectElement/RegisterObjectId");
            return allowedProperties;
        }
    }
}
