using RegiX.Info.DataContracts.DTO.ConsumerRequests;
using RegiX.Info.Infrastructure.Models;
using RegiX.Info.Repositories;
using RegiX.Info.Repositories.Contracts;
using RegiX.Info.Services.Contracts;
using RegiX.Info.Services.QueryValidators;
using System;
using System.Collections.Generic;
using TechnoLogica.API.Services;

namespace RegiX.Info.Services.Services
{
    public class ConsumerRequestsService :
         ABaseService<ConsumerRequestsInDto, ConsumerRequestsOutDto, ConsumerRequests, decimal,
             RegiXContext>,
         IConsumerRequestsService
    {
        private readonly IConsumerContext consumerContext;
        private readonly IReportingService reportingService;
        private readonly IConsumerRequestStatusRepository consumerRequestStatusRepository;

        public ConsumerRequestsService(IConsumerRequestsRepository aBaseRepository, IConsumerContext consumerContext,IReportingService reportingService,IConsumerRequestStatusRepository consumerRequestStatusRepository) :
            base(aBaseRepository, new ConsumerRequestsQueryValidator())
        {
            this.consumerContext = consumerContext;
            this.reportingService = reportingService;
            this.consumerRequestStatusRepository = consumerRequestStatusRepository;
        }

        protected override void ValidateUpdate(ConsumerRequests repoObj, ConsumerRequestsInDto aInDto)
        {
            if (aInDto.Status != 1)//User can only change status from DRAFT to NEW
            {
                throw  new ArgumentException("Не позволена промяна на статуса !");
            }
        }

        public override ConsumerRequestsOutDto Insert(ConsumerRequestsInDto aInDto)
        {
            ConsumerRequests mappedObj = MappingTools.MapTo<ConsumerRequestsInDto, ConsumerRequests>(aInDto);
            mappedObj.ConsumerProfileId = (decimal)consumerContext.ConsumerProfileID;
            ConsumerRequests resultObj = this._baseRepository.Insert(mappedObj);
            var consumerRequestStatus = new ConsumerRequestStatus
            {
                Date = DateTime.Now,
                Comment = "Получена заявка",
                OldStatus = 0,
                NewStatus = 1,
                ConsumerRequest = resultObj
            };
            this.consumerRequestStatusRepository.Insert(consumerRequestStatus);
            this._baseRepository.GetDbContext().SaveChanges();
            return MappingTools.MapTo<ConsumerRequests, ConsumerRequestsOutDto>(resultObj);
        }

        public override ConsumerRequestsOutDto Update(decimal aId, ConsumerRequestsInDto aInDto)
        {
            //Add new method to update only the status and to write in consumerRequestsStatus table 
            //Change the angular to use the new method
            return base.Update(aId, aInDto);
        }

        public byte[] CreateReport(decimal consumerRequest)
        {
            var result = this.reportingService.RunFullReport(
                consumerContext.UserId.ToString(),
                consumerRequest.ToString());

            return result.GetAwaiter().GetResult();
        }

        protected override void PopulateDtoToEntityFieldsMapping()
        {
            dtoFieldsToEntityFields.Add("consumerSystem.id", "ConsumerSystem/ConsumerSystemId");
            dtoFieldsToEntityFields.Add("consumerSystem.displayName", "ConsumerSystem/Name");
        }

        protected override bool IsChildRecord(decimal aId, List<string> aParentsList)
        {
            return false;
        }
    }
}
