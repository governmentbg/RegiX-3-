using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;

namespace TechnoLogica.RegiX.Admin.Repositories.Impl
{
    /// <summary>
    ///     Defines the <see cref="ApiServiceOperationLogRepository" />
    /// </summary>
    public class ApiServiceOperationLogRepository : ABaseRepository<ApiServiceOperationLog, decimal, RegiXContext>,
        IApiServiceOperationLogRepository
    {
        public ApiServiceOperationLogRepository(RegiXContext aDbContext)
            : base(aDbContext)
        {
        }

        /// <summary>
        ///     The SelectAll
        /// </summary>
        /// <returns>The <see cref="IQueryable{ApiServiceOperationLog}" /></returns>
        public override IQueryable<ApiServiceOperationLog> SelectAll()
        {
            return GetDbContext().Set<ApiServiceOperationLog>()
                .Include(r => r.ApiServiceOperation)
                .AsQueryable();
        }

        /// <summary>
        ///     The Select
        /// </summary>
        /// <param name="aId">The aId<see cref="decimal" /></param>
        /// <returns>The <see cref="ApiServiceOperationLog" /></returns>
        public override ApiServiceOperationLog Select(decimal aId)
        {
            return GetDbContext().Set<ApiServiceOperationLog>()
                .Include(r => r.ApiServiceOperation)
                .SingleOrDefault(r => r.ApiServiceOperationLogId == aId);
        }
    }
}