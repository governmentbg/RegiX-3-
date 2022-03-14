using System.Collections.Generic;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Infrastructure.Models.DatabaseOperationService;
using TechnoLogica.RegiX.Admin.Infrastructure.Models.DatabaseOperationsModels;

namespace TechnoLogica.RegiX.Admin.Services.Contracts.DatabaseOperationsServicesInterfaces
{
    public interface IDatabaseOperationService
    {
        List<StatisticsOutput> CallStoredProcedure(StatisticsInput input);
        ConsumerRequestOperationDb GetHierarchyByOperationId(decimal operationId);
        List<GetElementConsumersViewOutput> CallGetElementConsumersProd(GetElementConsumersViewInput input);
        List<AccessReportFilterView> GenerateView();
    }
}