using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.AdapterOperation;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Services.Contracts
{
    public interface
        IAdapterOperationService : IBaseService<AdapterOperationInDto, AdapterOperationOutDto, AdapterOperations,
            decimal>
    {
    }
}