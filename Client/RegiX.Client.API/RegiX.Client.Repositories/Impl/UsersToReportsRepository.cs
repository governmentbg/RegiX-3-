using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Repositories.Contracts;

namespace TechnoLogica.RegiX.Client.Repositories.Impl
{
    public class UsersToReportsRepository : ABaseRepository<UsersToReports, int,RegiXClientContext>, IUsersToReportsRepository
    {
        protected IUserContext UserContext { get; private set; }

        public UsersToReportsRepository(RegiXClientContext aDbContext, IUserContext userContext)
            : base(aDbContext)
        {
            UserContext = userContext;
        }
        public override IQueryable<UsersToReports> SelectAll()
        {
            var result = GetDbContext().Set<UsersToReports>()
                .Include(ur => ur.User)
                .Include(ur => ur.User.FederationUsers)
                .Include(ur => ur.Report)
                .AsQueryable();

           //result = this.UserContext.FilterByUser(result);

            return result;
        }

        public override UsersToReports Select(int aId)
        {
            return this.SelectAll()
                .SingleOrDefault(ur => ur.Id == aId);
        }
    }
}