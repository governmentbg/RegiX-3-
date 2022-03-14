using System;
using System.Collections.Generic;
using TechnoLogica.API.Repositories.Contracts;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ParametersValuesLog;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.Services.Services
{
    /// <summary>
    ///     Defines the <see cref="ParametersValuesLogService" />
    /// </summary>
    public class ParametersValuesLogService :
        ABaseService<ParametersValuesLogInDto, ParametersValuesLogOutDto, ParametersValuesLog, decimal, RegiXContext>,
        IParametersValuesLogService
    {
        public ParametersValuesLogService(IParametersValuesLogRepository aBaseRepository)
            : base(aBaseRepository)
        {
        }

        /// <summary>
        ///     The PopulateDtoToEntityFieldsMapping
        /// </summary>
        protected override void PopulateDtoToEntityFieldsMapping()
        {
            dtoFieldsToEntityFields.Add("registerAdapter.id", "RegisterAdapter/RegisterAdapterId");
            dtoFieldsToEntityFields.Add("registerAdapter.displayName", "RegisterAdapter/Name");
            dtoFieldsToEntityFields.Add("user.id", "User/UserId");
            dtoFieldsToEntityFields.Add("user.displayName", "User/Name");
        }

        protected override bool IsChildRecord(decimal aId, List<string> aParentsList)
        {
            throw new NotImplementedException();
        }
    }
}