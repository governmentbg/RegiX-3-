using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;

namespace TechnoLogica.RegiX.Admin.Repositories.Impl
{
    public class ConsumerRoleOperationAccessRepository : ABaseRepository<ConsumerRoleOperationAccess, decimal, RegiXContext>, IConsumerRoleOperationAccessRepository
    {
        public ConsumerRoleOperationAccessRepository(RegiXContext aDbContext) 
            : base(aDbContext)
        {
        }

        public override IQueryable<ConsumerRoleOperationAccess> SelectAll()
        {
            var result = 
                GetDbContext()
                .Set<ConsumerRoleOperationAccess>()
                .Include(r => r.AdapterOperation)
                .Include(r => r.AdapterOperation.RegisterAdapter)
                .Include(r => r.AdapterOperation.RegisterAdapter.Register)
                .Include(r => r.AdapterOperation.RegisterAdapter.Register.Administration)
                .Include(r => r.ConsumerRole)
                .AsQueryable();
            return result;

        }

        public override ConsumerRoleOperationAccess Select(decimal aId)
        {
            return this.SelectAll().SingleOrDefault(x => x.Id == aId);
        }
    }
}