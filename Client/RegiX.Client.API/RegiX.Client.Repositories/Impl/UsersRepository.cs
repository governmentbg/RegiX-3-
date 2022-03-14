using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Repositories.Contracts;

namespace TechnoLogica.RegiX.Client.Repositories.Impl
{
    public class UsersRepository : ABaseRepository<Users, int,RegiXClientContext>, IUsersRepository
    {
        private IUserContext UserContext { get; set; }

        public UsersRepository(
            RegiXClientContext aDbContext, 
            IUserContext userContext)
            : base(aDbContext)
        {
            UserContext = userContext;
        }
        public override IQueryable<Users> SelectAll()
        {
            var result = 
                GetDbContext().Set<Users>().AsNoTracking()
                .Include(r => r.FederationUsers)
                .Include(r => r.FederationUsers.UserAuthority)
                .Include(r => r.PublicUsers)
                .Include(r => r.UsersToRoles).ThenInclude(x => x.Role)
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

        public override Users Delete(int aId)
        {
            var repoObj = GetDbContext()
                .Set<Users>()
                .Include(ur => ur.UsersToRoles)
                .Include(ur => ur.UsersToReports)
                .Include(ur => ur.UsersFavouriteReports)
                .Include(ur => ur.FederationUsers).ThenInclude(ur => ur.LocalUsers)
                .Include(ur => ur.FederationUsers).ThenInclude(ur => ur.UsersEauth)
                .FirstOrDefault(u => u.Id == aId);
            if (repoObj == null)
            {
                throw new Exception("Object with id [" + aId + "] not found!");
            }
            GetDbContext().Remove(repoObj);
            return repoObj;        }
    }
}