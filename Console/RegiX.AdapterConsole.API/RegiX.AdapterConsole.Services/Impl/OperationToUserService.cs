using System;
using System.Collections.Generic;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.AdapterConsole.DataContracts.DTO.UserToReports;
using TechnoLogica.RegiX.AdapterConsole.Infrastructure.Models;
using TechnoLogica.RegiX.AdapterConsole.Repositories.Contracts;
using TechnoLogica.RegiX.AdapterConsole.Services.Contracts;

namespace TechnoLogica.RegiX.AdapterConsole.Services.Impl
{
    public class OperationToUserService :
        ABaseService<OperationToUserInDto, OperationToUserOutDto, OperationsToUsers, int, RegiXAdapterConsoleContext>,
        IOperationToUserService
    {
        public OperationToUserService(IOperationToUserRepository aBaseRepository)
            : base(aBaseRepository)
        {
        }


        /// <summary>
        ///   The PopulateDtoToEntityFieldsMapping
        /// </summary>
        protected override void PopulateDtoToEntityFieldsMapping()
        {
        }

        protected override bool IsChildRecord(int aId, List<string> aParentsList)
        {
            throw new NotImplementedException();
        }
    }
}