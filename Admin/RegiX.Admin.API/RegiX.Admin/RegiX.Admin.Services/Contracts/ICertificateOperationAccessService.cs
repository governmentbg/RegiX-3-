using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.CertificateOperationAccess;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Services.Contracts
{
    public interface ICertificateOperationAccessService : IBaseService<CertificateOperationAccessInDto,
        CertificateOperationAccessOutDto, CertificateOperationAccess, decimal>
    {
    }
}