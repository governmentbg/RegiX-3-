using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;

namespace TechnoLogica.RegiX.Admin.Repositories.Impl
{
    /// <summary>
    ///     Defines the <see cref="RegisterObjectsRepository" />
    /// </summary>
    public class RegisterObjectsRepository : ABaseRepository<RegisterObjects, decimal, RegiXContext>,
        IRegisterObjectsRepository
    {
        public RegisterObjectsRepository(RegiXContext aDbContext) : base(aDbContext)
        {
        }

        /// <summary>
        ///     The SelectAll
        /// </summary>
        /// <returns>The <see cref="IQueryable{RegisterObjects}" /></returns>
        public override IQueryable<RegisterObjects> SelectAll()
        {
            return GetDbContext().Set<RegisterObjects>()
                .Include(r => r.RegisterAdapter)
                .AsQueryable();
        }

        /// <summary>
        ///     The Select
        /// </summary>
        /// <param name="aId">The aId<see cref="decimal" /></param>
        /// <returns>The <see cref="RegisterObjects" /></returns>
        public override RegisterObjects Select(decimal aId)
        {
            return GetDbContext().Set<RegisterObjects>()
                .Include(r => r.RegisterAdapter)
                .SingleOrDefault(r => r.RegisterObjectId == aId);
        }
    }
}