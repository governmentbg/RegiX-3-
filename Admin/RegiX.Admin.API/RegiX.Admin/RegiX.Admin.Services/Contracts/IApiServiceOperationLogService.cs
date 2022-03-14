using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ApiServiceOperationLog;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Services.Contracts
{
    public interface IApiServiceOperationLogService : IBaseService<ApiServiceOperationLogInDto,
        ApiServiceOperationLogOutDto, ApiServiceOperationLog, decimal>
    {
    }
}