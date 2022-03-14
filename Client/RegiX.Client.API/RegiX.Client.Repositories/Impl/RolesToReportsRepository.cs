using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Repositories.Contracts;

namespace TechnoLogica.RegiX.Client.Repositories.Impl
{
    public class RolesToReportsRepository : ABaseRepository<RolesToReports, int,RegiXClientContext>, IRolesToReportsRepository
    {
  

        public RolesToReportsRepository(RegiXClientContext aDbContext) 
            : base(aDbContext)
        {
        }
        public override IQueryable<RolesToReports> SelectAll()
        {
            var result = GetDbContext().Set<RolesToReports>()
                .Include(rr => rr.Report)
                .Include(rr => rr.Role)
                .AsQueryable();


            return result;
        }

        public override RolesToReports Select(int aId)
        {
            var result = this.SelectAll()
                .SingleOrDefault(rr => rr.Id == aId);

            return result;
        }

        
    }
}