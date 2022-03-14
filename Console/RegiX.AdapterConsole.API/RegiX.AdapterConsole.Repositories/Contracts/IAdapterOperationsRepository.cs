using System.Linq;
using TechnoLogica.API.Repositories.Contracts;
using TechnoLogica.RegiX.AdapterConsole.Infrastructure.Models;

namespace TechnoLogica.RegiX.AdapterConsole.Repositories
{
    public interface IAdapterOperationsRepository : IBaseRepository<AdapterOperations, int, RegiXAdapterConsoleContext>
    {
        IQueryable<AdapterOperations> SelectByUser(int aId);
    }
}