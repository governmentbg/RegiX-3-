using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.OperationsErrorLog;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Services.Contracts
{
    public interface IOperationsErrorLogService : IBaseService<OperationsErrorLogInDto, OperationsErrorLogOutDto,
        OperationsErrorLog, decimal>
    {
    }
}