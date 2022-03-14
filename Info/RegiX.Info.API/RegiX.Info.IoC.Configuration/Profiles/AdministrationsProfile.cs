using AutoMapper;
using RegiX.Info.API.DTOs.Administrations;
using RegiX.Info.Infrastructure.Models;

namespace RegiX.Info.IoC.Configuration.Profiles
{
    public class AdministrationsProfile : Profile
    {
        public AdministrationsProfile()
        {
            //Configuration for Administrations
            CreateMap<AdministrationsInDto, Administrations>();
            CreateMap<Administrations, AdministrationsOutDto>()
                .ForMember(a => a.Id, ad => ad.MapFrom(m => m.AdministrationId));

        }
    }
}
