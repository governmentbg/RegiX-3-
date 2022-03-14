using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;

namespace TechnoLogica.RegiX.Admin.Repositories.Impl
{
    /// <summary>
    ///     Defines the <see cref="ApiServiceAdapterOperationsRepository" />
    /// </summary>
    public class ApiServiceAdapterOperationsRepository :
        ABaseRepository<ApiServiceAdapterOperations, decimal, RegiXContext>,
        IApiServiceAdapterOperationsRepository
    {
        public ApiServiceAdapterOperationsRepository(RegiXContext aDbContext)
            : base(aDbContext)
        {
        }

        /// <summary>
        ///     The SelectAll
        /// </summary>
        /// <returns>The <see cref="IQueryable{ApiServiceAdapterOperations}" /></returns>
        public override IQueryable<ApiServiceAdapterOperations> SelectAll()
        {
            var result = 
             GetDbContext().Set<ApiServiceAdapterOperations>()
                .Include(r => r.AdapterOperation)
                .Include(r => r.ApiServiceOperation)
                .AsQueryable();

            return result;
        }

        /// <summary>
        ///     The Select
        /// </summary>
        /// <param name="aId">The aId<see cref="decimal" /></param>
        /// <returns>The <see cref="ApiServiceAdapterOperations" /></returns>
        public override ApiServiceAdapterOperations Select(decimal aId)
        {
            return this.SelectAll()
                .SingleOrDefault(r => r.Id == aId);
        }
    }
}