using System.Collections.Generic;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.AuditSystemReportExecutions;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Repositories.Contracts;
using TechnoLogica.RegiX.Client.Services.Contracts;

namespace TechnoLogica.RegiX.Client.Services.Services
{
    public class AuditSystemReportExecutionsService :
        ABaseService<AuditSystemReportExecutionsInDto, AuditSystemReportExecutionsOutDto, AuditSystemReportExecutions,
            int,RegiXClientContext>, IAuditSystemReportExecutionsService
    {
        public AuditSystemReportExecutionsService(IAuditSystemReportExecutionsRepository aBaseRepository) : base(aBaseRepository)
        {
        }

        protected override void PopulateDtoToEntityFieldsMapping()
        {
            dtoFieldsToEntityFields.Add("adapterOperation.id", "AdapterOperation/Id");
            dtoFieldsToEntityFields.Add("adapterOperation.displayName", "AdapterOperation/DisplayOperationName");
        }

        protected override bool IsChildRecord(int aId, List<string> aParentsList)
        {
            throw new System.NotImplementedException();
        }

       
    }
}