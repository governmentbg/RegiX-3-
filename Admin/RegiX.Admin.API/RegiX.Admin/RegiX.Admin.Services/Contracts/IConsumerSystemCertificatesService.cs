using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerSystemCertificates;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Services.Contracts
{
    public interface IConsumerSystemCertificatesService : IBaseService<ConsumerSystemCertificatesInDto, ConsumerSystemCertificatesOutDto, ConsumerSystemCertificates, decimal>
    {
        
    }
}