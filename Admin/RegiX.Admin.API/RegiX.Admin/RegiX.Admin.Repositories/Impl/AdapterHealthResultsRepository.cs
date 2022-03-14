using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Admin.Infrastructure;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;

namespace TechnoLogica.RegiX.Admin.Repositories.Impl
{
    /// <summary>
    ///     Defines the <see cref="AdapterHealthResultsRepository" />
    /// </summary>
    public class AdapterHealthResultsRepository : ABaseRepository<AdapterHealthResults, decimal, RegiXContext>,
        IAdapterHealthResultsRepository
    {
        protected IUserContext UserContext { get; private set; }
        /// <summary>
        ///     Initializes a new instance of the <see cref="AdapterHealthResultsRepository" /> class.
        /// </summary>
        public AdapterHealthResultsRepository(RegiXContext aDbContext, IUserContext userContext)
            : base(aDbContext)
        {
            UserContext = userContext;
        }

        /// <summary>
        ///     The SelectAll
        /// </summary>
        /// <returns>The <see cref="IQueryable{AdapterHealthResults}" /></returns>
        public override IQueryable<AdapterHealthResults> SelectAll()
        {
            var result = GetDbContext().Set<AdapterHealthResults>()
                .Include(r => r.RegisterAdapter)
                .Include(r => r.AdapterHealthFunction)
                .AsQueryable();

            result = this.UserContext
                .FilterByAdministration(result, r => r.RegisterAdapter.Register.AdministrationId);

            return result;
        }

        /// <summary>
        ///     The Select
        /// </summary>
        /// <param name="aId">The aId<see cref="decimal" /></param>
        /// <returns>The <see cref="AdapterHealthResults" /></returns>
        public override AdapterHealthResults Select(decimal aId)
        {
            return this.SelectAll()
                .SingleOrDefault(r => r.AdapterHealthResultId == aId);
        }
    }
}