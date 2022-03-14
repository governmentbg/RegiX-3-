using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.AdapterHealthFunction;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Services.Contracts
{
    public interface IAdapterHealthFunctionService : IBaseService<AdapterHealthFunctionInDto,
        AdapterHealthFunctionOutDto, AdapterHealthFunctions, decimal>
    {
    }
}