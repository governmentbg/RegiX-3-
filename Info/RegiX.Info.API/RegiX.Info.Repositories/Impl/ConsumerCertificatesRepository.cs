using System.Linq;
using Microsoft.EntityFrameworkCore;
using RegiX.Info.Infrastructure.Models;
using RegiX.Info.Repositories.Contracts;
using TechnoLogica.API.Repositories.Impl;

namespace RegiX.Info.Repositories.Impl
{
    public class ConsumerCertificatesRepository : ABaseRepository<ConsumerCertificates, decimal, RegiXContext>, IConsumerCertificatesRepository
    {
        public ConsumerCertificatesRepository(RegiXContext aDbContext) 
            : base(aDbContext)
        {
        }

        public override IQueryable<ConsumerCertificates> SelectAll()
        {
            var result = GetDbContext().Set<ConsumerCertificates>()
                .Include(r => r.ApiServiceConsumer)
                .AsQueryable();

            return result;
        }

        public override ConsumerCertificates Select(decimal aId)
        {
            return this.SelectAll().SingleOrDefault(x => x.ConsumerCertificateId == aId);
        }
    }
}