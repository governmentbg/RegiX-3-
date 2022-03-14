using System.Collections.Generic;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.AdapterConsole.DataContracts.OperationsToRoles;
using TechnoLogica.RegiX.AdapterConsole.Infrastructure.Models;
using TechnoLogica.RegiX.AdapterConsole.Repositories.Contracts;
using TechnoLogica.RegiX.AdapterConsole.Services.Contracts;
using TechnoLogica.RegiX.AdapterConsole.Services.QueryValidators;

namespace TechnoLogica.RegiX.AdapterConsole.Services.Impl
{
    public class OperationsToRolesService :
        ABaseService<OperationsToRolesInDto, OperationsToRolesOutDto, OperationsToRoles, int, RegiXAdapterConsoleContext
        >, IOperationsToRolesService
    {
        public OperationsToRolesService(IOperationsToRolesRepository aBaseRepository)
            : base(aBaseRepository, new OperationsToRoleQueryValidator())
        {
        }

        /// <summary>
        ///   The PopulateDtoToEntityFieldsMapping
        /// </summary>
        protected override void PopulateDtoToEntityFieldsMapping()
        {
            dtoFieldsToEntityFields.Add("adapterOperation.id", "adapterOperation/Id");
            dtoFieldsToEntityFields.Add("adapterOperation.displayName", "adapterOperation/Name");
            dtoFieldsToEntityFields.Add("role.id", "role/Id");
            dtoFieldsToEntityFields.Add("role.displayName", "role/Name");
        }

        protected override bool IsChildRecord(int aId, List<string> aParentsList)
        {
            return false;
        }
    }
}