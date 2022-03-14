using TechnoLogica.API.Repositories.Contracts;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Repositories.Contracts;
using TechnoLogica.RegiX.Client.Services.Contracts;

namespace TechnoLogica.RegiX.Client.Services.Services
{
    public abstract class ABaseClearReportsService<S, U, V> : ABaseService<S, U, V, int, RegiXClientContext>
        where V : class
    {
        protected IDatabaseOperationsService databaseOperationsService;

        protected IUsersFavouriteReportRepository favouriteReportRepository;
        protected IReportsForUsersViewRepository reportsForUserRepository;

        protected ABaseClearReportsService(IBaseRepository<V, int,RegiXClientContext> aBaseRepository,
            IUsersFavouriteReportRepository aFavouriteReportsRepository,
            IReportsForUsersViewRepository aReportsForUserRepository,
            IDatabaseOperationsService aDatabaseOperationsService)
            : base(aBaseRepository)
        {
            favouriteReportRepository = aFavouriteReportsRepository;
            reportsForUserRepository = aReportsForUserRepository;

            databaseOperationsService = aDatabaseOperationsService;
        }

        protected void ClearFavouriteReports()
        {
            databaseOperationsService.ClearFavouriteReports();
        }
    }
}