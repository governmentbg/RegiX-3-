using AutoMapper;
using TechnoLogica.API.DataContracts;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ApiServiceCall;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace RegiX.Admin.IoC.Configuration.Profiles
{
    public class ApiServiceCallsProfile : Profile
    {
        public ApiServiceCallsProfile()
        {
            //Configuration for ApiServiceCalls
            CreateMap<ApiServiceCallInDto, ApiServiceCalls>();
            CreateMap<ApiServiceCalls, ApiServiceCallOutDto>()
                .ForMember(r => r.Id, rd => rd.MapFrom(m => m.ApiServiceCallId))
                .ForMember(r => r.ApiServiceOperation, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.ApiServiceOperation.ApiServiceOperationId,
                    DisplayName = m.ApiServiceOperation.Name
                }))
                .ForMember(r => r.ConsumerCertificate, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.ConsumerCertificate.ConsumerCertificateId,
                    DisplayName = m.ConsumerCertificate.Name
                }));
        }
    }
}