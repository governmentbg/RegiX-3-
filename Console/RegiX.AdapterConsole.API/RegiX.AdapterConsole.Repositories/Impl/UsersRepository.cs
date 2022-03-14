using System.Linq;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.AdapterConsole.Infrastructure.Models;
using TechnoLogica.RegiX.AdapterConsole.Repositories.Contracts;

namespace TechnoLogica.RegiX.AdapterConsole.Repositories.Impl
{
    public class UsersRepository : ABaseRepository<AspNetUsers, int, RegiXAdapterConsoleContext>,
        IUsersRepository
    {
        public UsersRepository(RegiXAdapterConsoleContext aDbContext)
            : base(aDbContext)
        {
        }

        /// <summary>
        ///   The SelectAll
        /// </summary>
        /// <returns>The <see cref="IQueryable{AuditValues}" /></returns>
        public override IQueryable<AspNetUsers> SelectAll()
        {
            return GetDbContext().Set<AspNetUsers>()
                .AsQueryable();
        }

        /// <summary>
        ///   The Select
        /// </summary>
        /// <param name="aId">The aId<see cref="int" /></param>
        /// <returns>The <see cref="Users" /></returns>
        public override AspNetUsers Select(int aId)
        {
            return SelectAll()
                .SingleOrDefault(r => r.Id == aId);
        }
    }
}