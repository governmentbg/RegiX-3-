using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.CustomParameter;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Services.Contracts
{
    public interface
        ICustomParameterService : IBaseService<CustomParameterInDto, CustomParameterOutDto, CustomParameters, decimal>
    {
    }
}