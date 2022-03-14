using AutoMapper;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.AdministrationType;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace RegiX.Admin.IoC.Configuration.Profiles
{
    public class AdministrationTypesProfile : Profile
    {
        public AdministrationTypesProfile()
        {
            // Configuration for AdministrationTypes
            CreateMap<AdministrationTypeInDto, AdministrationTypes>();
            CreateMap<AdministrationTypes, AdministrationTypeOutDto>()
                .ForMember(a => a.Id, ad => ad.MapFrom(m => m.AdministrationTypeId));
        }
    }
}