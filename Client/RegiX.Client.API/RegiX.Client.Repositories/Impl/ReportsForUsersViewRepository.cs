using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Infrastructure.Models.DatabaseObjectModels;
using TechnoLogica.RegiX.Client.Repositories.Contracts;

namespace TechnoLogica.RegiX.Client.Repositories.Impl
{
    public class ReportsForUsersViewRepository : ABaseRepository<ReportsForUsersView, int,RegiXClientContext>,
        IReportsForUsersViewRepository
    {
        protected IUserContext UserContext { get; private set; }

        public ReportsForUsersViewRepository(RegiXClientContext aDbContext, IUserContext userContext) : base(aDbContext)
        {
            UserContext = userContext;
        }

        public override IQueryable<ReportsForUsersView> SelectAll()
        {
            if (UserContext.UserId.HasValue)
            {
                var userId = UserContext.UserId.Value;
                var result =
                    this.GetDbContext()
                        .ReportsForUsersView
                        .FromSqlRaw
                        (
                            "EXECUTE REPORTS_FOR_USER {0}",
                            userId
                        )
                        .ToList();
                return result.AsQueryable();
            }
            else
            {
                return new List<ReportsForUsersView>().AsQueryable();
            }
        }
    }
}