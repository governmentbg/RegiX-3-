using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.RegisterObject;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Services.Contracts
{
    public interface
        IRegisterObjectService : IBaseService<RegisterObjectInDto, RegisterObjectOutDto, RegisterObjects, decimal>
    {
    }
}