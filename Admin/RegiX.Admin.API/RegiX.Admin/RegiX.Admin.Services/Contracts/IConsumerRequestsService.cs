using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerRequests;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Services.Contracts
{
    public interface IConsumerRequestsService : IBaseService<ConsumerRequestsInDto, ConsumerRequestsOutDto, ConsumerRequests, decimal>
    {
        
    }
}