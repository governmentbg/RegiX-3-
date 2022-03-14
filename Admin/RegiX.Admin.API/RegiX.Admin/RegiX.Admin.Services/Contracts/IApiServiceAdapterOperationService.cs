using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ApiServiceAdapterOperation;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Services.Contracts
{
    public interface IApiServiceAdapterOperationService : IBaseService<ApiServiceAdapterOperationInDto,
        ApiServiceAdapterOperationOutDto, ApiServiceAdapterOperations, decimal>
    {
    }
}