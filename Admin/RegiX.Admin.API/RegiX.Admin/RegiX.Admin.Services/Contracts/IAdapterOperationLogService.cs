using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.AdapterOperationLog;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Services.Contracts
{
    public interface IAdapterOperationLogService : IBaseService<AdapterOperationLogInDto, AdapterOperationLogOutDto,
        AdapterOperationLog, decimal>
    {
    }
}