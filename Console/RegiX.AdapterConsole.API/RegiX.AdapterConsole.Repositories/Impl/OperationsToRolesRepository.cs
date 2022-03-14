using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.AdapterConsole.Infrastructure.Models;
using TechnoLogica.RegiX.AdapterConsole.Repositories.Contracts;

namespace TechnoLogica.RegiX.AdapterConsole.Repositories.Impl
{
    public class OperationsToRolesRepository : ABaseRepository<OperationsToRoles, int, RegiXAdapterConsoleContext>,
        IOperationsToRolesRepository
    {
        public OperationsToRolesRepository(RegiXAdapterConsoleContext aDbContext)
            : base(aDbContext)
        {
        }

        /// <summary>
        ///   The SelectAll
        /// </summary>
        /// <returns>The <see cref="IQueryable{T}" /></returns>
        public override IQueryable<OperationsToRoles> SelectAll()
        {
            return GetDbContext().Set<OperationsToRoles>()
                .Include(r => r.Role)
                .Include(r => r.AdapterOperation)
                .AsQueryable();
        }

        /// <summary>
        ///   The Select
        /// </summary>
        /// <param name="aId">The aId<see cref="int" /></param>
        /// <returns>The <see cref="OperationsToRoles" /></returns>
        public override OperationsToRoles Select(int aId)
        {
            return SelectAll()
                .SingleOrDefault(r => r.Id == aId);
        }
    }
}