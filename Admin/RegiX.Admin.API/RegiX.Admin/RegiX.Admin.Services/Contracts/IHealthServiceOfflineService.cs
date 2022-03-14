using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.HealthServiceOffline;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Services.Contracts
{
    public interface IHealthServiceOfflineService : IBaseService<HealthServiceOfflineInDto, HealthServiceOfflineOutDto,
        HealthServiceOffline, decimal>
    {
    }
}