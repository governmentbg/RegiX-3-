using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;

namespace TechnoLogica.RegiX.Admin.Repositories.Impl
{
    /// <summary>
    ///     Defines the <see cref="AuditTablesWithDataRepository" />
    /// </summary>
    public class AuditTablesWithDataRepository : ABaseRepository<AuditTables, decimal, RegiXContext>,
        IAuditTablesWithDataRepository
    {
        public AuditTablesWithDataRepository(RegiXContext aDbContext)
            : base(aDbContext)
        {
        }

        public override IQueryable<AuditTables> SelectAll()
        {
            return GetDbContext().Set<AuditTables>()
                .Include(r => r.AuditValues)
                .AsQueryable();
        }

        public override AuditTables Select(decimal aId)
        {
            return GetDbContext().Set<AuditTables>()
                .Include(r => r.AuditValues)
                .SingleOrDefault(r => r.Id == aId);
        }
    }
}