using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.AdapterPingResult;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Services.Contracts
{
    public interface IAdapterPingResultService : IBaseService<AdapterPingResultInDto, AdapterPingResultOutDto,
        AdapterPingResults, decimal>
    {
    }
}