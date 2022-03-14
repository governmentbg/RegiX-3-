using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;

namespace TechnoLogica.RegiX.Admin.Repositories.Impl
{
    /// <summary>
    ///     Defines the <see cref="ParametersValuesLogRepository" />
    /// </summary>
    public class ParametersValuesLogRepository : ABaseRepository<ParametersValuesLog, decimal, RegiXContext>,
        IParametersValuesLogRepository
    {
        public ParametersValuesLogRepository(RegiXContext aDbContext)
            : base(aDbContext)
        {
        }

        /// <summary>
        ///     The SelectAll
        /// </summary>
        /// <returns>The <see cref="IQueryable{ParametersValuesLog}" /></returns>
        public override IQueryable<ParametersValuesLog> SelectAll()
        {
            return GetDbContext().Set<ParametersValuesLog>()
                .Include(r => r.RegisterAdapter)
                .Include(r => r.User)
                .AsQueryable();
        }

        /// <summary>
        ///     The Select
        /// </summary>
        /// <param name="aId">The aId<see cref="decimal" /></param>
        /// <returns>The <see cref="ParametersValuesLog" /></returns>
        public override ParametersValuesLog Select(decimal aId)
        {
            return GetDbContext().Set<ParametersValuesLog>()
                .Include(r => r.RegisterAdapter)
                .Include(r => r.User)
                .SingleOrDefault(r => r.Id == aId);
        }
    }
}