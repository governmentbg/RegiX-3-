using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;

namespace TechnoLogica.RegiX.Admin.Repositories.Impl
{
    /// <summary>
    ///     Defines the <see cref="AuditValuesRepository" />
    /// </summary>
    public class AuditValuesRepository : ABaseRepository<AuditValues, decimal, RegiXContext>, IAuditValuesRepository
    {
        public AuditValuesRepository(RegiXContext aDbContext)
            : base(aDbContext)
        {
        }

        /// <summary>
        ///     The SelectAll
        /// </summary>
        /// <returns>The <see cref="IQueryable{AuditValues}" /></returns>
        public override IQueryable<AuditValues> SelectAll()
        {
            return GetDbContext().Set<AuditValues>()
                .Include(r => r.AuditTable)
                .AsQueryable();
        }

        /// <summary>
        ///     The Select
        /// </summary>
        /// <param name="aId">The aId<see cref="decimal" /></param>
        /// <returns>The <see cref="AuditValues" /></returns>
        public override AuditValues Select(decimal aId)
        {
            return GetDbContext().Set<AuditValues>()
                .Include(r => r.AuditTable)
                .SingleOrDefault(r => r.Id == aId);
        }
    }
}