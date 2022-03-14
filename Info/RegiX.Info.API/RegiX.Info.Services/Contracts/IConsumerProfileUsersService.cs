using RegiX.Info.API.DTOs.ConsumerProfileUsers;
using RegiX.Info.Infrastructure.Models;
using TechnoLogica.API.Services;

namespace RegiX.Info.Services.Contracts
{
    public interface IConsumerProfileUsersService : IBaseService<ConsumerProfileUsersInDto, ConsumerProfileUsersOutDto, ConsumerProfileUsers, decimal>
    {
        
    }
}