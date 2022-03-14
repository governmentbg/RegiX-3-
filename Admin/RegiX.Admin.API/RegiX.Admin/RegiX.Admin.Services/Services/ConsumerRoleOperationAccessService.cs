using System.Collections.Generic;
using TechnoLogica.API.Repositories.Contracts;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerRoleOperationAccess;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Services.Contracts;
using TechnoLogica.RegiX.Admin.Services.QueryValidators;

namespace TechnoLogica.RegiX.Admin.Services.Services
{
    public class ConsumerRoleOperationAccessService :
        ABaseService<ConsumerRoleOperationAccessInDto, ConsumerRoleOperationAccessOutDto, ConsumerRoleOperationAccess,
            decimal, RegiXContext>, IConsumerRoleOperationAccessService
    {
        public ConsumerRoleOperationAccessService(IBaseRepository<ConsumerRoleOperationAccess, decimal, RegiXContext> aBaseRepository) : base(aBaseRepository, new ConsumerRoleOperationAccessQueryValidator())
        {
        }

        protected override void PopulateDtoToEntityFieldsMapping()
        {
            dtoFieldsToEntityFields.Add("consumerRole.id", "ConsumerRole/Id");
            dtoFieldsToEntityFields.Add("consumerRole.displayName", "ConsumerRole/Name");
            dtoFieldsToEntityFields.Add("adapterOperation.id", "AdapterOperation/AdapterOperationId");
            dtoFieldsToEntityFields.Add("adapterOperation.displayName", "AdapterOperation/Name");
            dtoFieldsToEntityFields.Add("adapterOperationDisplayName", "AdapterOperation/Description");
            dtoFieldsToEntityFields.Add("registerDisplayName", "AdapterOperation/RegisterAdapter/Register/Name");
            dtoFieldsToEntityFields.Add("administrationDisplayName", "AdapterOperation/RegisterAdapter/Register/Administration/Name");
            dtoFieldsToEntityFields.Add("adapterDisplayName", "AdapterOperation/RegisterAdapter/Description");
        }

        protected override bool IsChildRecord(decimal aId, List<string> aParentsList)
        {
            return false;
        }
    }
}