using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.RoleToReport;
using TechnoLogica.RegiX.Client.Infrastructure.Models;

namespace TechnoLogica.RegiX.Client.Services.Contracts
{
    public interface IRoleToReportService : IBaseService<RoleToReportInDto, RoleToReportOutDto, RolesToReports, int>
    {
    }
}