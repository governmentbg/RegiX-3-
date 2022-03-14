using System.Collections.Generic;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Infrastructure.Models.DatabaseOperationService;
using TechnoLogica.RegiX.Admin.Infrastructure.Models.DatabaseOperationsModels;

namespace TechnoLogica.RegiX.Admin.Repositories.Contracts.DatabaseOperationsRepositoriesInterfaces
{
    public interface IDatabaseOperationRepository
    {
        List<StatisticsOutput> CallProcedure(StatisticsInput input);

        ConsumerRequestOperationDb GetHierarchyByOperationId(decimal operationId);
        List<GetElementConsumersViewOutput> GetElementConsumersProd(GetElementConsumersViewInput input);
        List<AccessReportFilterView> GenerateView();
    }
}