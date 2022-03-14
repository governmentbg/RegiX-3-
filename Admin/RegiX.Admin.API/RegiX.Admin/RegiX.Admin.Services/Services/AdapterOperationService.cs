using System;
using System.Collections.Generic;
using TechnoLogica.API.Repositories.Contracts;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.AdapterOperation;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;
using TechnoLogica.RegiX.Admin.Services.Contracts;
using TechnoLogica.RegiX.Admin.Services.QueryValidators;

namespace TechnoLogica.RegiX.Admin.Services.Services
{
    /// <summary>
    ///     Defines the <see cref="AdapterOperationService" />
    /// </summary>
    public class AdapterOperationService :
        ABaseService<AdapterOperationInDto, AdapterOperationOutDto, AdapterOperations, decimal, RegiXContext>,
        IAdapterOperationService
    {
        public AdapterOperationService(IAdapterOperationsRepository aBaseRepository)
            : base(aBaseRepository, new AdapterOperationQueryValidator())
        {
        }

        /// <summary>
        ///     The PopulateDtoToEntityFieldsMapping
        /// </summary>
        protected override void PopulateDtoToEntityFieldsMapping()
        {
            dtoFieldsToEntityFields.Add("registerObject.id", "RegisterObject/RegisterObjectId");
            dtoFieldsToEntityFields.Add("registerObject.displayName", "RegisterObject/Name");
            dtoFieldsToEntityFields.Add("registerAdapter.id", "RegisterAdapter/RegisterAdapterId");
            dtoFieldsToEntityFields.Add("registerAdapter.displayName", "RegisterAdapter/Name");
            dtoFieldsToEntityFields.Add("id", "AdapterOperationId");
        }

        protected override bool IsChildRecord(decimal aId, List<string> aParentsList)
        {
            throw new NotImplementedException();
        }
    }
}