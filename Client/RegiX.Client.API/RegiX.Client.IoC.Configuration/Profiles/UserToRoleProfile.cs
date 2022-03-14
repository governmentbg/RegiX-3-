using AutoMapper;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.UserToRole;
using TechnoLogica.RegiX.Client.Infrastructure.Models;

namespace TechnoLogica.RegiX.Client.IoC.Configuration.Profiles
{
    public class UserToRoleProfile : Profile
    {
        public UserToRoleProfile()
        {
            // Configuration for UsersToRoles
            CreateMap<UserToRoleInDto, UsersToRoles>();
            CreateMap<UsersToRoles, UserToRoleOutDto>()
                .ForMember(u => u.Role, role => role.MapFrom(ur => new DisplayValue
                    {
                        Id = ur.Role.Id,
                        DisplayName = ur.Role.Name
                    }
                ))
                .ForMember(u => u.User, user => user.MapFrom(ur => new DisplayValueAuthority
                    {
                        Id = ur.User.Id,
                        DisplayName = ur.User.UserName,
                        AuthorityId = ur.User.FederationUsers.UserAuthorityId
                    }
                ));
        }
    }
}