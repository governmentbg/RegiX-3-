using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Admin.Infrastructure;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;

namespace TechnoLogica.RegiX.Admin.Repositories.Impl
{
    public class ConsumerAccessRequestsRepository : ABaseRepository<ConsumerAccessRequests, decimal, RegiXContext>, IConsumerAccessRequestsRepository
    {
        private readonly IUserContext userContext;

        public ConsumerAccessRequestsRepository(RegiXContext aDbContext, IUserContext userContext) 
            : base(aDbContext)
        {
            this.userContext = userContext;
        }
     

        public override IQueryable<ConsumerAccessRequests> SelectAll()
        {
            var result = GetDbContext().Set<ConsumerAccessRequests>()
                .Include(r => r.ConsumerSystemCertificate)
                .Include(r => r.ConsumerRequest)
                .Include(r => r.AdapterOperation)
                .Include(r => r.ConsumerSystemCertificate.ConsumerCertificate)
                .Where(x => x.ConsumerRequest.Status != 0)
                .AsQueryable();

            if (this.userContext.AdministrationID.HasValue)
            {
                result = this.userContext.FilterByAdministration(result, r => r.AdapterOperation.RegisterAdapter.Register.AdministrationId);
            }

            return result;
        }

        public override ConsumerAccessRequests Select(decimal aId)
        {
            return this.SelectAll().SingleOrDefault(x => x.ConsumerAccessRequestId == aId);
        }
    }
}