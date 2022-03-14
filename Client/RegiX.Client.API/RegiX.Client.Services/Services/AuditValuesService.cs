using System.Collections.Generic;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.AuditValues;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Repositories.Contracts;
using TechnoLogica.RegiX.Client.Services.Contracts;

namespace TechnoLogica.RegiX.Client.Services.Services
{
    public class AuditValuesService : ABaseService<AuditValuesInDto, AuditValuesOutDto, AuditValues, int,RegiXClientContext>,
        IAuditValuesService
    {
        public AuditValuesService(IAuditValuesRepository aBaseRepository) 
            : base(aBaseRepository)
        {
        }

        protected override void PopulateDtoToEntityFieldsMapping()
        {
            dtoFieldsToEntityFields.Add("auditTable.id", "AuditTable/Id");
            dtoFieldsToEntityFields.Add("auditTable.displayName", "AuditTable/TableName");
        }

        protected override bool IsChildRecord(int aId, List<string> aParentsList)
        {
            throw new System.NotImplementedException();
        }
    }
}