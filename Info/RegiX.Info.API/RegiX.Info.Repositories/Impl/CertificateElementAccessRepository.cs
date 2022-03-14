using System.Linq;
using Microsoft.EntityFrameworkCore;
using RegiX.Info.Infrastructure.Models;
using RegiX.Info.Repositories.Contracts;
using TechnoLogica.API.Repositories.Impl;

namespace RegiX.Info.Repositories.Impl
{
    public class CertificateElementAccessRepository : ABaseRepository<CertificateElementAccess, decimal, RegiXContext>,
        ICertificateElementAccessRepository
    {
        public CertificateElementAccessRepository(RegiXContext aDbContext) 
            : base(aDbContext)
        {
        }

        public override IQueryable<CertificateElementAccess> SelectAll()
        {
            var result = GetDbContext().Set<CertificateElementAccess>()
                .Include(r => r.RegisterObjectElement)
                .Include(r => r.ConsumerCertificate)
                .AsQueryable();

            return result;
        }

        public override CertificateElementAccess Select(decimal aId)
        {
            return this.SelectAll().SingleOrDefault(x => x.Id == aId);
        }
    }
}