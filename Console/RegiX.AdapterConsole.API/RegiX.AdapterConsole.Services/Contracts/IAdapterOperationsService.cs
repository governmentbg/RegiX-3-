using System.Linq;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.AdapterConsole.DataContracts.AdapterOperation;
using TechnoLogica.RegiX.AdapterConsole.Infrastructure.Models;

namespace TechnoLogica.RegiX.AdapterConsole.Services.Contracts
{
    public interface
        IAdapterOperationsService : IBaseService<AdapterOperationsInDto, AdapterOperationsOutDto, AdapterOperations, int
        >
    {
        IQueryable<AdapterOperations> GetUsersAdapterOperationsById(int userId);
    }
}