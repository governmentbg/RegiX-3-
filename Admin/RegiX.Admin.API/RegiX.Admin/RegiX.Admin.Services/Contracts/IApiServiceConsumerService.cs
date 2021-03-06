using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ApiServiceConsumer;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Services.Contracts
{
    public interface IApiServiceConsumerService : IBaseService<ApiServiceConsumerInDto, ApiServiceConsumerOutDto,
        ApiServiceConsumers, decimal>
    {
    }
}