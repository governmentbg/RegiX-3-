using System.Linq;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.AdapterConsole.Infrastructure.Models;
using TechnoLogica.RegiX.AdapterConsole.Repositories.Contracts;

namespace TechnoLogica.RegiX.AdapterConsole.Repositories.Impl
{
    public class RolesRepository : ABaseRepository<AspNetRoles, int, RegiXAdapterConsoleContext>,
        IRolesRepository
    {
        public RolesRepository(RegiXAdapterConsoleContext aDbContext)
            : base(aDbContext)
        {
        }

        /// <summary>
        ///   The SelectAll
        /// </summary>
        /// <returns>The <see cref="IQueryable" /></returns>
        public override IQueryable<AspNetRoles> SelectAll()
        {
            return GetDbContext().Set<AspNetRoles>()
                .AsQueryable();
        }

        /// <summary>
        ///   The Select
        /// </summary>
        /// <param name="aId">The aId<see cref="int" /></param>
        /// <returns>The <see cref="Roles" /></returns>
        public override AspNetRoles Select(int aId)
        {
            return SelectAll()
                .SingleOrDefault(r => r.Id == aId);
        }
    }
}