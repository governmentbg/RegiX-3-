using System;
using System.Collections.Generic;
using System.Text;
using TechnoLogica.API.Repositories.Contracts;
using TechnoLogica.RegiX.Client.Infrastructure.Models;

namespace TechnoLogica.RegiX.Client.Repositories.Contracts
{
    public interface IAsyncReportExecutionsRepository : IBaseRepository<AsyncReportExecutions, int, RegiXClientContext>
    {
        AsyncReportExecutions FindByServiceCallId(decimal apiServiceCallId, string verificationCode);
    }
}
