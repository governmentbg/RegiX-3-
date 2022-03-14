using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerCertificateEid;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Services.Contracts
{
    public interface IConsumerCertificateEidService : IBaseService<ConsumerCertificateEidInDto,
        ConsumerCertificateEidOutDto, ConsumerCertificateEids, decimal>
    {
    }
}