using TechnoLogica.API.Repositories.Contracts;
using TechnoLogica.RegiX.AdapterConsole.Infrastructure.Models;

namespace TechnoLogica.RegiX.AdapterConsole.Repositories.Contracts
{
    public interface IOperationCallsRepository : IBaseRepository<OperationCalls, int, RegiXAdapterConsoleContext>
    {
    }
}