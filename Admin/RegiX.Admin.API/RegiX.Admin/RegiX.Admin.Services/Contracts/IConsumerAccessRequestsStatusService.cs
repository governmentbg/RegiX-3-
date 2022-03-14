using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerAccessRequestsStatus;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Services.Contracts
{
    public interface IConsumerAccessRequestsStatusService : IBaseService<ConsumerAccessRequestsStatusInDto, ConsumerAccessRequestsStatusOutDto, ConsumerAccessRequestsStatus,
        decimal>
    {
    }
}