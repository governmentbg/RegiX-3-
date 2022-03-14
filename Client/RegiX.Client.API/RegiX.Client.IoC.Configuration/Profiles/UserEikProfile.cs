using AutoMapper;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.UserEik;
using TechnoLogica.RegiX.Client.Infrastructure.Models;

namespace TechnoLogica.RegiX.Client.IoC.Configuration.Profiles
{
    public class UserEikProfile : Profile
    {
        public UserEikProfile()
        {
            // Configuration for UserEiks
            CreateMap<UserEikInDto, UserEiks>();
            CreateMap<UserEiks, UserEikOutDto>()
                .ForMember(ue => ue.User, user => user.MapFrom(ue => new DisplayValue
                    {
                        Id = ue.User.Id,
                        DisplayName = ue.User.Identifier
                    }
                ));
        }
    }
}