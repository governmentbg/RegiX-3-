using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.HealthServiceLog;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Services.Contracts
{
    public interface
        IHealthServiceLogService : IBaseService<HealthServiceLogInDto, HealthServiceLogOutDto, HealthServiceLog, decimal
        >
    {
    }
}