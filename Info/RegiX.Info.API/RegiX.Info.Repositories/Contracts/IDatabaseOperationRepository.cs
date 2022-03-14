using RegiX.Info.Infrastructure.Models;
using System.Collections.Generic;

namespace RegiX.Info.Repositories.Contracts
{
    public interface IDatabaseOperationRepository
    {
        List<Statistics> StatisticsProcedure(string timeFrame, bool showErrors);

        ConsumerRequestOperationDb GetHierarchyByOperationId(decimal operationId);

        int GetMonthRecords(int year, int month);
    }
}