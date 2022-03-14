using System;
using System.Collections.Generic;
using System.Linq;
using TechnoLogica.API.Repositories.Contracts;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.AdapterOperations;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Repositories.Contracts;
using TechnoLogica.RegiX.Client.Services.Contracts;
using TechnoLogica.RegiX.Client.Services.QueryValidators;

namespace TechnoLogica.RegiX.Client.Services.Services
{
    public class AdapterOperationsService :
        ABaseService<AdapterOperationsInDto, AdapterOperationsOutDto, AdapterOperations, int,RegiXClientContext>, IAdapterOperationsService
    {
        public AdapterOperationsService(IAdapterOperationsRepository aBaseRepository) 
            : base(aBaseRepository)
        {
            queryValidator = new AdapterOperationQueryValidator();
        }

        protected override void PopulateDtoToEntityFieldsMapping()
        {
            dtoFieldsToEntityFields.Add("register.id", "Register/Id");
            dtoFieldsToEntityFields.Add("register.displayName", "Register/Name");
            dtoFieldsToEntityFields.Add("registerDisplayName", "Register/Name");
        }

        public AdapterOperationsWithMetadata GetWithMetadata(string operationName)
        {
            var operation = this._baseRepository.SelectAll().Where(ao => ao.OperationName == operationName).FirstOrDefault();
            return MappingTools.MapTo<AdapterOperations, AdapterOperationsWithMetadata>(operation);
        }
        public AdapterOperationsWithMetadata GetWithMetadata(int operationId)
        {
            var operation = this._baseRepository.SelectAll().Where(ao => ao.Id == operationId).FirstOrDefault();
            return MappingTools.MapTo<AdapterOperations, AdapterOperationsWithMetadata>(operation);
        }
        protected override bool IsChildRecord(int aId, List<string> aParentsList)
        {
            throw new NotImplementedException();
        }

    }
}