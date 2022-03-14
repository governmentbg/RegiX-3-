using AutoMapper;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.Register;
using TechnoLogica.RegiX.Client.Infrastructure.Models;

namespace TechnoLogica.RegiX.Client.IoC.Configuration.Profiles
{
    public class RegisterProfile : Profile
    {
        public RegisterProfile()
        {
            // Configuration for Registers
            CreateMap<RegisterInDto, Registers>();
            CreateMap<Registers, RegisterOutDto>()
                .ForMember(r => r.Authority, au => au.MapFrom(r => new DisplayValue
                    {
                        Id = r.AuthorityId,
                        DisplayName = r.Authority.Name
                    }
                ));
        }
    }
}