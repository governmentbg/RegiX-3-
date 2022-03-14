using RegiX.Info.API.DTOs.ConsumerProfileUsers;
using RegiX.Info.Infrastructure.Models;
using RegiX.Info.Repositories.Contracts;
using RegiX.Info.Services.Contracts;
using System.Collections.Generic;
using TechnoLogica.API.Services;

namespace RegiX.Info.Services.Services
{
    public class ConsumerProfileUsersService : ABaseService<ConsumerProfileUsersInDto, ConsumerProfileUsersOutDto, ConsumerProfileUsers, decimal, RegiXContext>,
        IConsumerProfileUsersService
    {
        public ConsumerProfileUsersService(IConsumerProfileUsersRepository aBaseRepository) 
            : base(aBaseRepository)
        {
        }

        protected override void PopulateDtoToEntityFieldsMapping()
        {
        }

        protected override bool IsChildRecord(decimal aId, List<string> aParentsList)
        {
            return false;
        }
    }
}