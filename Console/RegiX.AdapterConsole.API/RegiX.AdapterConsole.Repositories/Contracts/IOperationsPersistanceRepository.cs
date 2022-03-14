using System;
using System.Collections.Generic;
using System.Text;
using TechnoLogica.API.Repositories.Contracts;
using TechnoLogica.RegiX.AdapterConsole.Infrastructure.Models;

namespace TechnoLogica.RegiX.AdapterConsole.Repositories.Contracts
{
    public interface IOperationsPersistanceRepository : IBaseRepository<OperationsPersistance, int, RegiXAdapterConsoleContext>
    {
    }
}
