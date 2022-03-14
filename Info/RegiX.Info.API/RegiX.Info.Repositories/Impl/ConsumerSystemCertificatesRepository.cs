using Microsoft.EntityFrameworkCore;
using RegiX.Info.Infrastructure.Models;
using RegiX.Info.Repositories.Contracts;
using System.Linq;
using TechnoLogica.API.Repositories.Impl;

namespace RegiX.Info.Repositories.Impl
{
    public class ConsumerSystemCertificatesRepository : ABaseRepository<ConsumerSystemCertificates, decimal, RegiXContext>, IConsumerSystemCertificatesRepository
    {
        private readonly IConsumerSystemsRepository consumerSystemsRepository;

        public ConsumerSystemCertificatesRepository(RegiXContext aDbContext, IConsumerSystemsRepository consumerSystemsRepository)
            : base(aDbContext)
        {
            this.consumerSystemsRepository = consumerSystemsRepository;
        }

        public override IQueryable<ConsumerSystemCertificates> SelectAll()
        {
            var result = GetDbContext().Set<ConsumerSystemCertificates>()
                .Include(r => r.ConsumerCertificate)
                .Include(r => r.ConsumerSystem)
                .AsQueryable();

            //already filtered by consumerProfileId
            var consumerSystems = this.consumerSystemsRepository.SelectAll().Select(x => x.ConsumerSystemId);

            result = result.Where(x => consumerSystems.Contains(x.ConsumerSystemId));

            return result;
        }

        public override ConsumerSystemCertificates Select(decimal aId)
        {
            return this.SelectAll().SingleOrDefault(x => x.ConsumerSystemCertificateId == aId);
        }
    }
}
