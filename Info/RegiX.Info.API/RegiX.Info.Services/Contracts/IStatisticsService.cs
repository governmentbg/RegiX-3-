using RegiX.Info.Infrastructure.Models;

namespace RegiX.Info.Services.Contracts
{
    public interface IStatisticsService
    {
        Records CallStatisticsProcedure(string timeFrame, bool showErrors);
        int GetMonthRecords(string yearMonth);
    }
}