using AutoMapper;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.MyProfileDtos;
using TechnoLogica.RegiX.Client.Infrastructure.Models;

namespace TechnoLogica.RegiX.Client.IoC.Configuration.Profiles
{
    public class MyProfileProfile : Profile
    {
        public MyProfileProfile()
        {
            // Configuration for EnumItems
            CreateMap<MyProfileInDto, Users>();
            CreateMap<Users, MyProfileOutDto>()
                .ForMember(
                    u => u.Position,
                    federationUser => federationUser.MapFrom(u => u.FederationUsers.Position))
                .ForMember(r => r.UsersEauth, ad => ad.MapFrom(m => new UsersEauthDto
                    {
                        Id = m.FederationUsers.UsersEauth.Id,
                        Identifier = m.FederationUsers.UsersEauth.Identifier,
                        IdentifierType = m.FederationUsers.UsersEauth.IdentifierType
                    }
                ));
        }
    }
}