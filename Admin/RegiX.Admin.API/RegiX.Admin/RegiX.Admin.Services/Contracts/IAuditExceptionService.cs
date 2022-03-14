using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.AuditException;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Services.Contracts
{
    public interface
        IAuditExceptionService : IBaseService<AuditExceptionInDto, AuditExceptionOutDto, AuditExceptions, decimal>
    {
    }
}