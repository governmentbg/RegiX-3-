using AutoMapper;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.Role;
using TechnoLogica.RegiX.Client.Infrastructure.Models;

namespace TechnoLogica.RegiX.Client.AutoMapper.AutoMapper
{
    public class RolesMappingProfile : Profile
    {
        public RolesMappingProfile()
        {
            // Configuration for Roles
            CreateMap<RoleInDto, Roles>();
            CreateMap<Roles, RoleOutDto>()
                .ForMember(r => r.Authority, ad => ad.MapFrom(m => new DisplayValue
                    {
                        Id = m.Authority.Id,
                        DisplayName = m.Authority.Name
                    }
                ));
        }
    }
}