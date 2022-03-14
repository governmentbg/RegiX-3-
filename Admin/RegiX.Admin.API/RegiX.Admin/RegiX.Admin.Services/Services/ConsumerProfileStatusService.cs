using System.Collections.Generic;
using Microsoft.AspNet.OData.Query.Validators;
using TechnoLogica.API.Repositories.Contracts;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerProfileStatus;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Services.Contracts;
using TechnoLogica.RegiX.Admin.Services.QueryValidators;

namespace TechnoLogica.RegiX.Admin.Services.Services
{
    public class ConsumerProfileStatusService :
        ABaseService<ConsumerProfileStatusInDto, ConsumerProfileStatusOutDto, ConsumerProfileStatus, decimal,
            RegiXContext>,
        IConsumerProfileStatusService
    {
        public ConsumerProfileStatusService(IBaseRepository<ConsumerProfileStatus, decimal, RegiXContext> aBaseRepository) : base(aBaseRepository, new ConsumerProfileStatusQueryValidator())
        {
        }

        protected override void PopulateDtoToEntityFieldsMapping()
        {
            dtoFieldsToEntityFields.Add("consumerProfile.id", "ConsumerProfile/ConsumerProfileId");
            dtoFieldsToEntityFields.Add("consumerProfile.displayName", "ConsumerProfile/Name");
            dtoFieldsToEntityFields.Add("id", "ConsumerProfileStatusId"); //Must be last.The order matters
        }

        protected override bool IsChildRecord(decimal aId, List<string> aParentsList)
        {
            return false;
        }
    }
}