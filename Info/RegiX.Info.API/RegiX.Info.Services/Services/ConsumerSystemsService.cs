using Microsoft.AspNet.OData.Query.Validators;
using RegiX.Info.DataContracts.DTO.ConsumerSystems;
using RegiX.Info.Infrastructure.Models;
using RegiX.Info.Repositories.Contracts;
using RegiX.Info.Services.Contracts;
using System.Collections.Generic;
using TechnoLogica.API.Services;

namespace RegiX.Info.Services.Services
{
    public class ConsumerSystemsService :
          ABaseService<ConsumerSystemsInDto, ConsumerSystemsOutDto, ConsumerSystems, decimal,
              RegiXContext>,
          IConsumerSystemsService
    {
        public ConsumerSystemsService(IConsumerSystemsRepository aBaseRepository, FilterQueryValidator aQueryValidator = null)
            : base(aBaseRepository, aQueryValidator)
        {
        }

        public override ConsumerSystemsOutDto Update(decimal aId, ConsumerSystemsInDto aInDto)
        {
            return base.Update(aId, aInDto);
        }

        public override ConsumerSystemsOutDto Insert(ConsumerSystemsInDto aInDto)
        {
            return base.Insert(aInDto);
        }

        protected override void PopulateDtoToEntityFieldsMapping()
        {
            dtoFieldsToEntityFields.Add("apiServiceConsumer.id", "ApiServiceConsumer/ApiServiceConsumerId");
            dtoFieldsToEntityFields.Add("apiServiceConsumer.displayName", "AdministrationType/Name");
            dtoFieldsToEntityFields.Add("consumerProfile.id", "ConsumerProfile/ConsumerProfileId");
            dtoFieldsToEntityFields.Add("consumerProfile.displayName", "ConsumerProfile/Name");
            dtoFieldsToEntityFields.Add("id", "ConsumerSystemId"); //Must be last.The order matters
        }

        protected override bool IsChildRecord(decimal aId, List<string> aParentsList)
        {
            return false;
        }
    }
}
