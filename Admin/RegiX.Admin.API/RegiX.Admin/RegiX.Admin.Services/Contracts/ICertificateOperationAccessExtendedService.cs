using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ElementConsumers;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Services.Contracts
{
    public interface ICertificateOperationAccessExtendedService : IBaseService<CertificateOperationAccessExtendedInDto,
        CertificateOperationAccessExtendedOutDto, CertificateOperationAccessExtended, decimal>
    {
    }
}