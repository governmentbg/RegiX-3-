using System.Linq;
using TechnoLogica.API.Repositories.Contracts;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Repositories.Contracts
{
    public interface
        ICertificateElementAccessRepository : IBaseRepository<CertificateElementAccess, decimal, RegiXContext>
    {
        IQueryable<CertificateElementAccess> SelectAllByCertificateId(decimal certificateId);
    }
}