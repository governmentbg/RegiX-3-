using System.Collections.Generic;
using Microsoft.AspNet.OData.Query.Validators;
using TechnoLogica.API.Repositories.Contracts;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.CertificateConsumerRole;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Services.Contracts;
using TechnoLogica.RegiX.Admin.Services.QueryValidators;

namespace TechnoLogica.RegiX.Admin.Services.Services
{
    public class CertificateConsumerRoleService : ABaseService<CertificateConsumerRoleInDto, CertificateConsumerRoleOutDto, CertificateConsumerRole, decimal, RegiXContext>,
        ICertificateConsumerRoleService
    {
        public CertificateConsumerRoleService(IBaseRepository<CertificateConsumerRole, decimal, RegiXContext> aBaseRepository) 
            : base(aBaseRepository, new CertificateConsumerRoleQueryValidator())
        {
        }

        protected override void PopulateDtoToEntityFieldsMapping()
        {
            dtoFieldsToEntityFields.Add("consumerRole.id", "ConsumerRole/Id");
            dtoFieldsToEntityFields.Add("consumerRole.displayName", "ConsumerRole/Name");
            dtoFieldsToEntityFields.Add("consumerCertificate.id", "ConsumerCertificate/ConsumerCertificateId");
            dtoFieldsToEntityFields.Add("consumerCertificate.displayName", "ConsumerCertificate/Name");
        }

        protected override bool IsChildRecord(decimal aId, List<string> aParentsList)
        {
            return false;
        }
    }
}