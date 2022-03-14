using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;

namespace TechnoLogica.RegiX.Admin.Repositories.Impl
{
    /// <summary>
    ///     Defines the <see cref="AdapterOperationLogRepository" />
    /// </summary>
    public class AdapterOperationLogRepository : ABaseRepository<AdapterOperationLog, decimal, RegiXContext>,
        IAdapterOperationLogRepository
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="AdapterOperationLogRepository" /> class.
        /// </summary>
        public AdapterOperationLogRepository(RegiXContext aDbContext)
            : base(aDbContext)
        {
        }

        /// <summary>
        ///     The SelectAll
        /// </summary>
        /// <returns>The <see cref="IQueryable{AdapterOperationLog}" /></returns>
        public override IQueryable<AdapterOperationLog> SelectAll()
        {
            return GetDbContext().Set<AdapterOperationLog>()
                .Include(r => r.AdapterOperation)
                .AsQueryable();
        }

        /// <summary>
        ///     The Select
        /// </summary>
        /// <param name="aId">The aId<see cref="decimal" /></param>
        /// <returns>The <see cref="AdapterOperationLog" /></returns>
        public override AdapterOperationLog Select(decimal aId)
        {
            return GetDbContext().Set<AdapterOperationLog>()
                .Include(r => r.AdapterOperation)
                .SingleOrDefault(r => r.AdapterOperationLogId == aId);
        }
    }
}