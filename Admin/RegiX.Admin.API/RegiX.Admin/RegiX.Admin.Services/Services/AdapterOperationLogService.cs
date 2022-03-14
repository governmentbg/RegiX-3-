using System;
using System.Collections.Generic;
using TechnoLogica.API.Repositories.Contracts;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.AdapterOperationLog;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.Services.Services
{
    /// <summary>
    ///     Defines the <see cref="AdapterOperationLogService" />
    /// </summary>
    public class AdapterOperationLogService :
        ABaseService<AdapterOperationLogInDto, AdapterOperationLogOutDto, AdapterOperationLog, decimal, RegiXContext>,
        IAdapterOperationLogService
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="AdapterOperationLogService" /> class.
        /// </summary>
        /// <param name="aBaseRepository">The aBaseRepository<see cref="IBaseRepository{AdapterOperationLog}" /></param>
        /// <param name="aDbContext">The aDbContext<see cref="RegiXContext" /></param>
        public AdapterOperationLogService(IAdapterOperationLogRepository aBaseRepository)
            : base(aBaseRepository)
        {
        }

        /// <summary>
        ///     The PopulateDtoToEntityFieldsMapping
        /// </summary>
        protected override void PopulateDtoToEntityFieldsMapping()
        {
            dtoFieldsToEntityFields.Add("adapterOperation.id", "AdapterOperation/AdapterOperationId");
            dtoFieldsToEntityFields.Add("adapterOperation.displayName", "AdapterOperation/Name");
            dtoFieldsToEntityFields.Add("id", "AdapterOperationLogId");
        }

        protected override bool IsChildRecord(decimal aId, List<string> aParentsList)
        {
            throw new NotImplementedException();
        }
    }
}