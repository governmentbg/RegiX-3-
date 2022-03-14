using System.Collections.Generic;
using RegiX.Info.DataContracts.DTO.CertificateElementAccess;
using RegiX.Info.Infrastructure.Models;
using TechnoLogica.API.Services;

namespace RegiX.Info.Services.Contracts
{
    public interface ICertificateElementAccessService :
        IBaseService<CertificateElementAccessInDto, CertificateElementAccessOutDto, CertificateElementAccess, decimal>
    {
        List<CertificateElementAccessOutDto> GetElementsByAdapterOperation(decimal consumerSystemCertificates, decimal adapterOperationId);
    }
}