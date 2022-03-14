using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerCertificatesReport;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Services.Contracts
{
    public interface IConsumerCertificatesReportService : IBaseService<ConsumerCertificatesReportInDto,
        ConsumerCertificatesReportOutDto, ConsumerCertificatesReports, decimal>
    {
    }
}