using AutoMapper;
using RegiX.Info.DataContracts.DTO.RegisterObjectElement;
using RegiX.Info.Infrastructure.Models;
using TechnoLogica.API.DataContracts;

namespace RegiX.Info.IoC.Configuration.Profiles
{
    public class RegisterObjectElementsProfile : Profile
    {
        public RegisterObjectElementsProfile()
        {
            //Configuration for RegisterObjectElements
            CreateMap<RegisterObjectElementInDto, RegisterObjectElements>();
            CreateMap<RegisterObjectElements, RegisterObjectElementOutDto>()
                .ForMember(r => r.Id, rd => rd.MapFrom(m => m.RegisterObjectElementId))
                .ForMember(r => r.RegisterObject, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.RegisterObject.RegisterObjectId,
                    DisplayName = m.RegisterObject.Name
                }));
        }
    }
}