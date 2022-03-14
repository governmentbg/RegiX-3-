using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Repositories.Contracts;

namespace TechnoLogica.RegiX.Client.Repositories.Impl
{
    public class AuditExceptionsRepository : ABaseRepository<AuditExceptions, int, RegiXClientContext>, IAuditExceptionsRepository
    {
        protected IUserContext UserContext { get; private set; }

        public AuditExceptionsRepository(RegiXClientContext aDbContext, IUserContext userContext)
            : base(aDbContext)
        {
            UserContext = userContext;
        }

        public override IQueryable<AuditExceptions> SelectAll()
        {
            var result =
             GetDbContext().Set<AuditExceptions>().AsNoTracking()
                .Include(r => r.Authority)
                .Include(r => r.User)
                .AsQueryable();
            
            result = this.UserContext.FilterByAuthority(result);

            return result;

        }

        public override AuditExceptions Select(int aId)
        {
            return SelectAll().SingleOrDefault(r => r.Id == aId);
        }
    }
}