using AutoMapper;
using RegiX.Info.DataContracts.DTO.RegisterAdapter;
using RegiX.Info.Infrastructure.Models;
using TechnoLogica.API.DataContracts;

namespace RegiX.Info.IoC.Configuration.Profiles
{
    public class RegisterAdaptersProfile : Profile
    {
        public RegisterAdaptersProfile()
        {
            //Configuration for RegisterAdapters
            CreateMap<RegisterAdapterInDto, RegisterAdapters>();
            CreateMap<RegisterAdapters, RegisterAdapterOutDto>()
                .ForMember(r => r.Id, rd => rd.MapFrom(m => m.RegisterAdapterId))
                .ForMember(r => r.Register, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.Register.RegisterId,
                    DisplayName = m.Register.Name
                }));
        }
    }
}
