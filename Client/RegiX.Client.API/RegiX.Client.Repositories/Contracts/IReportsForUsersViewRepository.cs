using TechnoLogica.API.Repositories.Contracts;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Infrastructure.Models.DatabaseObjectModels;

namespace TechnoLogica.RegiX.Client.Repositories.Contracts
{
    public interface IReportsForUsersViewRepository : IBaseRepository<ReportsForUsersView, int, RegiXClientContext>
    {
    }
}