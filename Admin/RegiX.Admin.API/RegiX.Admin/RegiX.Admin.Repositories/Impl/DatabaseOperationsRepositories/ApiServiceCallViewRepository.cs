using Microsoft.EntityFrameworkCore;
using System.Linq;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Infrastructure.Models.DatabaseOperationsModels;
using TechnoLogica.RegiX.Admin.Repositories.Contracts.DatabaseOperationsRepositoriesInterfaces;

namespace TechnoLogica.RegiX.Admin.Repositories.Impl.DatabaseOperationsRepositories
{
    public class ApiServiceCallViewRepository : ABaseRepository<ApiServiceCallViewOutput, decimal, RegiXContext>,
        IApiServiceCallViewRepository
    {
        public ApiServiceCallViewRepository(RegiXContext aDbContext)
            : base(aDbContext)
        {
        }

        /// <summary>
        ///     The SelectAll
        /// </summary>
        /// <returns>The <see cref="IQueryable{ApiServiceCalls}" /></returns>
        public override IQueryable<ApiServiceCallViewOutput> SelectAll()
        {
            return GetDbContext()
               .Query<ApiServiceCallViewOutput>()
               .AsNoTracking()
               .AsQueryable();
        }


    }
}
