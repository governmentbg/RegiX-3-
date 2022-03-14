using AutoMapper;
using TechnoLogica.API.DataContracts;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.Register;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace RegiX.Admin.IoC.Configuration.Profiles
{

    public class RegistersProfile : Profile
    {
        public RegistersProfile()
        {
            // Configuration for Registers
            CreateMap<RegisterInDto, Registers>();
            CreateMap<Registers, RegisterOutDto>()
                .ForMember(r => r.Id, rd => rd.MapFrom(m => m.RegisterId))
                .ForMember(r => r.Administration, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.Administration.AdministrationId,
                    DisplayName = m.Administration.Name
                }));
        }
    }
}