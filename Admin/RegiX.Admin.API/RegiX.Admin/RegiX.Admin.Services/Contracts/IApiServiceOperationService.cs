using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ApiServiceOperation;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Services.Contracts
{
    public interface IApiServiceOperationService : IBaseService<ApiServiceOperationInDto, ApiServiceOperationOutDto,
        ApiServiceOperations, decimal>
    {
    }
}