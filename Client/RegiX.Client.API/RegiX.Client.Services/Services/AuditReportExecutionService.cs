using System.Collections.Generic;
using Microsoft.AspNet.OData.Query.Validators;
using TechnoLogica.API.Repositories.Contracts;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.AuditReportExecution;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Repositories;
using TechnoLogica.RegiX.Client.Repositories.Contracts;
using TechnoLogica.RegiX.Client.Services.Contracts;
using TechnoLogica.RegiX.Client.Services.QueryValidators;

namespace TechnoLogica.RegiX.Client.Services.Services
{
    public class AuditReportExecutionService :
        ABaseService<AuditReportExecutionInDto, AuditReportExecutionOutDto, AuditReportExecutions, int,RegiXClientContext>,
        IAuditReportExecutionService
    {
        private IUserContext UserContext { get; set; }
        public AuditReportExecutionService(
            IAuditReportExecutionsRepository aBaseRepository,
            IUserContext userContext)
            : base(aBaseRepository)
        {
            UserContext = userContext;
            queryValidator = new AuditReportExecutionQueryValidator();
        }

        protected override void PopulateDtoToEntityFieldsMapping()
        {
            dtoFieldsToEntityFields.Add("report.id", "Report/Id");
            dtoFieldsToEntityFields.Add("report.displayName", "Report/Name");
            dtoFieldsToEntityFields.Add("authority.id", "Authority/Id");
            dtoFieldsToEntityFields.Add("authority.displayName", "Authority/Name");
            dtoFieldsToEntityFields.Add("user.id", "User/Id");
            dtoFieldsToEntityFields.Add("user.displayName", "User/UserName");
        }

        protected override bool IsChildRecord(int aId, List<string> aParentsList)
        {
            throw new System.NotImplementedException();
        }

        public override AuditReportExecutionOutDto Insert(AuditReportExecutionInDto aInDto)
        {
            aInDto.UserId = UserContext.UserId.Value;
            aInDto.AuthorityId = UserContext.AdministrationID.Value;
            return base.Insert(aInDto);
        }

        public AuditReportExecutionWithResultOutDto ReaderReportExecution(int aId)
        {
            var res =  this._baseRepository.Select(aId);
            return MappingTools.MapTo<AuditReportExecutions, AuditReportExecutionWithResultOutDto>(res);

        }
    }
}