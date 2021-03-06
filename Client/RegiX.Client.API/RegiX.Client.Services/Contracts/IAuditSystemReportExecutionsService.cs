using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.AuditSystemReportExecutions;
using TechnoLogica.RegiX.Client.Infrastructure.Models;

namespace TechnoLogica.RegiX.Client.Services.Contracts
{
    public interface IAuditSystemReportExecutionsService : IBaseService<AuditSystemReportExecutionsInDto,
        AuditSystemReportExecutionsOutDto, AuditSystemReportExecutions, int>
    {
    }
}