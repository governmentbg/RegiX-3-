using TechnoLogica.RegiX.Client.Repositories.Contracts.DatabaseOperations;
using TechnoLogica.RegiX.Client.Services.Contracts;

namespace TechnoLogica.RegiX.Client.Services.Services
{
    public class DatabaseOperationsService : IDatabaseOperationsService
    {
        private readonly IClearFavouriteReportsRepository clearReportsRepository;

        public DatabaseOperationsService(IClearFavouriteReportsRepository aRepo)
        {
            clearReportsRepository = aRepo;
        }

        public void ClearFavouriteReports()
        {
            clearReportsRepository.CallProcedure();
        }
    }
}