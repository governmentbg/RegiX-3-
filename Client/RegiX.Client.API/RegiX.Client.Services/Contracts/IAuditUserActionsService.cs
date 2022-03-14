using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.AuditUserActions;
using TechnoLogica.RegiX.Client.Infrastructure.Models;

namespace TechnoLogica.RegiX.Client.Services.Contracts
{
    public interface
        IAuditUserActionsService : IBaseService<AuditUserActionsInDto, AuditUserActionsOutDto, AuditUserActions, int>
    {
    }
}