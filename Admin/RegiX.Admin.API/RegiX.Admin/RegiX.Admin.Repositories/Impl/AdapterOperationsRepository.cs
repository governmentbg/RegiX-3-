using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Admin.Infrastructure;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;

namespace TechnoLogica.RegiX.Admin.Repositories.Impl
{
    /// <summary>
    ///     Defines the <see cref="AdapterOperationsRepository" />
    /// </summary>
    public class AdapterOperationsRepository : ABaseRepository<AdapterOperations, decimal, RegiXContext>,
        IAdapterOperationsRepository
    {
        protected IUserContext UserContext { get; private set; }
        /// <summary>
        ///     Initializes a new instance of the <see cref="AdapterOperationsRepository" /> class.
        /// </summary>
        public AdapterOperationsRepository(RegiXContext aDbContext, IUserContext userContext)
            : base(aDbContext)
        {
            UserContext = userContext;
        }

        /// <summary>
        ///     The SelectAll
        /// </summary>
        /// <returns>The <see cref="IQueryable{AdapterOperations}" /></returns>
        public override IQueryable<AdapterOperations> SelectAll()
        {
            var result =
             GetDbContext().Set<AdapterOperations>()
                .Include(r => r.RegisterAdapter)
                .Include(r => r.RegisterObject)
                .AsQueryable();

            result = UserContext.FilterByAdministration(result,
                (r) => r.RegisterAdapter.Register.AdministrationId);

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