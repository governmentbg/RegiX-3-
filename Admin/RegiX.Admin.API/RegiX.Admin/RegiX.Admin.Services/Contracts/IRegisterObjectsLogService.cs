using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.RegisterObjectsLog;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Services.Contracts
{
    public interface IRegisterObjectsLogService : IBaseService<RegisterObjectsLogInDto, RegisterObjectsLogOutDto,
        RegisterObjectsLog, decimal>
    {
    }
}