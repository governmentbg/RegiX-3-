using System;
using RegiX.Info.DataContracts.DTO.ConsumerAccessRequests;
using RegiX.Info.Infrastructure.Models;
using RegiX.Info.Repositories.Contracts;
using RegiX.Info.Services.Contracts;
using RegiX.Info.Services.QueryValidators;
using System.Collections.Generic;
using System.Linq;
using TechnoLogica.API.Services;

namespace RegiX.Info.Services.Services
{
    public class ConsumerAccessRequestsService :
        ABaseService<ConsumerAccessRequestsInDto, ConsumerAccessRequestsOutDto, ConsumerAccessRequests, decimal,
            RegiXContext>,
        IConsumerAccessRequestsService
    {
        private readonly IConsumerAccessRequestsRepository aBaseRepository;
        private readonly IConsumerRequestElementsRepository consumerRequestElementsRepository;
        private readonly IConsumerAccessRequestsStatusRepository consumerAccessRequestsStatusRepository;

        public ConsumerAccessRequestsService
        (
            IConsumerAccessRequestsRepository aBaseRepository,
            IConsumerRequestElementsRepository consumerRequestElementsRepository,
            IConsumerAccessRequestsStatusRepository consumerAccessRequestsStatusRepository
            )
            : base(aBaseRepository, new ConsumerAccessRequestsQueryValidator())
        {
            this.aBaseRepository = aBaseRepository;
            this.consumerRequestElementsRepository = consumerRequestElementsRepository;
            this.consumerAccessRequestsStatusRepository = consumerAccessRequestsStatusRepository;
        }

        public override ConsumerAccessRequestsOutDto Insert(ConsumerAccessRequestsInDto aInDto)
        {
            ConsumerAccessRequests mappedObj = MappingTools.MapTo<ConsumerAccessRequestsInDto, ConsumerAccessRequests>(aInDto);
            ConsumerAccessRequests resultObj = this._baseRepository.Insert(mappedObj);
            resultObj.Status = 0; // 0 represents "NEW" status 
            AddRequestElements(aInDto, resultObj);
            var consumerAccessRequestsStatus = new ConsumerAccessRequestsStatus
            {
                OldStatus = 0,
                NewStatus = 0,
                Comment = "Получаване на заявката",
                Date = DateTime.Now,
                ConsumerAccessRequest = mappedObj
            };
            this.consumerAccessRequestsStatusRepository.Insert(consumerAccessRequestsStatus);

            this._baseRepository.GetDbContext().SaveChanges();
            return MappingTools.MapTo<ConsumerAccessRequests, ConsumerAccessRequestsOutDto>(resultObj);
        }

        public override ConsumerAccessRequestsOutDto Delete(decimal aId)
        {
            var consumerRequestElementsToDelete =
                this.consumerRequestElementsRepository
                    .SelectAll()
                    .Where(x => x.ConsumerAccessRequestId == aId)
                    .Select(x => x.Id);
            foreach (var consumerRequestElement in consumerRequestElementsToDelete)
            {
                this.consumerRequestElementsRepository.Delete(consumerRequestElement);
            }

            var consumerAccessRequestsStatusToDelete =
                this.consumerAccessRequestsStatusRepository
                    .SelectAll()
                    .Where(x => x.ConsumerAccessRequestId == aId)
                    .Select(x => x.Id);
            foreach (var consumerAccessRequestsStatus in consumerAccessRequestsStatusToDelete)
            {
                this.consumerAccessRequestsStatusRepository.Delete(consumerAccessRequestsStatus);
            }
            var deletedObj = base.Delete(aId);
            this.aBaseRepository.GetDbContext().SaveChanges();
            return deletedObj;
        }

        protected override void PopulateDtoToEntityFieldsMapping()
        {
            dtoFieldsToEntityFields.Add("consumerSystemCertificate.id", "ConsumerSystemCertificate/ConsumerSystemCertificateId");
            dtoFieldsToEntityFields.Add("consumerSystemCertificate.displayName", "ConsumerSystemCertificate/Name");
            dtoFieldsToEntityFields.Add("consumerRequest.id", "ConsumerRequest/Id");
            dtoFieldsToEntityFields.Add("consumerRequest.displayName", "ConsumerRequest/Name");
            dtoFieldsToEntityFields.Add("adapterOperation.id", "AdapterOperation/AdapterOperationId");
            dtoFieldsToEntityFields.Add("adapterOperation.displayName", "AdapterOperation/Description");
            dtoFieldsToEntityFields.Add("id", "ConsumerAccessRequestId");
        }

        protected override bool IsChildRecord(decimal aId, List<string> aParentsList)
        {
            return false;
        }
        private void AddRequestElements(ConsumerAccessRequestsInDto aInDto, ConsumerAccessRequests resultObj)
        {
            foreach (var elementId in aInDto.ElementsIds)
            {
                var consumerRequestElement = new ConsumerRequestElements()
                {
                    RegisterObjectElementId = elementId,
                    ConsumerAccessRequest = resultObj
                };
                this.consumerRequestElementsRepository.Insert(consumerRequestElement);
            }
        }
    }
}
