using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Repositories.Contracts;

namespace TechnoLogica.RegiX.Client.Repositories.Impl
{
    public class AuditValuesRepository : ABaseRepository<AuditValues, int,RegiXClientContext>, IAuditValuesRepository
    {
        public override IQueryable<AuditValues> SelectAll()
        {
            return GetDbContext().Set<AuditValues>().AsNoTracking()
                .Include(r => r.AuditTable)
                .AsQueryable();
        }

        public override AuditValues Select(int aId)
        {
            return SelectAll()
                .SingleOrDefault(r => r.Id == aId);
        }

        public AuditValuesRepository(RegiXClientContext aDbContext) : base(aDbContext)
        {
        }
    }
}