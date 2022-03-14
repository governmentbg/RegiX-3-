using RegiX.Info.DataContracts.DTO.ConsumerRequestOperations;
using RegiX.Info.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;
using TechnoLogica.API.Services;

namespace RegiX.Info.Services.Contracts
{
    public interface IConsumerRequestOperationsService : IBaseService<ConsumerRequestOperationsInDto, ConsumerRequestOperationsOutDto, ConsumerRequestOperations, decimal>
    {
    }
}
