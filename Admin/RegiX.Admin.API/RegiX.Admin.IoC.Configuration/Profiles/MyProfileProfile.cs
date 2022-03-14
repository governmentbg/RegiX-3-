using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.MyProfile;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.IoC.Configuration.Profiles
{
    public class MyProfileProfile : Profile
    {
        public MyProfileProfile()
        {
            // Configuration for EnumItems
            CreateMap<MyProfileInDto, Users>();
            CreateMap<Users, MyProfileOutDto>()
                .ForMember( r=> r.Id, ad => ad.MapFrom( m=> m.UserId))
                .ForMember( r => r.UsersEauth, ad => ad.MapFrom(m => new UsersEauthDto
                {
                    Id = m.UserEAuth.UserId,
                    Identifier = m.UserEAuth.Identifier,
                    IdentifierType = m.UserEAuth.IdentifierType
                }
                ));
        }
    }
}
