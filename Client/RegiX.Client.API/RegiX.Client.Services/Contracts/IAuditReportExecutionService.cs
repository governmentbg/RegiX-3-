using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.AuditReportExecution;
using TechnoLogica.RegiX.Client.Infrastructure.Models;

namespace TechnoLogica.RegiX.Client.Services.Contracts
{
    public interface IAuditReportExecutionService : IBaseService<AuditReportExecutionInDto, AuditReportExecutionOutDto,
        AuditReportExecutions, int>
    {
        AuditReportExecutionWithResultOutDto ReaderReportExecution(int aId);
    }
}