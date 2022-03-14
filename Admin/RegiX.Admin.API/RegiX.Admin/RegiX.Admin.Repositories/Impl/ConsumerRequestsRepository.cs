using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Admin.Infrastructure;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;

namespace TechnoLogica.RegiX.Admin.Repositories.Impl
{
    public class ConsumerRequestsRepository :
        ABaseRepository<ConsumerRequests, decimal, RegiXContext>,
        IConsumerRequestsRepository
    {
        private readonly IConsumerAccessRequestsRepository consumerAccessRequestsRepository;
        private readonly IUserContext userContext;

        public ConsumerRequestsRepository(RegiXContext aDbContext, IConsumerAccessRequestsRepository consumerAccessRequestsRepository, IUserContext userContext)
            : base(aDbContext)
        {
            this.consumerAccessRequestsRepository = consumerAccessRequestsRepository;
            this.userContext = userContext;
        }

        public override IQueryable<ConsumerRequests> SelectAll()
        {
            var result =
                GetDbContext()
                    .Set<ConsumerRequests>()
                    .Include(r => r.ConsumerProfile)
                    .Include(r => r.ConsumerAccessRequests)
                    .ThenInclude(car => car.AdapterOperation)
                    .ThenInclude(ao => ao.RegisterAdapter)
                    .ThenInclude(ra => ra.Register)
                    .Where(x => x.Status != 0)//Don't show requests with status DRAFT (0)
                    .AsQueryable();

            //filtration for non-global admins
            if (this.userContext.AdministrationID != null)
            {
                //returns ConsumerRequests with 1 or more consumerAccessRequests(filtered by current user administration id) in them

                var temp = result.Where(
                    x => x.ConsumerAccessRequests.Count > 0 && 
                         x.ConsumerAccessRequests.Any( car =>
                         car.AdapterOperation.RegisterAdapter.Register.AdministrationId == this.userContext.AdministrationID
                         )
                    );

                return temp;

            }

            return result;

        }

        public override ConsumerRequests Select(decimal aId)
        {
            return this.SelectAll().SingleOrDefault(x => x.ConsumerRequestId == aId);
        }
    }
}