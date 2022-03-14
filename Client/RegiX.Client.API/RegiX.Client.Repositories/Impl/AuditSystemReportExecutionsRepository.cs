using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Repositories.Contracts;

namespace TechnoLogica.RegiX.Client.Repositories.Impl
{
    public class AuditSystemReportExecutionsRepository : ABaseRepository<AuditSystemReportExecutions, int,RegiXClientContext>,
        IAuditSystemReportExecutionsRepository
    {
        public AuditSystemReportExecutionsRepository(RegiXClientContext aDbContext)
            : base(aDbContext)
        {
        }

        public override IQueryable<AuditSystemReportExecutions> SelectAll()
        {
            return GetDbContext().Set<AuditSystemReportExecutions>().AsNoTracking()
                .Include(r => r.AdapterOperation)
                .AsQueryable();
        }

        public override AuditSystemReportExecutions Select(int aId)
        {
            return SelectAll()
                .SingleOrDefault(r => r.Id == aId);
        }

       
    }
}