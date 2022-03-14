using AutoMapper;
using RegiX.Info.DataContracts.DTO.Registers;
using RegiX.Info.Infrastructure.Models;
using TechnoLogica.API.DataContracts;

namespace RegiX.Info.IoC.Configuration.Profiles
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