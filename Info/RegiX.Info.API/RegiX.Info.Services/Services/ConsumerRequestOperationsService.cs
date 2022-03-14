using RegiX.Info.DataContracts.DTO.ConsumerRequestOperations;
using RegiX.Info.Infrastructure.Models;
using RegiX.Info.Repositories.Contracts;
using RegiX.Info.Services.Contracts;
using RegiX.Info.Services.QueryValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechnoLogica.API.Repositories.Contracts;
using TechnoLogica.API.Services;

namespace RegiX.Info.Services.Services
{
    public class ConsumerRequestOperationsService :
         ABaseService<ConsumerRequestOperationsInDto, ConsumerRequestOperationsOutDto, ConsumerRequestOperations, decimal,
             RegiXContext>,
         IConsumerRequestOperationsService
    {
        public ConsumerRequestOperationsService(IConsumerRequestOperationsRepository aBaseRepository) : 
            base(aBaseRepository, new ConsumerRequestOperationsQueryValidator())
        {
        }

        protected override void PopulateDtoToEntityFieldsMapping()
        {
            dtoFieldsToEntityFields.Add("adapterOperation.id", "AdapterOperation/AdapterOperationId");
            dtoFieldsToEntityFields.Add("adapterOperation.displayName", "AdapterOperation/Name");
            dtoFieldsToEntityFields.Add("adapterOperation.registerObjectId", "AdapterOperation/RegisterObjectId");
            dtoFieldsToEntityFields.Add("adapterOperation.description", "AdapterOperation/Description");
            dtoFieldsToEntityFields.Add("consumerAccessRequest.id", "ConsumerAccessRequest/ConsumerAccessRequestId");
            dtoFieldsToEntityFields.Add("consumerAccessRequest.status", "ConsumerAccessRequest/Status");
        }

        protected override bool IsChildRecord(decimal aId, List<string> aParentsList)
        {
            return false;
        }
    }
}
