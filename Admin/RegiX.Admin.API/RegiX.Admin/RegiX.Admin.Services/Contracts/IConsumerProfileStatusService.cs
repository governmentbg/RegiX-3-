using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerProfileStatus;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Services.Contracts
{
    public interface IConsumerProfileStatusService : IBaseService<ConsumerProfileStatusInDto, ConsumerProfileStatusOutDto, ConsumerProfileStatus, decimal>
    {
        
    }
}