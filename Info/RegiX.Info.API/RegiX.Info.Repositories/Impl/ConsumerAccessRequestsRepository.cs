using Microsoft.EntityFrameworkCore;
using RegiX.Info.Infrastructure.Models;
using RegiX.Info.Repositories.Contracts;
using System.Linq;
using TechnoLogica.API.Repositories.Impl;

namespace RegiX.Info.Repositories.Impl
{
    public class ConsumerAccessRequestsRepository : ABaseRepository<ConsumerAccessRequests, decimal, RegiXContext>, IConsumerAccessRequestsRepository
    {
        private readonly IConsumerRequestsRepository consumerRequestsRepository;

        public ConsumerAccessRequestsRepository(RegiXContext aDbContext, IConsumerRequestsRepository consumerRequestsRepository)
            : base(aDbContext)
        {
            this.consumerRequestsRepository = consumerRequestsRepository;
        }

        public override IQueryable<ConsumerAccessRequests> SelectAll()
        {
            var result = GetDbContext().Set<ConsumerAccessRequests>()
                 .Include(r => r.AdapterOperation)
                 .Include(r => r.ConsumerSystemCertificate)
                 .Include(r => r.ConsumerRequest)
                 .AsQueryable();

            // already filtered by consumerProfileId
            var consumerRequests = consumerRequestsRepository.SelectAll().Select(x => x.Id);

            //get all ConsumerAccessRequests for specific consumerProfile 
            result = result.Where(x => consumerRequests.Contains((decimal)x.ConsumerRequestId));

            return result;
        }

        public override ConsumerAccessRequests Select(decimal aId)
        {
            return this.SelectAll().SingleOrDefault(x => x.ConsumerAccessRequestId == aId);
        }
    }
}
