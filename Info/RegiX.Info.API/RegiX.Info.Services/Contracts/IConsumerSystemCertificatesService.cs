using RegiX.Info.DataContracts.DTO.ConsumerSystemCertificates;
using RegiX.Info.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;
using TechnoLogica.API.Services;

namespace RegiX.Info.Services.Contracts
{
    public interface IConsumerSystemCertificatesService : IBaseService<ConsumerSystemCertificatesInDto, ConsumerSystemCertificatesOutDto, ConsumerSystemCertificates, decimal>
    {
    }
}
