using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerCertificate;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Services.Contracts
{
    public interface IConsumerCertificateService : IBaseService<ConsumerCertificateInDto, ConsumerCertificateOutDto,
        ConsumerCertificates, decimal>
    {
        ConsumerCertificateOutDto SwapCertificates(decimal sourceId, decimal destinationId);
    }
}