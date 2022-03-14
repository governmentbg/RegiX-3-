using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.OperationParameter;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Services.Contracts
{
    public interface IOperationParameterService : IBaseService<OperationParameterInDto, OperationParameterOutDto,
        OperationParameters, decimal>
    {
    }
}