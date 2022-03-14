using RegiX.Info.DataContracts.DTO.ConsumerRequests;
using RegiX.Info.Infrastructure.Models;
using TechnoLogica.API.Services;

namespace RegiX.Info.Services.Contracts
{
    public interface IConsumerRequestsService : IBaseService<ConsumerRequestsInDto, ConsumerRequestsOutDto, ConsumerRequests, decimal>
    {
        byte[] CreateReport(decimal consumerRequest);
    }
}
