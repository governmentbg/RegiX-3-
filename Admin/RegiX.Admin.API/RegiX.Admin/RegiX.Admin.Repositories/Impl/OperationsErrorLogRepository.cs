using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;

namespace TechnoLogica.RegiX.Admin.Repositories.Impl
{
    /// <summary>
    ///     Defines the <see cref="OperationsErrorLogRepository" />
    /// </summary>
    public class OperationsErrorLogRepository : ABaseRepository<OperationsErrorLog, decimal, RegiXContext>,
        IOperationsErrorLogRepository
    {
        public OperationsErrorLogRepository(RegiXContext aDbContext)
            : base(aDbContext)
        {
        }

        /// <summary>
        ///     The SelectAll
        /// </summary>
        /// <returns>The <see cref="IQueryable{OperationsErrorLog}" /></returns>
        public override IQueryable<OperationsErrorLog> SelectAll()
        {
            return GetDbContext().Set<OperationsErrorLog>()
                .Include(r => r.AdapterOperation)
                .Include(r => r.ApiServiceCall)
                .Include(r => r.ApiServiceCall.ConsumerCertificate)
                .Include(r => r.ApiServiceCall.ConsumerCertificate.ApiServiceConsumer)
                .Include(r => r.ApiServiceCall.ConsumerCertificate.ApiServiceConsumer.Administration)
                .Include(r => r.ApiServiceCall.ApiServiceOperation.ApiService)
                .Include(r => r.ApiServiceOperation)
                .AsQueryable();
        }

        /// <summary>
        ///     The Select
        /// </summary>
        /// <param name="aId">The aId<see cref="decimal" /></param>
        /// <returns>The <see cref="OperationsErrorLog" /></returns>
        public override OperationsErrorLog Select(decimal aId)
        {
            return this.SelectAll()
                .SingleOrDefault(r => r.OperationsErrorLogId == aId);
        }
    }
}