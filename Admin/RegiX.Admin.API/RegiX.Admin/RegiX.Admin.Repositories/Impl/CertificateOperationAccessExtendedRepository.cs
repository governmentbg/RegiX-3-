using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Repositories.Impl
{
    public class CertificateOperationAccessExtendedRepository :
        ABaseRepository<CertificateOperationAccessExtended, decimal, RegiXContext>,
        ICertificateOperationAccessExtendedRepository
    {
        public CertificateOperationAccessExtendedRepository(RegiXContext aDbContext)
            : base(aDbContext)
        {
        }
    }
}