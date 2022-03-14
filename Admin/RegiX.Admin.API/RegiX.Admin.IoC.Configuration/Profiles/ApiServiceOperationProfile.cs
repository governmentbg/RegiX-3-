using AutoMapper;
using TechnoLogica.API.DataContracts;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ApiServiceOperation;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace RegiX.Admin.IoC.Configuration.Profiles
{
    public class ApiServiceOperationProfile : Profile
    {
        public ApiServiceOperationProfile()
        {
            //Configuration for ApiServiceOperation
            CreateMap<ApiServiceOperationInDto, ApiServiceOperations>();
            CreateMap<ApiServiceOperations, ApiServiceOperationOutDto>()
                .ForMember(r => r.Id, rd => rd.MapFrom(m => m.ApiServiceOperationId))
                .ForMember(r => r.ApiService, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.ApiService.ApiServiceId,
                    DisplayName = m.ApiService.Name
                }));
        }
    }
}