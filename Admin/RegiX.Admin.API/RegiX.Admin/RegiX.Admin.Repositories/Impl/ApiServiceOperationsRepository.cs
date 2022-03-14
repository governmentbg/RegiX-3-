using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;

namespace TechnoLogica.RegiX.Admin.Repositories.Impl
{
    /// <summary>
    ///     Defines the <see cref="ApiServiceOperationsRepository" />
    /// </summary>
    public class ApiServiceOperationsRepository : ABaseRepository<ApiServiceOperations, decimal, RegiXContext>,
        IApiServiceOperationsRepository
    {
        public ApiServiceOperationsRepository(RegiXContext aDbContext)
            : base(aDbContext)
        {
        }

        /// <summary>
        ///     The SelectAll
        /// </summary>
        /// <returns>The <see cref="IQueryable{ApiServiceOperations}" /></returns>
        public override IQueryable<ApiServiceOperations> SelectAll()
        {
            return GetDbContext().Set<ApiServiceOperations>()
                .Include(r => r.ApiService)
                .AsQueryable();
        }

        /// <summary>
        ///     The Select
        /// </summary>
        /// <param name="aId">The aId<see cref="decimal" /></param>
        /// <returns>The <see cref="ApiServiceOperations" /></returns>
        public override ApiServiceOperations Select(decimal aId)
        {
            return GetDbContext().Set<ApiServiceOperations>()
                .Include(r => r.ApiService)
                .SingleOrDefault(r => r.ApiServiceOperationId == aId);
        }
    }
}