using System.Linq;
using Microsoft.EntityFrameworkCore;
using RegiX.Info.Infrastructure.Models;
using RegiX.Info.Repositories.Contracts;
using TechnoLogica.API.Repositories.Impl;

namespace RegiX.Info.Repositories.Impl
{
    public class CertificateOperationAccessRepository : ABaseRepository<CertificateOperationAccess, decimal, RegiXContext>, ICertificateOperationAccessRepository
    {
        public CertificateOperationAccessRepository(RegiXContext aDbContext) 
            : base(aDbContext)
        {
        }

        public override IQueryable<CertificateOperationAccess> SelectAll()
        {
            var result = GetDbContext().Set<CertificateOperationAccess>()
                .Include(x => x.AdapterOperation)
                .Include(x => x.ConsumerCertificate)
                .AsQueryable();
            //Should we filter by HAS_ACCESS col ?

            return result;
        }

        public override CertificateOperationAccess Select(decimal aId)
        {
            return this.SelectAll().SingleOrDefault(x => x.Id == aId);
        }
    }
}