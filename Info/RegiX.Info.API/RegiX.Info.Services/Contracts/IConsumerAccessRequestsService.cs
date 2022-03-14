using RegiX.Info.DataContracts.DTO.ConsumerAccessRequests;
using RegiX.Info.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;
using TechnoLogica.API.Services;

namespace RegiX.Info.Services.Contracts
{
    public interface IConsumerAccessRequestsService : 
        IBaseService<ConsumerAccessRequestsInDto, ConsumerAccessRequestsOutDto, ConsumerAccessRequests, decimal>
    {
    }

}
