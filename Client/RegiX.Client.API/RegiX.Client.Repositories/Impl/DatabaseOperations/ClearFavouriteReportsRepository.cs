using Microsoft.EntityFrameworkCore;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Repositories.Contracts.DatabaseOperations;

namespace TechnoLogica.RegiX.Client.Repositories.Impl.DatabaseOperations
{
    public class ClearFavouriteReportsRepository : IClearFavouriteReportsRepository
    {
        protected readonly RegiXClientContext _dbContext;

        public ClearFavouriteReportsRepository(RegiXClientContext aDbContext)
        {
            _dbContext = aDbContext;
        }

        public void CallProcedure()
        {
            // TODO maybe return the deleted reports?
            //return this._dbContext.ClearFavouriteReports.FromSql("EXECUTE ClearFavouriteReports").ToList();

            _dbContext.Database.ExecuteSqlCommand("ClearFavouriteReports");
            _dbContext.SaveChanges();
        }
    }
}