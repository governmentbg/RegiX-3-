using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Infrastructure.Models.DatabaseOperationsModels;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;

namespace TechnoLogica.RegiX.Admin.Repositories.Impl
{
    public class AccessReportFilterConsumerRepository : ABaseRepository<AccessReportFilterConsumerView, decimal, RegiXContext>,
    IAccessReportFilterConsumerRepository
    {
        public AccessReportFilterConsumerRepository(RegiXContext aDbContext) : base(aDbContext)
        {
        }

        public override IQueryable<AccessReportFilterConsumerView> SelectAll()
        {
            return GetDbContext().Query<AccessReportFilterConsumerView>()
                .AsNoTracking()
                .AsQueryable();
        }
    }
}