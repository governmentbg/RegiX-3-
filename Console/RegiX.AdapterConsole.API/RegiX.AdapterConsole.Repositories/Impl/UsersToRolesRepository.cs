using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.AdapterConsole.Infrastructure.Models;
using TechnoLogica.RegiX.AdapterConsole.Repositories.Contracts;

namespace TechnoLogica.RegiX.AdapterConsole.Repositories.Impl
{
    public class UsersToRolesRepository : ABaseRepository<AspNetUserRoles, int, RegiXAdapterConsoleContext>,
        IUsersToRolesRepository
    {
        public UsersToRolesRepository(RegiXAdapterConsoleContext aDbContext)
            : base(aDbContext)
        {
        }

        public void DeleteAllRoles(int userId)
        {
            GetDbContext().Database.ExecuteSqlCommand
            (
                $@"delete 
                from[dbo].[AspNetUserRoles]
                where UserId = {userId}"
            );
        }

        /// <summary>
        ///   The SelectAll
        /// </summary>
        /// <returns>The <see cref="IQueryable" /></returns>
        public override IQueryable<AspNetUserRoles> SelectAll()
        {
            return GetDbContext().Set<AspNetUserRoles>()
                .Include(u => u.User)
                .Include(r => r.Role)
                .AsQueryable();
        }

        /// <summary>
        ///   The Select
        /// </summary>
        /// <param name="aId">The aId<see cref="int" /></param>
        /// <returns>The <see cref="UsersToRoles" /></returns>
        public override AspNetUserRoles Select(int aId)
        {
            return SelectAll()
                .SingleOrDefault(r => r.RoleId == aId); //TODO: Is roleID ?
        }
    }
}