using Microsoft.EntityFrameworkCore;
using RegiX.Info.Infrastructure.Models;
using RegiX.Info.Repositories.Contracts;
using System.Linq;
using TechnoLogica.API.Repositories.Impl;

namespace RegiX.Info.Repositories.Impl
{
    public class ConsumerSystemsRepository : ABaseRepository<ConsumerSystems, decimal, RegiXContext>, IConsumerSystemsRepository
    {
        private readonly IConsumerContext consumerContext;

        public ConsumerSystemsRepository(RegiXContext aDbContext,IConsumerContext consumerContext)
            : base(aDbContext)
        {
            this.consumerContext = consumerContext;
        }

        public override IQueryable<ConsumerSystems> SelectAll()
        {
            var result = GetDbContext().Set<ConsumerSystems>()
                .Include(r => r.ConsumerProfile)
                .Include(r => r.ApiServiceConsumer)
                .AsQueryable();

            result = IConsumerContextExtentions.FilterByProfile(this.consumerContext,result);

            return result;
        }

        public override ConsumerSystems Select(decimal aId)
        {
            return this.SelectAll().SingleOrDefault(x => x.ConsumerSystemId == aId);
        }
    }
}
