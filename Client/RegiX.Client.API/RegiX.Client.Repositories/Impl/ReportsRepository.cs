using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Repositories.Contracts;

namespace TechnoLogica.RegiX.Client.Repositories.Impl
{
    public class ReportsRepository : ABaseRepository<Reports, int,RegiXClientContext>, IReportsRepository
    {
        protected IUserContext UserContext { get; private set; }
        public ReportsRepository(RegiXClientContext aDbContext, IUserContext userContext) 
            : base(aDbContext)
        {
            UserContext = userContext;
        }
        public override IQueryable<Reports> SelectAll()
        {
            var result = GetDbContext().Set<Reports>().AsNoTracking()
                .Include(x => x.AdapterOperation)
                .Include(x => x.AdapterOperation.Register)
                .Include(x => x.AdapterOperation.Register.Authority)
                .Include(x => x.Authority)
                .AsQueryable();

            result = this.UserContext.FilterByAuthority(result);

            return result;
        }

        public override Reports Insert(Reports aEntity)
        {
            if (!UserContext.IsGlobalAdmin && UserContext.AdministrationID.HasValue)
            {
                aEntity.AuthorityId = UserContext.AdministrationID.Value;
            }
            return base.Insert(aEntity);
        }

        public override Reports Select(int aId)
        {
            return SelectAll().SingleOrDefault(r => r.Id == aId);
        }

       
    }
}