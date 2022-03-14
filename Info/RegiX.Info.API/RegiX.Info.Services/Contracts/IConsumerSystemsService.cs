using RegiX.Info.DataContracts.DTO.ConsumerSystems;
using RegiX.Info.Infrastructure.Models;
using TechnoLogica.API.Services;

namespace RegiX.Info.Services.Contracts
{
    public interface IConsumerSystemsService : IBaseService<ConsumerSystemsInDto, ConsumerSystemsOutDto, ConsumerSystems, decimal>
    {
    }
}
