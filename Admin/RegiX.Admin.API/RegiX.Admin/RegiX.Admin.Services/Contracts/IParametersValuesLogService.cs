using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ParametersValuesLog;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Services.Contracts
{
    public interface IParametersValuesLogService : IBaseService<ParametersValuesLogInDto, ParametersValuesLogOutDto,
        ParametersValuesLog, decimal>
    {
    }
}