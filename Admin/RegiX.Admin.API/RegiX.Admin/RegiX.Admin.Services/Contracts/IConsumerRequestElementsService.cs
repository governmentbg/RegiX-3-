using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerRequestElements;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Services.Contracts
{
    public interface IConsumerRequestElementsService : IBaseService<ConsumerRequestElementsInDto, ConsumerRequestElementsOutDto, ConsumerRequestElements, decimal>
    {
        
    }
}