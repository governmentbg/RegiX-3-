using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.ParameterToOperation;
using TechnoLogica.RegiX.Client.Infrastructure.Models;

namespace TechnoLogica.RegiX.Client.Services.Contracts
{
    public interface IParameterToOperationService : IBaseService<ParameterToOperationInDto, ParameterToOperationOutDto,
        ParametersToOperation, int>
    {
    }
}