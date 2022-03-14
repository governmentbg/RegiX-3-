using System.Linq;
using AutoMapper;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.User;
using TechnoLogica.RegiX.Client.Infrastructure.Models;

namespace TechnoLogica.RegiX.Client.IoC.Configuration.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // Configuration for Users
            CreateMap<UserInDto, Users>();
            CreateMap<Users, UserOutDto>()
                //.ForMember(u => u.PublicUsers, publicUser => publicUser.MapFrom(u => new DisplayValue()
                //{
                //    Id = u.PublicUsers.Id,
                //    DisplayName = u.PublicUsers.Identifier
                //}))
                .ForMember(
                    u => u.AuthorityId,
                    pu => pu.MapFrom(u => u.FederationUsers.UserAuthority.Id))
                .ForMember(
                    u => u.UserRoles,
                    pu => pu.MapFrom(u => u.UsersToRoles.Select(x => x.Role.Name).ToList()))
                .ForMember(
                    u => u.Position, 
                    federationUser => federationUser.MapFrom(u => u.FederationUsers.Position))
                .ForMember(r => r.Authority, ad => ad.MapFrom(m => new DisplayValue
                    {
                        Id = m.FederationUsers.UserAuthority.Id,
                        DisplayName = m.FederationUsers.UserAuthority.DisplayName
                    }
                ))
                ;
        }
    }
}