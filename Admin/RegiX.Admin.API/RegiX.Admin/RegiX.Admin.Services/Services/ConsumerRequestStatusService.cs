using System.Collections.Generic;
using Microsoft.AspNet.OData.Query.Validators;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerRequestStatus;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.Services.Services
{
    public class ConsumerRequestStatusService :
        ABaseService<ConsumerRequestStatusInDto, ConsumerRequestStatusOutDto, ConsumerRequestStatus, decimal, RegiXContext>,
        IConsumerRequestStatusService
    {
        public ConsumerRequestStatusService(IConsumerRequestStatusRepository aBaseRepository, FilterQueryValidator aQueryValidator = null) 
            : base(aBaseRepository, aQueryValidator)
        {
        }

        protected override void PopulateDtoToEntityFieldsMapping()
        {
            dtoFieldsToEntityFields.Add("consumerRequest.id", "ConsumerRequest/ConsumerRequestId");
            dtoFieldsToEntityFields.Add("consumerRequest.displayName", "ConsumerRequest/Name");
        }

        protected override bool IsChildRecord(decimal aId, List<string> aParentsList)
        {
            return false;
        }
    }
}