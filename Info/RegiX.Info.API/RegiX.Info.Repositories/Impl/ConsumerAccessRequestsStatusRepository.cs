using RegiX.Info.Infrastructure.Models;
using RegiX.Info.Repositories.Contracts;
using TechnoLogica.API.Repositories.Impl;

namespace RegiX.Info.Repositories.Impl
{
    public class ConsumerAccessRequestsStatusRepository : ABaseRepository<ConsumerAccessRequestsStatus, decimal, RegiXContext>, IConsumerAccessRequestsStatusRepository
    {
        public ConsumerAccessRequestsStatusRepository(RegiXContext aDbContext) 
            : base(aDbContext)
        {
        }
    }
}