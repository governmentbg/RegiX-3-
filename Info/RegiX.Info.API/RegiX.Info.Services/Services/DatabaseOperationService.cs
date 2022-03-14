using RegiX.Info.Infrastructure.Models;
using RegiX.Info.Repositories.Contracts;
using RegiX.Info.Services.Contracts;

namespace RegiX.Info.Services.Services
{
    public class DatabaseOperationService : IDatabaseOperationService
    {
        private readonly IDatabaseOperationRepository operationsRepository;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DatabaseOperationService" /> class.
        /// </summary>
        /// <param name="aRepo">The aRepo<see cref="IDatabaseOperationRepository" /></param>
        public DatabaseOperationService(IDatabaseOperationRepository aRepo)
        {
            operationsRepository = aRepo;
        }
        public ConsumerRequestOperationDb GetHierarchyByOperationId(decimal operationId)
        {
            return operationsRepository.GetHierarchyByOperationId(operationId);
        }
    }
}