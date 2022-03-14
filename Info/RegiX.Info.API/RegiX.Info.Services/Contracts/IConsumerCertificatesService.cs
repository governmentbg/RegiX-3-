using RegiX.Info.DataContracts.DTO.ConsumerCertificates;
using RegiX.Info.Infrastructure.Models;
using TechnoLogica.API.Services;

namespace RegiX.Info.Services.Contracts
{
    public interface IConsumerCertificatesService : IBaseService<ConsumerCertificatesInDto, ConsumerCertificatesOutDto, ConsumerCertificates, decimal>
    {
        
    }
}