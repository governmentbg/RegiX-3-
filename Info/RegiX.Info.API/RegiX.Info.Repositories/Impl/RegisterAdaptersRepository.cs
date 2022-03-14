using System.Linq;
using Microsoft.EntityFrameworkCore;
using RegiX.Info.Infrastructure.Models;
using RegiX.Info.Repositories.Contracts;
using TechnoLogica.API.Repositories.Impl;

namespace RegiX.Info.Repositories.Impl
{
    public class RegisterAdaptersRepository : ABaseRepository<RegisterAdapters, decimal, RegiXContext>,
        IRegisterAdaptersRepository
    {
        public RegisterAdaptersRepository(RegiXContext aDbContext) 
            : base(aDbContext)
        {
        }

        /// <summary>
        ///     The SelectAll
        /// </summary>
        /// <returns>The <see cref="IQueryable" /></returns>
        public override IQueryable<RegisterAdapters> SelectAll()
        {
            var result =
                GetDbContext().Set<RegisterAdapters>()
                    .Include(r => r.Register)
                    .AsQueryable();
            return result;
        }

        /// <summary>
        ///     The Select
        /// </summary>
        /// <param name="aId">The aId<see cref="decimal" /></param>
        /// <returns>The <see cref="RegisterAdapters" /></returns>
        public override RegisterAdapters Select(decimal aId)
        {
            return this.SelectAll()
                .SingleOrDefault(r => r.RegisterAdapterId == aId);
        }
    }
}