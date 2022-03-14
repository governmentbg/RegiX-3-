using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerRequestStatus;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Services.Contracts
{
    public interface IConsumerRequestStatusService : IBaseService<ConsumerRequestStatusInDto, ConsumerRequestStatusOutDto, ConsumerRequestStatus, decimal>
    {
        
    }
}