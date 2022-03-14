using System.Threading.Tasks;

namespace RegiX.Info.Services.Contracts
{
    public interface IReportingService
    {
        Task<byte[]> RunReport(string ProfileId);
        Task<byte[]> RunFullReport(string userId, string ConsumerRequestId);
    }
}