using System.Collections.Generic;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.RoleToReport;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Repositories.Contracts;
using TechnoLogica.RegiX.Client.Services.Contracts;
using TechnoLogica.RegiX.Client.Services.QueryValidators;

namespace TechnoLogica.RegiX.Client.Services.Services
{
    public class RoleToReportService : ABaseService<RoleToReportInDto, RoleToReportOutDto, RolesToReports, int,RegiXClientContext>,
        IRoleToReportService
    {

        public RoleToReportService(IRolesToReportsRepository aBaseRepository) 
            : base(aBaseRepository)
        {
            queryValidator = new RolesToReportsQueryValidator();
        }
        protected override void PopulateDtoToEntityFieldsMapping()
        {
            dtoFieldsToEntityFields.Add("role.id", "Role/Id");
            dtoFieldsToEntityFields.Add("role.displayName", "Role/Name");
            dtoFieldsToEntityFields.Add("report.id", "Report/Id");
            dtoFieldsToEntityFields.Add("report.displayName", "Report/Name");
            dtoFieldsToEntityFields.Add("report.authorityId", "Report/AuthorityId");
        }

        protected override bool IsChildRecord(int aId, List<string> aParentsList)
        {
            throw new System.NotImplementedException();
        }
    }
}