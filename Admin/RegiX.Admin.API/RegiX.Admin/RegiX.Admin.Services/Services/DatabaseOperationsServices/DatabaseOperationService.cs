using System.Collections.Generic;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Infrastructure.Models.DatabaseOperationService;
using TechnoLogica.RegiX.Admin.Infrastructure.Models.DatabaseOperationsModels;
using TechnoLogica.RegiX.Admin.Repositories.Contracts.DatabaseOperationsRepositoriesInterfaces;
using TechnoLogica.RegiX.Admin.Services.Contracts.DatabaseOperationsServicesInterfaces;

namespace TechnoLogica.RegiX.Admin.Services.Services.DatabaseOperationService
{
    /// <summary>
    ///     Defines the <see cref="DatabaseOperationService" />
    /// </summary>
    public class DatabaseOperationService : IDatabaseOperationService
    {
        /// <summary>
        ///     Defines the operationsRepository
        /// </summary>
        private readonly IDatabaseOperationRepository operationsRepository;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DatabaseOperationService" /> class.
        /// </summary>
        /// <param name="aRepo">The aRepo<see cref="IDatabaseOperationRepository" /></param>
        public DatabaseOperationService(IDatabaseOperationRepository aRepo)
        {
            operationsRepository = aRepo;
        }

        /// <summary>
        ///     The CallStoredProcedure
        /// </summary>
        /// <param name="input">The input<see cref="StatisticsInput" /></param>
        /// <returns>The <see cref="List{StatisticsOutput}" /></returns>
        public List<StatisticsOutput> CallStoredProcedure(StatisticsInput input)
        {
            return operationsRepository.CallProcedure(input);
        }

        public ConsumerRequestOperationDb GetHierarchyByOperationId(decimal operationId)
        {
            return operationsRepository.GetHierarchyByOperationId(operationId);
        }

        /// <summary>
        ///     The GenerateView
        /// </summary>
        /// <returns>The <see cref="List{GetElementConsumersViewOutput}" /></returns>
        public List<GetElementConsumersViewOutput> CallGetElementConsumersProd(GetElementConsumersViewInput input)
        {
            return operationsRepository.GetElementConsumersProd(input);
        }

        public List<AccessReportFilterView> GenerateView()
        {
            return operationsRepository.GenerateView();
        }
    }
}