using TechnoLogica.API.Services;
using TechnoLogica.RegiX.AdapterConsole.DataContracts.OperationCalls;
using TechnoLogica.RegiX.AdapterConsole.Infrastructure.Models;

namespace TechnoLogica.RegiX.AdapterConsole.Services.Contracts
{
    public interface
        IOperationCallsService : IBaseService<OperationCallsInDto, OperationCallsOutDto, OperationCalls, int>
    {
        void Update(int aId, int? assignedToId);
        void Update(int aId, int? assignedToId, string xmlParams);
        void SaveToReturnedCalls(int aId, int assignedToId, string xmlParams);
    }
}