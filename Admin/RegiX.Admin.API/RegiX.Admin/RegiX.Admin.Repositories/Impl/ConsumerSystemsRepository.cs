using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;

namespace TechnoLogica.RegiX.Admin.Repositories.Impl
{
    public class ConsumerSystemsRepository : ABaseRepository<ConsumerSystems, decimal, RegiXContext>, IConsumerSystemsRepository
    {
        public ConsumerSystemsRepository(RegiXContext aDbContext) 
            : base(aDbContext)
        {
        }

        public override IQueryable<ConsumerSystems> SelectAll()
        {
            var result = GetDbContext().Set<ConsumerSystems>()
                .Include(r => r.ConsumerProfile)
                .Include(r => r.ApiServiceConsumer)
                .AsQueryable();

            return result;
        }

        public override ConsumerSystems Select(decimal aId)
        {
            return this.SelectAll().SingleOrDefault(x => x.ConsumerSystemId == aId);
        }
    }
}