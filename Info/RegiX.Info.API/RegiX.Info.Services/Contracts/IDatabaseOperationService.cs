using RegiX.Info.Infrastructure.Models;

namespace RegiX.Info.Services.Contracts
{
    public interface IDatabaseOperationService
    {
        ConsumerRequestOperationDb GetHierarchyByOperationId(decimal operationId);
    }
}