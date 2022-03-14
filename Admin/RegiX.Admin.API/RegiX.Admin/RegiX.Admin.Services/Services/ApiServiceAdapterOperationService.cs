using System;
using System.Collections.Generic;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ApiServiceAdapterOperation;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.Services.Services
{
    /// <summary>
    ///     Defines the <see cref="ApiServiceAdapterOperationService" />
    /// </summary>
    public class ApiServiceAdapterOperationService :
        ABaseService<ApiServiceAdapterOperationInDto, ApiServiceAdapterOperationOutDto, ApiServiceAdapterOperations,
            decimal, RegiXContext>, IApiServiceAdapterOperationService
    {
        public ApiServiceAdapterOperationService(
            IApiServiceAdapterOperationsRepository aBaseRepository)
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
            dtoFieldsToEntityFields.Add("apiServiceOperation.id", "ApiServiceOperation/ApiServiceOperationId");
            dtoFieldsToEntityFields.Add("apiServiceOperation.displayName", "ApiServiceOperation/Name");
        }

        protected override bool IsChildRecord(decimal aId, List<string> aParentsList)
        {
            throw new NotImplementedException();
        }
    }
}