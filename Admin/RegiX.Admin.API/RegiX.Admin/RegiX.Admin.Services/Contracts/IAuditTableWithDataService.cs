using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.AuditTable;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Services.Contracts
{
    public interface
        IAuditTableWithDataService : IBaseService<AuditTableWithDataInDto, AuditTableWithDataOutDto, AuditTables,
            decimal>
    {
    }
}