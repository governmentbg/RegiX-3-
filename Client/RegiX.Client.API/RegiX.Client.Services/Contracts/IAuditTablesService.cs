using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.AuditTables;
using TechnoLogica.RegiX.Client.Infrastructure.Models;

namespace TechnoLogica.RegiX.Client.Services.Contracts
{
    public interface IAuditTablesService : IBaseService<AuditTablesInDto, AuditTablesOutDto, AuditTables, int>
    {
    }
}