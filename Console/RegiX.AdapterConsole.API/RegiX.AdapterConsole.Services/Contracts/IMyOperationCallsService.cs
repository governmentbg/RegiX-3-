using TechnoLogica.API.Services;
using TechnoLogica.RegiX.AdapterConsole.DataContracts.OperationCalls;
using TechnoLogica.RegiX.AdapterConsole.Infrastructure.Models;

namespace TechnoLogica.RegiX.AdapterConsole.Services.Contracts
{
    public interface
        IMyOperationCallsService : IBaseService<MyOperationCallsInDto, MyOperationCallsOutDto, OperationCalls, int>
    {
        void Update(int aId, int assignedToId, string xmlParams);

        void SaveToReturnedCalls(int aId, int assignedToId, string xmlParams);
    }
}