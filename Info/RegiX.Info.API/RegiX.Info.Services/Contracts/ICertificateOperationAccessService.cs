using RegiX.Info.DataContracts.DTO.CertificateOperationAccess;
using RegiX.Info.Infrastructure.Models;
using TechnoLogica.API.Services;

namespace RegiX.Info.Services.Contracts
{
    public interface ICertificateOperationAccessService : IBaseService<CertificateOperationAccessInDto, CertificateOperationAccessOutDto, CertificateOperationAccess,
        decimal>
    {
        
    }
}