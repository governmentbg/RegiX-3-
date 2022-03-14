using System;
using System.Collections.Generic;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.AdapterConsole.DataContracts.ReturnedCalls;
using TechnoLogica.RegiX.AdapterConsole.Infrastructure.Models;
using TechnoLogica.RegiX.AdapterConsole.Repositories.Contracts;
using TechnoLogica.RegiX.AdapterConsole.Services.Contracts;
using TechnoLogica.RegiX.AdapterConsole.Services.QueryValidators;

namespace TechnoLogica.RegiX.AdapterConsole.Services.Impl
{
    public class ReturnedCallsService :
        ABaseService<ReturnedCallsInDto, ReturnedCallsOutDto, ReturnedCalls, int, RegiXAdapterConsoleContext>,
        IReturnedCallsService
    {
        public ReturnedCallsService(IReturnedCallsRepository aBaseRepository)
            : base(aBaseRepository, new ReturnedCallsQueryValidator())
        {
        }

        /// <summary>
        ///   The PopulateDtoToEntityFieldsMapping
        /// </summary>
        protected override void PopulateDtoToEntityFieldsMapping()
        {
            dtoFieldsToEntityFields.Add("adapterOperation.id", "adapterOperation/Id");
            dtoFieldsToEntityFields.Add("adapterOperation.displayName", "AdapterOperation/Description");
            dtoFieldsToEntityFields.Add("returnedBy.id", "ReturnedByNavigation/Id");
            dtoFieldsToEntityFields.Add("returnedBy.displayName", "ReturnedByNavigation/Name");
        }

        protected override bool IsChildRecord(int aId, List<string> aParentsList)
        {
            throw new NotImplementedException();
        }
    }
}