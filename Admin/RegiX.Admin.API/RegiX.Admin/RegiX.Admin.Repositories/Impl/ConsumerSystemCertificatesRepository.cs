using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;

namespace TechnoLogica.RegiX.Admin.Repositories.Impl
{
    public class ConsumerSystemCertificatesRepository :  ABaseRepository<ConsumerSystemCertificates, decimal, RegiXContext>, IConsumerSystemCertificatesRepository
    {
        public ConsumerSystemCertificatesRepository(RegiXContext aDbContext) 
            : base(aDbContext)
        {
        }

        public override IQueryable<ConsumerSystemCertificates> SelectAll()
        {
            var result = GetDbContext().Set<ConsumerSystemCertificates>()
                .Include(r => r.ConsumerCertificate)
                .Include(r => r.ConsumerSystem)
                .AsQueryable();

            return result;
        }

        public override ConsumerSystemCertificates Select(decimal aId)
        {
            return this.SelectAll().SingleOrDefault(x => x.ConsumerSystemCertificateId == aId);
        }
    }
}