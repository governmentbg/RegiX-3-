using AutoMapper;
using TechnoLogica.API.DataContracts;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ApiServiceAdapterOperation;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace RegiX.Admin.IoC.Configuration.Profiles
{
    public class ApiServiceAdapterOperationsProfile : Profile
    {
        public ApiServiceAdapterOperationsProfile()
        {
            //Configuration for ApiServiceAdapterOperations
            CreateMap<ApiServiceAdapterOperationInDto, ApiServiceAdapterOperations>();
            CreateMap<ApiServiceAdapterOperations, ApiServiceAdapterOperationOutDto>()
                .ForMember(r => r.Id, rd => rd.MapFrom(m => m.Id))
                .ForMember(r => r.AdapterOperation, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.AdapterOperation.AdapterOperationId,
                    DisplayName = m.AdapterOperation.Name
                }))
                .ForMember(r => r.ApiServiceOperation, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.ApiServiceOperation.ApiServiceOperationId,
                    DisplayName = m.ApiServiceOperation.Name
                }));
        }

    }
}