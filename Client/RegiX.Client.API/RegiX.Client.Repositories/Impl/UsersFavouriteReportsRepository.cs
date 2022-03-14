using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Repositories.Contracts;

namespace TechnoLogica.RegiX.Client.Repositories.Impl
{
    public class UsersFavouriteReportsRepository : ABaseRepository<UsersFavouriteReports, int, RegiXClientContext>,
        IUsersFavouriteReportRepository
    {
        protected IUserContext UserContext { get; private set; }

        public UsersFavouriteReportsRepository(RegiXClientContext aDbContext, IUserContext userContext)
            : base(aDbContext)
        {
            UserContext = userContext;
        }

        public override IQueryable<UsersFavouriteReports> SelectAll()
        {
            var result = GetDbContext().Set<UsersFavouriteReports>()
                .Include(ur => ur.User)
                .Include(ur => ur.Report)
                .Include(ur => ur.Report.AdapterOperation)
                .Include(ur => ur.Report.AdapterOperation.Register)
                .Include(ur => ur.Report.AdapterOperation.Register.Authority)
                .AsQueryable();

            result = UserContext.FilterByUser(result);

            return result;
        }

        public override UsersFavouriteReports Select(int aId)
        {
            return 
                this.SelectAll()
                .SingleOrDefault(ur => ur.Id == aId);
        }
    }
}