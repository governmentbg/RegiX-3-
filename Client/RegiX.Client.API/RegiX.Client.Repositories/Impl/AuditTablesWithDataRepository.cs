using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Repositories.Contracts;

namespace TechnoLogica.RegiX.Client.Repositories.Impl
{
    public class AuditTablesWithDataRepository : ABaseRepository<AuditTables, int,RegiXClientContext>, IAuditTablesWithDataRepository
    {
        protected IUserContext UserContext { get; private set; }

        public AuditTablesWithDataRepository(RegiXClientContext aDbContext, IUserContext userContext)
            : base(aDbContext)
        {
            UserContext = userContext;
        }
        public override IQueryable<AuditTables> SelectAll()
        {
            var result = GetDbContext().Set<AuditTables>().AsNoTracking()
                .Include(a => a.Authority)
                .Include(a => a.User)
                .Include(a => a.AuditValues)
                .AsQueryable();
            result = this.UserContext.FilterByAuthority(result);
            return result;
        }

        public override AuditTables Select(int aId)
        {
            return SelectAll()
                .SingleOrDefault(a => a.Id == aId);
        }
    }
}