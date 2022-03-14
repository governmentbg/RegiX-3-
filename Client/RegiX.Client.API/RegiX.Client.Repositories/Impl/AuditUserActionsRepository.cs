using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Repositories.Contracts;

namespace TechnoLogica.RegiX.Client.Repositories.Impl
{
    public class AuditUserActionsRepository : ABaseRepository<AuditUserActions, int, RegiXClientContext>, IAuditUserActionsRepository
    {
        protected IUserContext UserContext { get; private set; }

        public AuditUserActionsRepository(RegiXClientContext aDbContext, IUserContext userContext) 
            : base(aDbContext)
        {
            UserContext = userContext;
        }
        public override IQueryable<AuditUserActions> SelectAll()
        {
            var result = GetDbContext().Set<AuditUserActions>()
                .AsNoTracking()
                .Include(x => x.Authority)
                .Include(x => x.User)
                .AsQueryable();

            result = this.UserContext.FilterByAuthority(result);

            return result;
        }

        public override AuditUserActions Select(int aId)
        {
            return SelectAll().SingleOrDefault(r => r.Id == aId);
        }
    }
}