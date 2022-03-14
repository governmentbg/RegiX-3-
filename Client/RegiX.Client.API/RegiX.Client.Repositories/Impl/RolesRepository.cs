using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Repositories.Contracts;

namespace TechnoLogica.RegiX.Client.Repositories.Impl
{
    public class RolesRepository : ABaseRepository<Roles, int,RegiXClientContext>, IRolesRepository
    {
        protected IUserContext UserContext { get; private set; }

        public RolesRepository(RegiXClientContext aDbContext, IUserContext userContext) 
            : base(aDbContext)
        {
            UserContext = userContext;
        }
        public override IQueryable<Roles> SelectAll()
        {
             var result = GetDbContext().Set<Roles>().AsNoTracking()
                .Include(r => r.Authority)
                .AsQueryable();

            if (!UserContext.IsGlobalAdmin)
            {
                result = this.UserContext.FilterByAuthority(result);
            }

             return result;
        }

        public override Roles Select(int aId)
        {
            return SelectAll().SingleOrDefault(r => r.Id == aId);
        }

        
    }
}