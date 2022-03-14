using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.AuditValue;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Services.Contracts
{
    public interface IAuditValueService : IBaseService<AuditValueInDto, AuditValueOutDto, AuditValues, decimal>
    {
    }
}