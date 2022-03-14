using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;

namespace TechnoLogica.RegiX.Admin.Repositories.Impl
{
    public class ConsumerRoleElementAccessRepository :  ABaseRepository<ConsumerRoleElementAccess, decimal, RegiXContext>, IConsumerRoleElementAccessRepository
    {
        public ConsumerRoleElementAccessRepository(RegiXContext aDbContext) 
            : base(aDbContext)
        {
        }

        public override IQueryable<ConsumerRoleElementAccess> SelectAll()
        {
            var result =
                GetDbContext()
                    .Set<ConsumerRoleElementAccess>()
                    .Include(r => r.RegisterObjectElement)
                    .Include(r => r.ConsumerRole)
                    .AsQueryable();
            return result;
        }

        public override ConsumerRoleElementAccess Select(decimal aId)
        {
            return this.SelectAll().SingleOrDefault(x => x.Id == aId);
        }

        public IQueryable<ConsumerRoleElementAccess> SelectAllByConsumerRole(decimal consumerRoleId)
        {
            return GetDbContext().Set<ConsumerRoleElementAccess>()
                .Include(r => r.ConsumerRole)
                .Include(r => r.RegisterObjectElement)
                .Where(x => x.ConsumerRoleId == consumerRoleId)
                .AsQueryable();
        }
    }
}