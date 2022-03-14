using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.AdapterOperations;
using TechnoLogica.RegiX.Client.Infrastructure.Models;

namespace TechnoLogica.RegiX.Client.Services.Contracts
{
    public interface
        IAdapterOperationsService : IBaseService<AdapterOperationsInDto, AdapterOperationsOutDto, AdapterOperations, int
        >
    {
        AdapterOperationsWithMetadata GetWithMetadata(string operationName);
        AdapterOperationsWithMetadata GetWithMetadata(int operationID);
    }
}