using TechnoLogica.API.Services;
using TechnoLogica.RegiX.AdapterConsole.DataContracts.ReturnedCalls;
using TechnoLogica.RegiX.AdapterConsole.Infrastructure.Models;

namespace TechnoLogica.RegiX.AdapterConsole.Services.Contracts
{
    public interface IReturnedCallsService : IBaseService<ReturnedCallsInDto, ReturnedCallsOutDto, ReturnedCalls, int
    >
    {
    }
}