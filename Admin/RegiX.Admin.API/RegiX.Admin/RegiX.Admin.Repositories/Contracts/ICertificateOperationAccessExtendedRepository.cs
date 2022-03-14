using TechnoLogica.API.Repositories.Contracts;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Repositories
{
    public interface
        ICertificateOperationAccessExtendedRepository : IBaseRepository<CertificateOperationAccessExtended, decimal,
            RegiXContext>
    {
    }
}