using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.HealthServicePing;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Services.Contracts
{
    public interface IHealthServicePingService : IBaseService<HealthServicePingInDto, HealthServicePingOutDto,
        HealthServicePing, decimal>
    {
    }
}