using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Infrastructure.Models.DatabaseOperationsModels;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;

namespace TechnoLogica.RegiX.Admin.Repositories.Impl
{
    public class AccessReportFilterRepository : ABaseRepository<AccessReportFilterView, decimal, RegiXContext>,
        IAccessReportFilterRepository
    {
        public AccessReportFilterRepository(RegiXContext aDbContext) 
            : base(aDbContext)
        {
        }

        public override IQueryable<AccessReportFilterView> SelectAll()
        {
            return GetDbContext().Query<AccessReportFilterView>()
                .AsNoTracking()
                .AsQueryable();
        }
    }
}
