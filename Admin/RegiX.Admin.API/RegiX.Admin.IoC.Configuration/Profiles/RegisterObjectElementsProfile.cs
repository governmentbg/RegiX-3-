using AutoMapper;
using TechnoLogica.API.DataContracts;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.RegisterObjectElement;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace RegiX.Admin.IoC.Configuration.Profiles
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