using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.CertificateElementAccess;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Services.Contracts
{
    public interface ICertificateElementAccessService : IBaseService<CertificateElementAccessInDto,
        CertificateElementAccessOutDto, CertificateElementAccess, decimal>
    {
    }
}