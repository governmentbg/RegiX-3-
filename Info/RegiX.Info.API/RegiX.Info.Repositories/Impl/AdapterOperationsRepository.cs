using System.Linq;
using Microsoft.EntityFrameworkCore;
using RegiX.Info.Infrastructure.Models;
using RegiX.Info.Repositories.Contracts;
using TechnoLogica.API.Repositories.Impl;

namespace RegiX.Info.Repositories.Impl
{
    public class AdapterOperationsRepository : ABaseRepository<AdapterOperations, decimal, RegiXContext>,
        IAdapterOperationsRepository
    {
        public AdapterOperationsRepository(RegiXContext aDbContext) 
            : base(aDbContext)
        {
        }

        /// <summary>
        ///     The SelectAll
        /// </summary>
        /// <returns>The <see cref="IQueryable" /></returns>
        public override IQueryable<AdapterOperations> SelectAll()
        {
            var result =
                GetDbContext().Set<AdapterOperations>()
                    .Include(r => r.RegisterAdapter)
                    .Include(r => r.RegisterObject)
                    .AsQueryable();

            return result;
        }

        /// <summary>
        ///     The Select
        /// </summary>
        /// <param name="aId">The aId<see cref="decimal" /></param>
        /// <returns>The <see cref="AdapterOperations" /></returns>
        public override AdapterOperations Select(decimal aId)
        {
            return this.SelectAll()
                .SingleOrDefault(r => r.AdapterOperationId == aId);
        }
    }
}