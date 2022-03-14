using AutoMapper;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.Authorities;
using TechnoLogica.RegiX.Client.Infrastructure.Models;

namespace TechnoLogica.RegiX.Client.IoC.Configuration.Profiles
{
    public class AuthoritiesProfile : Profile
    {
        public AuthoritiesProfile()
        {
            // Configuration for Authorities
            CreateMap<AuthoritiesInDto, Authorities>();
            CreateMap<Authorities, AuthoritiesOutDto>()
                .ForMember(r => r.ParentAuthority, ad => ad.MapFrom(m => new DisplayValue
                    {
                        Id = m.ParentAuthority.Id,
                        DisplayName = m.ParentAuthority.Name
                    }
                ));
        }
    }
}