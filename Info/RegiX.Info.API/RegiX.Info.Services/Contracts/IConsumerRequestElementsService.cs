using RegiX.Info.DataContracts.DTO.ConsumerRequestElements;
using RegiX.Info.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;
using TechnoLogica.API.Services;

namespace RegiX.Info.Services.Contracts
{
    public interface IConsumerRequestElementsService : IBaseService<ConsumerRequestElementsInDto, ConsumerRequestElementsOutDto, ConsumerRequestElements, decimal>
    {
    }
}
