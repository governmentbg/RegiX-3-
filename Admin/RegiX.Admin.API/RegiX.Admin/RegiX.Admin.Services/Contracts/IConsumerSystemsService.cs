using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerSystems;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Services.Contracts
{
    public interface IConsumerSystemsService : IBaseService<ConsumerSystemsInDto, ConsumerSystemsOutDto, ConsumerSystems, decimal>
    {
        
    }
}