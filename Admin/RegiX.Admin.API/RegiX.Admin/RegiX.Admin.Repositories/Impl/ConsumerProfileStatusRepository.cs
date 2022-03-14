using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;

namespace TechnoLogica.RegiX.Admin.Repositories.Impl
{
    public class ConsumerProfileStatusRepository : ABaseRepository<ConsumerProfileStatus, decimal, RegiXContext>, IConsumerProfileStatusRepository
    {
        public ConsumerProfileStatusRepository(RegiXContext aDbContext) 
            : base(aDbContext)
        {
        }

        public override IQueryable<ConsumerProfileStatus> SelectAll()
        {
            return GetDbContext().Set<ConsumerProfileStatus>()
                .Include(r => r.ConsumerProfile)
                .AsQueryable();
        }

        public override ConsumerProfileStatus Select(decimal aId)
        {
            return this.SelectAll().SingleOrDefault(x => x.ConsumerProfileStatusId == aId);
        }
    }
}