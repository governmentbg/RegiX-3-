using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.ReportsForUsersView;
using TechnoLogica.RegiX.Client.Infrastructure.Models.DatabaseObjectModels;

namespace TechnoLogica.RegiX.Client.Services.Contracts
{
    public interface IReportsForUsersService : IBaseService<ReportsForUsersViewInDto, ReportsForUsersViewOutDto,
        ReportsForUsersView, int>
    {
    }
}