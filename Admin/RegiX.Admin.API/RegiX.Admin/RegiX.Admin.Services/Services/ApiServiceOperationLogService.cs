using System;
using System.Collections.Generic;
using TechnoLogica.API.Repositories.Contracts;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ApiServiceOperationLog;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.Services.Services
{
    /// <summary>
    ///     Defines the <see cref="ApiServiceOperationLogService" />
    /// </summary>
    public class ApiServiceOperationLogService :
        ABaseService<ApiServiceOperationLogInDto, ApiServiceOperationLogOutDto, ApiServiceOperationLog, decimal,
            RegiXContext>,
        IApiServiceOperationLogService
    {
        public ApiServiceOperationLogService(
            IApiServiceOperationLogRepository aBaseRepository)
            : base(aBaseRepository)
        {
        }

        /// <summary>
        ///     The PopulateDtoToEntityFieldsMapping
        /// </summary>
        protected override void PopulateDtoToEntityFieldsMapping()
        {
            dtoFieldsToEntityFields.Add("apiServiceOperation.id", "ApiServiceOperation/ApiServiceOperationId");
            dtoFieldsToEntityFields.Add("apiServiceOperation.displayName", "ApiServiceOperation/Name");
            dtoFieldsToEntityFields.Add("id", "ApiServiceOperationLogId");
        }

        protected override bool IsChildRecord(decimal aId, List<string> aParentsList)
        {
            throw new NotImplementedException();
        }
    }
}