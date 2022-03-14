using RegiX.Info.Infrastructure.Models;
using RegiX.Info.Repositories.Contracts;
using TechnoLogica.API.Repositories.Impl;

namespace RegiX.Info.Repositories.Impl
{
    public class ConsumerRequestStatusRepository : ABaseRepository<ConsumerRequestStatus, decimal, RegiXContext>, IConsumerRequestStatusRepository

    {
        public ConsumerRequestStatusRepository(RegiXContext aDbContext)
            : base(aDbContext)
        {
        }
    }
}