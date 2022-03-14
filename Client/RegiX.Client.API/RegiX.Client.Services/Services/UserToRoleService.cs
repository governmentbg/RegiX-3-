using System.Collections.Generic;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.UserToRole;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Repositories.Contracts;
using TechnoLogica.RegiX.Client.Services.Contracts;
using TechnoLogica.RegiX.Client.Services.QueryValidators;

namespace TechnoLogica.RegiX.Client.Services.Services
{
    public class UserToRoleService : ABaseService<UserToRoleInDto, UserToRoleOutDto, UsersToRoles, int,RegiXClientContext>,
        IUserToRoleService
    {

        public UserToRoleService(IUsersToRolesRepository aBaseRepository) 
            : base(aBaseRepository)
        {
            queryValidator = new UserToRoleQueryValidator();
        }
        protected override void PopulateDtoToEntityFieldsMapping()
        {
            dtoFieldsToEntityFields.Add("user.id", "User/Id");
            dtoFieldsToEntityFields.Add("user.displayName", "User/UserName");
            dtoFieldsToEntityFields.Add("user.authorityId", "User/FederationUsers/UserAuthority/Id");
            dtoFieldsToEntityFields.Add("role.id", "Role/Id");
            dtoFieldsToEntityFields.Add("role.displayName", "Role/Name");
        }

        protected override bool IsChildRecord(int aId, List<string> aParentsList)
        {
            throw new System.NotImplementedException();
        }

       
    }
}