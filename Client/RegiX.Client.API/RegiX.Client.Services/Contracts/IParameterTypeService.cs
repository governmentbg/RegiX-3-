using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.ParameterType;
using TechnoLogica.RegiX.Client.Infrastructure.Models;

namespace TechnoLogica.RegiX.Client.Services.Contracts
{
    public interface IParameterTypeService : IBaseService<ParameterTypeInDto, ParameterTypeOutDto, ParameterTypes, int>
    {
    }
}