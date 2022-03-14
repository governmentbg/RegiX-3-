using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Repositories.Contracts;

namespace TechnoLogica.RegiX.Client.Repositories.Impl
{
    public class AuditReportExecutionsRepository : ABaseRepository<AuditReportExecutions, int, RegiXClientContext>,
        IAuditReportExecutionsRepository
    {
        protected IUserContext UserContext { get; private set; }
        public AuditReportExecutionsRepository(RegiXClientContext aDbContext, IUserContext userContext) 
            : base(aDbContext)
        {
            UserContext = userContext;
        }
        public override IQueryable<AuditReportExecutions> SelectAll()
        {
            var result = GetDbContext().Set<AuditReportExecutions>()
                .AsNoTracking()
                .Include(a => a.Authority)
                .Include(a => a.Report)
                .Include(a => a.User)
                .AsQueryable();

            if (UserContext.IsAdmin)
            {
                result = this.UserContext.FilterByAuthority(result);
            }
            else if (!UserContext.IsGlobalAdmin)
            {
                result = this.UserContext.FilterByUser(result);
            }            

            return result;
        }

        public override AuditReportExecutions Select(int aId)
        {
            var res = SelectAll()
                .SingleOrDefault(a => a.Id == aId);
            if (UserContext.IsAdmin)
            {
                if (UserContext.AdministrationID != res.AuthorityId)
                {
                    return null;
                }
            }
            else if (!UserContext.IsGlobalAdmin)
            {
                if (UserContext.UserId != res.UserId)
                {
                    return null;
                }
            }
            return res;
        }
    }
}