using System;
using System.Collections.Generic;
using TechnoLogica.API.Repositories.Contracts;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.OperationParameter;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.Services.Services
{
    /// <summary>
    ///     Defines the <see cref="OperationParameterService" />
    /// </summary>
    public class OperationParameterService :
        ABaseService<OperationParameterInDto, OperationParameterOutDto, OperationParameters, decimal, RegiXContext>,
        IOperationParameterService
    {
        public OperationParameterService(IOperationParametersRepository aBaseRepository)
            : base(aBaseRepository)
        {
        }

        /// <summary>
        ///     The PopulateDtoToEntityFieldsMapping
        /// </summary>
        protected override void PopulateDtoToEntityFieldsMapping()
        {
            dtoFieldsToEntityFields.Add("parameterType.id", "ParameterType/Id");
            dtoFieldsToEntityFields.Add("parameterType.displayName", "ParameterType/Name");
            dtoFieldsToEntityFields.Add("serviceOperation.id", "ServiceOperation/ApiServiceOperationId");
            dtoFieldsToEntityFields.Add("serviceOperation.displayName", "ServiceOperation/Name");
        }

        protected override bool IsChildRecord(decimal aId, List<string> aParentsList)
        {
            throw new NotImplementedException();
        }
    }
}