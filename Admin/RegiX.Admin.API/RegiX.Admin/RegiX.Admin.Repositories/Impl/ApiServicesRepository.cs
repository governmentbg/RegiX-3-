using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Admin.Infrastructure;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;

namespace TechnoLogica.RegiX.Admin.Repositories.Impl
{
    /// <summary>
    ///     Defines the <see cref="ApiServicesRepository" />
    /// </summary>
    public class ApiServicesRepository : ABaseRepository<ApiServices, decimal, RegiXContext>, IApiServicesRepository
    {
        protected IUserContext UserContext { get; private set; }
        public ApiServicesRepository(RegiXContext aDbContext, IUserContext userContext)
            : base(aDbContext)
        {
            UserContext = userContext;
        }

        /// <summary>
        ///     The SelectAll
        /// </summary>
        /// <returns>The <see cref="IQueryable{ApiServices}" /></returns>
        public override IQueryable<ApiServices> SelectAll()
        {
            var result =
                    GetDbContext().Set<ApiServices>()
                        .Include(r => r.Administration)
                        .AsQueryable();

            result = this.UserContext.FilterByAdministration(result);
            
            return result;
        }

        /// <summary>
        ///     The Select
        /// </summary>
        /// <param name="aId">The aId<see cref="decimal" /></param>
        /// <returns>The <see cref="ApiServices" /></returns>
        public override ApiServices Select(decimal aId)
        {
            return this.SelectAll()
                .SingleOrDefault(r => r.ApiServiceId == aId);
        }
    }
}