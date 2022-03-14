using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.UserToReport;
using TechnoLogica.RegiX.Client.Infrastructure.Models;

namespace TechnoLogica.RegiX.Client.Services.Contracts
{
    public interface IUserToReportService : IBaseService<UserToReportInDto, UserToReportOutDto, UsersToReports, int>
    {
    }
}