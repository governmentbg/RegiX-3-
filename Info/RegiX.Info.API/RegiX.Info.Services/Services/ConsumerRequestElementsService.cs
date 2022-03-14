using Microsoft.AspNet.OData.Query.Validators;
using RegiX.Info.DataContracts.DTO.ConsumerRequestElements;
using RegiX.Info.Infrastructure.Models;
using RegiX.Info.Repositories.Contracts;
using RegiX.Info.Services.Contracts;
using System.Collections.Generic;
using TechnoLogica.API.Services;

namespace RegiX.Info.Services.Services
{
    public class ConsumerRequestElementsService :
        ABaseService<ConsumerRequestElementsInDto, ConsumerRequestElementsOutDto, ConsumerRequestElements, decimal,
            RegiXContext>,
        IConsumerRequestElementsService
    {
        public ConsumerRequestElementsService(IConsumerRequestElementsRepository aBaseRepository, FilterQueryValidator aQueryValidator = null) : 
            base(aBaseRepository, aQueryValidator)
        {
        }

        protected override void PopulateDtoToEntityFieldsMapping()
        {
            dtoFieldsToEntityFields.Add("registerObjectElement.id", "RegisterObjectElement/RegisterObjectElementId");
            dtoFieldsToEntityFields.Add("registerObjectElement.displayName", "RegisterObjectElement/Name");
        }

        protected override bool IsChildRecord(decimal aId, List<string> aParentsList)
        {
            return false;
        }
    }
}
