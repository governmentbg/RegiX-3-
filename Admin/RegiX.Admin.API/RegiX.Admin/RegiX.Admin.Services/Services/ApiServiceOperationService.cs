using System;
using System.Collections.Generic;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ApiServiceOperation;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;
using TechnoLogica.RegiX.Admin.Services.Contracts;
using TechnoLogica.RegiX.Admin.Services.QueryValidators;

namespace TechnoLogica.RegiX.Admin.Services.Services
{
    /// <summary>
    ///     Defines the <see cref="ApiServiceOperationService" />
    /// </summary>
    public class ApiServiceOperationService :
        ABaseService<ApiServiceOperationInDto, ApiServiceOperationOutDto, ApiServiceOperations, decimal, RegiXContext>,
        IApiServiceOperationService
    {
        public ApiServiceOperationService(IApiServiceOperationsRepository aBaseRepository)
            : base(aBaseRepository, new ApiServiceOperationQueryValidator())
        {
        }

        /// <summary>
        ///     The PopulateDtoToEntityFieldsMapping
        /// </summary>
        protected override void PopulateDtoToEntityFieldsMapping()
        {
            dtoFieldsToEntityFields.Add("apiService.id", "ApiService/ApiServiceId");
            dtoFieldsToEntityFields.Add("apiService.displayName", "ApiService/Name");
            dtoFieldsToEntityFields.Add("id", "ApiServiceOperationId");
        }

        protected override bool IsChildRecord(decimal aId, List<string> aParentsList)
        {
            throw new NotImplementedException();
        }
    }
}