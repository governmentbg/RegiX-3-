using AutoMapper;
using TechnoLogica.API.DataContracts;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.RegisterAdapter;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace RegiX.Admin.IoC.Configuration.Profiles
{
    public class RegisterAdaptersProfile : Profile
    {
        public RegisterAdaptersProfile()
        {
            //Configuration for RegisterAdapters
            CreateMap<RegisterAdapterInDto, RegisterAdapters>();
            CreateMap<RegisterAdapters, RegisterAdapterOutDto>()
                .ForMember(r => r.Id, rd => rd.MapFrom(m => m.RegisterAdapterId))
                .ForMember( r=> r.HostAvailability, rd => rd.MapFrom( m => false))
                .ForMember(r => r.Register, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.Register.RegisterId,
                    DisplayName = m.Register.Name
                }));
        }
    }
}