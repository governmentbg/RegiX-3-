using System.Threading.Tasks;

namespace EmailService.ReportingService
{
    public interface IReportingService
    {
        Task<byte[]> RunReport(string email);
    }
}