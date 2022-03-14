using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Repositories.Contracts;

namespace TechnoLogica.RegiX.Client.Repositories.Impl
{
    public class AsyncReportExecutionsRepository : ABaseRepository<AsyncReportExecutions, int, RegiXClientContext>, IAsyncReportExecutionsRepository
    {
        protected IUserContext UserContext { get; private set; }

        public AsyncReportExecutionsRepository(RegiXClientContext aDbContext, IUserContext userContext)
            : base(aDbContext)
        {
            UserContext = userContext;
        }

        public override IQueryable<AsyncReportExecutions> SelectAll()
        {
            var queryable = 
                GetDbContext().Set<AsyncReportExecutions>().AsNoTracking()
                .Include(r => r.AdapterOperation)
                .AsQueryable();
            queryable = UserContext.FilterByUser(queryable);
            return queryable;
        }
        public virtual AsyncReportExecutions FindByServiceCallId(decimal apiServiceCallId, string verificationCode)
        {
            var result =
                GetDbContext().Set<AsyncReportExecutions>().AsNoTracking()
                .Include( r => r.AdapterOperation )
                .Where( 
                    r => r.ApiServiceCallId == apiServiceCallId &&
                         r.VerificationCode == verificationCode
                 )
                .FirstOrDefault();
            return result;
        }

        public override AsyncReportExecutions Select(int aId)
        {
            var res = this.GetDbContext().Set<AsyncReportExecutions>().AsNoTracking().Single(a => a.Id == aId);
            if (res.UserId != UserContext.UserId)
            {
                throw new ArgumentException("This async execution result belongs to different user!");
            }
            return res;
        }
    }
}
