using AutoMapper;
using TechnoLogica.API.DataContracts;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace RegiX.Admin.IoC.Configuration.Profiles
{
    public class AdministrationsProfile : Profile
    {
        public AdministrationsProfile()
        {
            // Configuration for Administrations
            CreateMap<AdministrationInDto, Administrations>();
            CreateMap<Administrations, AdministrationOutDto>()
                .ForMember(a => a.Id, ad => ad.MapFrom(m => m.AdministrationId))
                .ForMember(a => a.AdministrationType, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.AdministrationType.AdministrationTypeId,
                    DisplayName = m.AdministrationType.Name
                }))
                .ForMember(a => a.ParentAuthority, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.ParentAuthority.AdministrationId,
                    DisplayName = m.ParentAuthority.Name
                }));
        }
    }
}