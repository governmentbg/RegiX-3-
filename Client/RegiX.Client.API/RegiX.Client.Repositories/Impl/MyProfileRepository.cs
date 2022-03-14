using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Repositories.Contracts;

namespace TechnoLogica.RegiX.Client.Repositories.Impl
{
    public class MyProfileRepository : ABaseRepository<Users, int,RegiXClientContext>, IMyProfileRepository
    {
        private IUserContext UserContext { get; set; }

        public MyProfileRepository(RegiXClientContext aDbContext, IUserContext userContext) : base(aDbContext)
        {
            UserContext = userContext;
        }

        public override IQueryable<Users> SelectAll()
        {
            var result =
                GetDbContext().Set<Users>().AsNoTracking()
                    .Include(r => r.FederationUsers)
                    .Include(r => r.FederationUsers.UserAuthority)
                    .Include(r => r.FederationUsers.UsersEauth)
                    .AsQueryable();
            result = UserContext.FilterByAuthority(result, uc => uc.FederationUsers.UserAuthorityId);
            return result;
        }

        public override Users Select(int aId)
        {
            if (UserContext.IsPublic)
            {
                return base.Select(UserContext.UserId.Value);
            }
            else
            {
                return SelectAll()
                    .SingleOrDefault(r => r.Id == aId);
            }
        }
    }
}