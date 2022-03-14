using RegiX.Info.API.DTOs.ConsumerProfileUsers;
using RegiX.Info.DataContracts.DTO.ConsumerProfileUsersApproved;
using RegiX.Info.Infrastructure.Models;
using TechnoLogica.API.Services;

namespace RegiX.Info.Services.Contracts
{
    public interface IConsumerProfileUsersApprovedService :  IBaseService<ConsumerProfileUsersApprovedInDto, ConsumerProfileUsersApprovedOutDto, ConsumerProfileUsers, decimal>
    {
        
    }
}