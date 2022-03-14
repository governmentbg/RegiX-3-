using AutoMapper;
using TechnoLogica.API.DataContracts;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.RegisterObject;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace RegiX.Admin.IoC.Configuration.Profiles
{
    public class RegisterObjectProfile : Profile
    {
        public RegisterObjectProfile()
        {
            // Configuration for RegisterObject
           CreateMap<RegisterObjectInDto, RegisterObjects>();
           CreateMap<RegisterObjects, RegisterObjectOutDto>()
                .ForMember(r => r.Id, rd => rd.MapFrom(m => m.RegisterObjectId))
                .ForMember(r => r.RegisterAdapter, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.RegisterAdapter.RegisterAdapterId,
                    DisplayName = m.RegisterAdapter.Name
                }));
        }
    }
}