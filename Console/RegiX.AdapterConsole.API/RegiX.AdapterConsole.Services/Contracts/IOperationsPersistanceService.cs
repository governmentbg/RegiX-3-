using System;
using System.Collections.Generic;
using System.Text;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.AdapterConsole.DataContracts.DTO.OperationsPersistance;
using TechnoLogica.RegiX.AdapterConsole.Infrastructure.Models;

namespace TechnoLogica.RegiX.AdapterConsole.Services.Contracts
{
    public interface
   IOperationsPersistanceService :
        IBaseService<OperationsPersistanceInDto, OperationsPersistanceOutDto, OperationsPersistance, int>
    {
    }
}
