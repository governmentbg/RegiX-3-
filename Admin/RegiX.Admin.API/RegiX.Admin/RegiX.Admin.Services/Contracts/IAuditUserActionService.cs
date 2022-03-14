using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.AuditUserAction;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Services.Contracts
{
    public interface
        IAuditUserActionService : IBaseService<AuditUserActionInDto, AuditUserActionOutDto, AuditUserActions, decimal>
    {
    }
}