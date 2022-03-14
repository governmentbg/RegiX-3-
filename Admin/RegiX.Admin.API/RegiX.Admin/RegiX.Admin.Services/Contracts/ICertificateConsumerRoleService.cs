using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.CertificateConsumerRole;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Services.Contracts
{
    public interface ICertificateConsumerRoleService : IBaseService<CertificateConsumerRoleInDto, CertificateConsumerRoleOutDto,
        CertificateConsumerRole, decimal>
    {
        
    }
}