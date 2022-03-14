using System;
using System.Collections.Generic;
using System.Text;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.AdapterConsole.DataContracts.DTO.OperationsPersistance;
using TechnoLogica.RegiX.AdapterConsole.Infrastructure.Models;
using TechnoLogica.RegiX.AdapterConsole.Repositories.Contracts;
using TechnoLogica.RegiX.AdapterConsole.Services.Contracts;

namespace TechnoLogica.RegiX.AdapterConsole.Services.Impl
{
    public class OperationsPersistanceService :
        ABaseService<OperationsPersistanceInDto, OperationsPersistanceOutDto, OperationsPersistance, int, RegiXAdapterConsoleContext>,
        IOperationsPersistanceService
    {
        public OperationsPersistanceService(IOperationsPersistanceRepository aBaseRepository)
            : base(aBaseRepository)
        {
        }

        protected override bool IsChildRecord(int aId, List<string> aParentsList)
        {
            return false;
        }

        protected override void PopulateDtoToEntityFieldsMapping()
        {

        }
    }
}
