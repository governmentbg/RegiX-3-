using RegiX.Info.DataContracts.DTO.ConsumerProfile;
using RegiX.Info.Infrastructure.Models;
using RegiX.Info.Repositories.Contracts;
using RegiX.Info.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using TechnoLogica.API.Services;

namespace RegiX.Info.Services.Services
{
    public class ConsumerProfileService :
        ABaseService<ConsumerProfileInDto, ConsumerProfileOutDto, ConsumerProfiles, decimal, RegiXContext>,
        IConsumerProfileService
    {
        public ConsumerProfileService(IConsumerProfileRepository aBaseRepository) : base(aBaseRepository)
        {
        }

        protected override bool IsChildRecord(decimal aId, List<string> aParentsList)
        {
            return false;
        }

        protected override void PopulateDtoToEntityFieldsMapping()
        {
        }

        public override ConsumerProfileOutDto Insert(ConsumerProfileInDto aInDto)
        {
            try
            {
                return base.Insert(aInDto);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
