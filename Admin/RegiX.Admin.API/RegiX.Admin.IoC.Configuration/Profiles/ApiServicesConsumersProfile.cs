using AutoMapper;
using TechnoLogica.API.DataContracts;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ApiServiceConsumer;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace RegiX.Admin.IoC.Configuration.Profiles
{
    public class ApiServicesConsumersProfile : Profile
    {
        public ApiServicesConsumersProfile()
        {
            // Configuration for ApiServicesConsumers
            CreateMap<ApiServiceConsumerInDto, ApiServiceConsumers>();
            CreateMap<ApiServiceConsumers, ApiServiceConsumerOutDto>()
                .ForMember(r => r.Id, rd => rd.MapFrom(m => m.ApiServiceConsumerId))
                .ForMember(r => r.Administration, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.Administration.AdministrationId,
                    DisplayName = m.Administration.Name
                }));
        }
    }
}