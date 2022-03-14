using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Repositories.Contracts;

namespace TechnoLogica.RegiX.Client.Repositories.Impl
{
    public class UsersToRolesRepository : ABaseRepository<UsersToRoles, int,RegiXClientContext>, IUsersToRolesRepository
    {
        protected IUserContext UserContext { get; private set; }

        public UsersToRolesRepository(RegiXClientContext aDbContext, IUserContext userContext) 
            : base(aDbContext)
        {
            UserContext = userContext;
        }

        public override IQueryable<UsersToRoles> SelectAll()
        {
            var result = GetDbContext().Set<UsersToRoles>()
                .Include(ur => ur.User)
                .Include(ur => ur.User.FederationUsers)
                .Include(ur => ur.Role)
                .AsQueryable();

            //result = this.UserContext.FilterByUser(result);

            return result;
        }

        public override UsersToRoles Select(int aId)
        {
            return this.SelectAll()
                .SingleOrDefault(ur => ur.Id == aId);
        }
    }
}