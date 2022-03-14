using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ParameterType;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Services.Contracts
{
    public interface
        IParameterTypeService : IBaseService<ParameterTypeInDto, ParameterTypeOutDto, ParameterTypes, decimal>
    {
    }
}