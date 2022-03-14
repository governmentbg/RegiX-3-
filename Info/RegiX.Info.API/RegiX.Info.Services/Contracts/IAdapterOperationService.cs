using RegiX.Info.DataContracts.DTO.AdapterOperations;
using RegiX.Info.Infrastructure.Models;
using TechnoLogica.API.Services;

namespace RegiX.Info.Services.Contracts
{
    public interface
        IAdapterOperationService : IBaseService<AdapterOperationInDto, AdapterOperationOutDto, AdapterOperations,
            decimal>
    {
        
    }
}