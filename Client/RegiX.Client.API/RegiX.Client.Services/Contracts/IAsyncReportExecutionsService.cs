using System;
using System.Collections.Generic;
using System.Text;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.AdapterOperations;
using TechnoLogica.RegiX.Client.Infrastructure.Models;

namespace TechnoLogica.RegiX.Client.Services.Contracts
{
    public interface IAsyncReportExecutionsService : IBaseService<AsyncReportExecutionsInDto, AsyncReportExecutionsOutDto, AsyncReportExecutions, int>
    {
        AsyncReportExecutionsOutDto UpdateRequest(decimal apiServiceCallId, string verificationCode, string data);
    }
}
