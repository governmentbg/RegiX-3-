using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.AuditTablesWithData;
using TechnoLogica.RegiX.Client.Infrastructure.Models;

namespace TechnoLogica.RegiX.Client.Services.Contracts
{
    public interface
        IAuditTablesWithDataService : IBaseService<AuditTablesWithDataInDto, AuditTablesWithDataOutDto, AuditTables, int
        >
    {
    }
}