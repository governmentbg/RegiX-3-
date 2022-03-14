using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.AuditExceptions;
using TechnoLogica.RegiX.Client.Infrastructure.Models;

namespace TechnoLogica.RegiX.Client.Services.Contracts
{
    public interface
        IAuditExceptionsService : IBaseService<AuditExceptionsInDto, AuditExceptionsOutDto, AuditExceptions, int>
    {
    }
}