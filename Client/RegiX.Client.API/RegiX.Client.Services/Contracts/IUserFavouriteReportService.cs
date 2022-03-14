using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.UserToReport;
using TechnoLogica.RegiX.Client.Infrastructure.Models;

namespace TechnoLogica.RegiX.Client.Services.Contracts
{
    public interface IUserFavouriteReportService : IBaseService<UsersFavouriteReportInDto,
        UsersFavouriteReportOutDto, UsersFavouriteReports, int>
    {
        void ChangeReportFavouriteStatus(int reportId, bool favourite);
    }
}