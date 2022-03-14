using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;

namespace TechnoLogica.RegiX.Admin.Repositories.Impl
{
    /// <summary>
    ///     Defines the <see cref="ReportsRepository" />
    /// </summary>
    public class ReportsRepository : ABaseRepository<Reports, decimal, RegiXContext>, IReportsRepository
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ReportsRepository" /> class.
        /// </summary>
        public ReportsRepository(RegiXContext aDbContext) : base(aDbContext)
        {
        }

        /// <summary>
        ///     The SelectAll
        /// </summary>
        /// <returns>The <see cref="IQueryable{Reports}" /></returns>
        public override IQueryable<Reports> SelectAll()
        {
            return GetDbContext().Set<Reports>()
                .Include(r => r.ApiServiceOperation)
                .Include(r => r.ApiServiceConsumer)
                .AsQueryable();
        }

        /// <summary>
        ///     The Select
        /// </summary>
        /// <param name="aId">The aId<see cref="decimal" /></param>
        /// <returns>The <see cref="Reports" /></returns>
        public override Reports Select(decimal aId)
        {
            return GetDbContext().Set<Reports>()
                .Include(r => r.ApiServiceConsumer)
                .Include(r => r.ApiServiceOperation)
                .SingleOrDefault(r => r.ReportId == aId);
        }
    }
}