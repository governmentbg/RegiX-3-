using AutoMapper;
using TechnoLogica.API.DataContracts;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ApiService;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace RegiX.Admin.IoC.Configuration.Profiles
{
    public class ApiServicesProfile : Profile
    {
        public ApiServicesProfile()
        {
            // Configuration for ApiServices
            CreateMap<ApiServiceInDto, ApiServices>();
            CreateMap<ApiServices, ApiServiceOutDto>()
                .ForMember(r => r.Id, rd => rd.MapFrom(m => m.ApiServiceId))
                .ForMember(r => r.Administration, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.Administration.AdministrationId,
                    DisplayName = m.Administration.Name
                }));
        }
    }
}