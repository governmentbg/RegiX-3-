using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;

namespace TechnoLogica.RegiX.Admin.Repositories.Impl
{
    public class CertificateConsumerRoleRepository : ABaseRepository<CertificateConsumerRole, decimal, RegiXContext>,
        ICertificateConsumerRoleRepository
    {
        public CertificateConsumerRoleRepository(RegiXContext aDbContext) 
            : base(aDbContext)
        {
        }

        public override IQueryable<CertificateConsumerRole> SelectAll()
        {
            var result =
                GetDbContext()
                    .Set<CertificateConsumerRole>()
                    .Include(r => r.ConsumerCertificate)
                    .Include(r => r.ConsumerRole)
                    .AsQueryable();
            return result;
        }

        public override CertificateConsumerRole Select(decimal aId)
        {
            return this.SelectAll().SingleOrDefault(x => x.Id == aId);
        }
    }
}