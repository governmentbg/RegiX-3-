using RegiX.Info.Infrastructure.Models;
using RegiX.Info.Repositories.Contracts;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;

namespace RegiX.Info.Repositories.Impl
{
    public class ConsumerRequestsRepository : ABaseRepository<ConsumerRequests, decimal, RegiXContext>, IConsumerRequestsRepository
    {
        private IConsumerContext Context { get; set; }
        public ConsumerRequestsRepository(RegiXContext aDbContext, IConsumerContext context)
            : base(aDbContext)
        {
            Context = context;
        }

        public override IQueryable<ConsumerRequests> SelectAll()
        {
            var result = GetDbContext().Set<ConsumerRequests>()
                .Include(r => r.ConsumerSystem)
                .AsQueryable();

            return Context.FilterByProfile(result);
        }

        public override ConsumerRequests Select(decimal aId)
        {
            return this.SelectAll().SingleOrDefault(x => x.Id == aId);
        }
    }
}
