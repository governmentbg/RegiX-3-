using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Admin.Infrastructure;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;

namespace TechnoLogica.RegiX.Admin.Repositories.Impl
{
    /// <summary>
    ///     Defines the <see cref="AdapterHealthFunctionsRepository" />
    /// </summary>
    public class AdapterHealthFunctionsRepository : ABaseRepository<AdapterHealthFunctions, decimal, RegiXContext>,
        IAdapterHealthFunctionsRepository
    {
        protected IUserContext UserContext { get; private set; }

        public AdapterHealthFunctionsRepository(RegiXContext aDbContext, IUserContext userContext)
            : base(aDbContext)
        {
            UserContext = userContext;
        }

        /// <summary>
        ///     The SelectAll
        /// </summary>
        /// <returns>The <see cref="IQueryable{AdapterHealthFunctions}" /></returns>
        public override IQueryable<AdapterHealthFunctions> SelectAll()
        {
            var result = GetDbContext().Set<AdapterHealthFunctions>()
                .Include(r => r.RegisterAdapter)
                .AsQueryable();

            result = this.UserContext
                .FilterByAdministration(result, r => r.RegisterAdapter.Register.AdministrationId);

            return result;
        }

        /// <summary>
        ///     The Select
        /// </summary>
        /// <param name="aId">The aId<see cref="decimal" /></param>
        /// <returns>The <see cref="AdapterHealthFunctions" /></returns>
        public override AdapterHealthFunctions Select(decimal aId)
        {
            return this.SelectAll()
                .SingleOrDefault(r => r.AdapterHealthFunctionId == aId);
        }
    }
}