using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Admin.Infrastructure;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;

namespace TechnoLogica.RegiX.Admin.Repositories.Impl
{
    /// <summary>
    ///     Defines the <see cref="ApiServiceConsumersRepository" />
    /// </summary>
    public class ApiServiceConsumersRepository : ABaseRepository<ApiServiceConsumers, decimal, RegiXContext>,
        IApiServiceConsumersRepository
    {
        protected IUserContext UserContext { get; private set; }
        public ApiServiceConsumersRepository(RegiXContext aDbContext, IUserContext userContext)
            : base(aDbContext)
        {
            UserContext = userContext;
        }

        /// <summary>
        ///     The SelectAll
        /// </summary>
        /// <returns>The <see cref="IQueryable{ApiServiceConsumers}" /></returns>
        public override IQueryable<ApiServiceConsumers> SelectAll()
        {
            var result =
                 GetDbContext().Set<ApiServiceConsumers>()
                    .Include(r => r.Administration)
                    .AsQueryable();
                        
            return result;
        }

        /// <summary>
        ///     The Select
        /// </summary>
        /// <param name="aId">The aId<see cref="decimal" /></param>
        /// <returns>The <see cref="ApiServiceConsumers" /></returns>
        public override ApiServiceConsumers Select(decimal aId)
        {
            return this.SelectAll()
                .SingleOrDefault(r => r.ApiServiceConsumerId == aId);
        }
    }
}