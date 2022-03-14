using System.Collections.Generic;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.AdapterConsole.DataContracts.UsersToRoles;
using TechnoLogica.RegiX.AdapterConsole.Infrastructure.Models;
using TechnoLogica.RegiX.AdapterConsole.Repositories.Contracts;
using TechnoLogica.RegiX.AdapterConsole.Services.Contracts;
using TechnoLogica.RegiX.AdapterConsole.Services.QueryValidators;

namespace TechnoLogica.RegiX.AdapterConsole.Services.Impl
{
    public class UsersToRolesService :
        ABaseService<UsersToRolesInDto, UsersToRolesOutDto, AspNetUserRoles, int, RegiXAdapterConsoleContext>,
        IUsersToRolesService
    {
        public UsersToRolesService(IUsersToRolesRepository aBaseRepository)
            : base(aBaseRepository, new UserToRoleQueryValidator())
        {
        }

        /// <summary>
        ///   The PopulateDtoToEntityFieldsMapping
        /// </summary>
        protected override void PopulateDtoToEntityFieldsMapping()
        {
            dtoFieldsToEntityFields.Add("user.id", "user/id");
            dtoFieldsToEntityFields.Add("user.displayName", "user/Name");
            dtoFieldsToEntityFields.Add("role.id", "role/id");
            dtoFieldsToEntityFields.Add("role.displayName", "role/Name");
        }

        protected override bool IsChildRecord(int aId, List<string> aParentsList)
        {
            return false;
        }
    }
}