using System.Linq;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;

namespace TechnoLogica.RegiX.Admin.Repositories.Impl
{
    public class ConsumerAccessRequestsStatusRepository : ABaseRepository<ConsumerAccessRequestsStatus, decimal, RegiXContext>, IConsumerAccessRequestsStatusRepository
    {
        public ConsumerAccessRequestsStatusRepository(RegiXContext aDbContext)
            : base(aDbContext)
        {
        }

        public override IQueryable<ConsumerAccessRequestsStatus> SelectAll()
        {
            var result = GetDbContext().Set<ConsumerAccessRequestsStatus>()
                .AsQueryable();

            return result;
        }

        public override ConsumerAccessRequestsStatus Select(decimal aId)
        {
            return this.SelectAll().SingleOrDefault(x => x.Id == aId);
        }
    }
}