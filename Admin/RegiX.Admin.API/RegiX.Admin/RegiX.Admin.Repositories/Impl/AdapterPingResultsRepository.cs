using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Admin.Infrastructure;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;

namespace TechnoLogica.RegiX.Admin.Repositories.Impl
{
    /// <summary>
    ///     Defines the <see cref="AdapterPingResultsRepository" />
    /// </summary>
    public class AdapterPingResultsRepository : ABaseRepository<AdapterPingResults, decimal, RegiXContext>,
        IAdapterPingResultsRepository
    {
        protected IUserContext UserContext { get; private set; }
        /// <summary>
        ///     Initializes a new instance of the <see cref="AdapterPingResultsRepository" /> class.
        /// </summary>
        public AdapterPingResultsRepository(RegiXContext aDbContext, IUserContext userContext)
            : base(aDbContext)
        {
            UserContext = userContext;
        }

        /// <summary>
        ///     The SelectAll
        /// </summary>
        /// <returns>The <see cref="IQueryable{AdapterPingResults}" /></returns>
        public override IQueryable<AdapterPingResults> SelectAll()
        {
            var result = 
             GetDbContext().Set<AdapterPingResults>()
                .Include(r => r.RegisterAdapter)
                .AsQueryable();

            result = UserContext.FilterByAdministration(result,
                (r) => r.RegisterAdapter.Register.AdministrationId);

            return result;
        }

        /// <summary>
        ///     The Select
        /// </summary>
        /// <param name="aId">The aId<see cref="decimal" /></param>
        /// <returns>The <see cref="AdapterPingResults" /></returns>
        public override AdapterPingResults Select(decimal aId)
        {
            return this.SelectAll()
                .SingleOrDefault(r => r.AdapterPingResultId == aId);
        }
    }
}