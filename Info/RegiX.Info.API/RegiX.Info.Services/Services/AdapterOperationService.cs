using Microsoft.AspNet.OData.Query.Validators;
using RegiX.Info.DataContracts.DTO.AdapterOperations;
using RegiX.Info.Infrastructure.Models;
using RegiX.Info.Repositories.Contracts;
using RegiX.Info.Services.Contracts;
using System.Collections.Generic;
using RegiX.Info.Services.QueryValidators;
using TechnoLogica.API.Services;

namespace RegiX.Info.Services.Services
{
    public class AdapterOperationService :
        ABaseService<AdapterOperationInDto, AdapterOperationOutDto, AdapterOperations, decimal, RegiXContext>,
        IAdapterOperationService
    {

        public AdapterOperationService(IAdapterOperationsRepository aBaseRepository) 
            : base(aBaseRepository, new AdapterOperationQueryValidator())
        {
        }
        protected override bool IsChildRecord(decimal aId, List<string> aParentsList)
        {
            return false;
        }

        protected override void PopulateDtoToEntityFieldsMapping()
        {
            dtoFieldsToEntityFields.Add("registerObject.id", "RegisterObject/RegisterObjectId");
            dtoFieldsToEntityFields.Add("registerObject.displayName", "RegisterObject/Name");
            dtoFieldsToEntityFields.Add("registerAdapter.id", "RegisterAdapter/RegisterAdapterId");
            dtoFieldsToEntityFields.Add("registerAdapter.displayName", "RegisterAdapter/Name");
            dtoFieldsToEntityFields.Add("id", "AdapterOperationId");
        }

    }
}