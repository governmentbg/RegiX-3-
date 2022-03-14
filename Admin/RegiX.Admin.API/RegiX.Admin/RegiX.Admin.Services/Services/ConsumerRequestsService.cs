using System.Collections.Generic;
using System.Linq;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerRequests;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;
using TechnoLogica.RegiX.Admin.Services.Contracts;
using TechnoLogica.RegiX.Admin.Services.QueryValidators;

namespace TechnoLogica.RegiX.Admin.Services.Services
{
    public class ConsumerRequestsService :
        ABaseService<ConsumerRequestsInDto, ConsumerRequestsOutDto, ConsumerRequests, decimal, RegiXContext>,
        IConsumerRequestsService
    {
        private readonly IConsumerRequestStatusRepository consumerRequestStatusRepository;
        private readonly IConsumerAccessRequestsStatusRepository consumerAccessRequestsStatusRepository;
        private readonly IConsumerAccessRequestsRepository consumerAccessRequestsRepository;
        private readonly IConsumerRequestElementsRepository consumerRequestElementsRepository;

        public ConsumerRequestsService(IConsumerRequestsRepository aBaseRepository,
            IConsumerRequestStatusRepository consumerRequestStatusRepository,
            IConsumerAccessRequestsStatusRepository consumerAccessRequestsStatusRepository,
            IConsumerAccessRequestsRepository consumerAccessRequestsRepository,
            IConsumerRequestElementsRepository consumerRequestElementsRepository) 
            : base(aBaseRepository, new ConsumerRequestsQueryValidator())
        {
            this.consumerRequestStatusRepository = consumerRequestStatusRepository;
            this.consumerAccessRequestsStatusRepository = consumerAccessRequestsStatusRepository;
            this.consumerAccessRequestsRepository = consumerAccessRequestsRepository;
            this.consumerRequestElementsRepository = consumerRequestElementsRepository;
        }

      

        protected override void PopulateDtoToEntityFieldsMapping()
        {
            dtoFieldsToEntityFields.Add("consumerProfile.id", "ConsumerProfile/ConsumerProfileId");
            dtoFieldsToEntityFields.Add("consumerProfile.displayName", "ConsumerProfile/Name");
            dtoFieldsToEntityFields.Add("id", "ConsumerRequestId");
        }

        protected override bool IsChildRecord(decimal aId, List<string> aParentsList)
        {
            return false;
        }
    }
}