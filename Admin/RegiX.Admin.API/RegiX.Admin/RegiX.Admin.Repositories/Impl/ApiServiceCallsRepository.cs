using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;

namespace TechnoLogica.RegiX.Admin.Repositories.Impl
{
    /// <summary>
    ///     Defines the <see cref="ApiServiceCallsRepository" />
    /// </summary>
    public class ApiServiceCallsRepository : ABaseRepository<ApiServiceCalls, decimal, RegiXContext>,
        IApiServiceCallsRepository
    {
        public ApiServiceCallsRepository(RegiXContext aDbContext)
            : base(aDbContext)
        {
        }
        //TODO: will need more special filtration ?

        /// <summary>
        ///     The SelectAll
        /// </summary>
        /// <returns>The <see cref="IQueryable{ApiServiceCalls}" /></returns>
        public override IQueryable<ApiServiceCalls> SelectAll()
        {
            return GetDbContext().Set<ApiServiceCalls>()
                .Include(r => r.ApiServiceOperation)
                .Include(r => r.ConsumerCertificate)
                .AsQueryable();
        }

        /// <summary>
        ///     The Select
        /// </summary>
        /// <param name="aId">The aId<see cref="decimal" /></param>
        /// <returns>The <see cref="ApiServiceCalls" /></returns>
        public override ApiServiceCalls Select(decimal aId)
        {
            return GetDbContext().Set<ApiServiceCalls>()
                .Include(r => r.ApiServiceOperation)
                .Include(r => r.ConsumerCertificate)
                .SingleOrDefault(r => r.ApiServiceCallId == aId);
        }
    }
}