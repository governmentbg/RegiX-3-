using TechnoLogica.API.Repositories.Contracts;
using TechnoLogica.RegiX.AdapterConsole.Infrastructure.Models;

namespace TechnoLogica.RegiX.AdapterConsole.Repositories.Contracts
{
    public interface IReturnedCallsRepository : IBaseRepository<ReturnedCalls, int, RegiXAdapterConsoleContext>
    {
    }
}