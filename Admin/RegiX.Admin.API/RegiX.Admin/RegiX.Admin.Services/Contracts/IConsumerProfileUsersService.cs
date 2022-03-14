using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerProfileUsers;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Services.Contracts
{
    public interface IConsumerProfileUsersService : IBaseService<ConsumerProfileUsersInDto, ConsumerProfileUsersOutDto, ConsumerProfileUsers, decimal>
    {
        
    }
}