using Microsoft.AspNet.OData.Query.Validators;
using System.Collections.Generic;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerAccessRequestsStatus;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.Services.Services
{
    public class ConsumerAccessRequestsStatusService :
        ABaseService<ConsumerAccessRequestsStatusInDto, ConsumerAccessRequestsStatusOutDto, ConsumerAccessRequestsStatus, decimal, RegiXContext>,
        IConsumerAccessRequestsStatusService
    {
        public ConsumerAccessRequestsStatusService(IConsumerAccessRequestsStatusRepository aBaseRepository, FilterQueryValidator aQueryValidator = null)
            : base(aBaseRepository, aQueryValidator)
        {
        }

        /// <summary>
        ///     The PopulateDtoToEntityFieldsMapping
        /// </summary>
        protected override void PopulateDtoToEntityFieldsMapping()
        {
       
        }

        protected override bool IsChildRecord(decimal aId, List<string> aParentsList)
        {
            return false;
        }
    }
}