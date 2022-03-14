using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.AdapterHealthResult;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Services.Contracts
{
    public interface IAdapterHealthResultService : IBaseService<AdapterHealthResultInDto, AdapterHealthResultOutDto,
        AdapterHealthResults, decimal>
    {
    }
}