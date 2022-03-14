using AutoMapper;
using TechnoLogica.API.DataContracts;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerAccessRequests;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.IoC.Configuration.Profiles
{
    public class ConsumerAccessRequestsProfile : Profile
    {
        public ConsumerAccessRequestsProfile()
        {
            //Configuration for ConsumerCertificateEid
            CreateMap<ConsumerAccessRequestsInDto, ConsumerAccessRequests>();
            CreateMap<ConsumerAccessRequests, ConsumerAccessRequestsOutDto>()
                .ForMember(r => r.Id, rd => rd.MapFrom(m => m.ConsumerAccessRequestId))
                .ForMember(r => r.ConsumerSystemCertificate, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.ConsumerSystemCertificate.ConsumerSystemCertificateId,
                    DisplayName = m.ConsumerSystemCertificate.Name
                }))
                .ForMember(r => r.ConsumerRequest, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.ConsumerRequest.ConsumerRequestId,
                    DisplayName = m.ConsumerRequest.Name
                }))
                .ForMember(r => r.AdapterOperation, ad => ad.MapFrom(m => new DisplayValueAdapterOperation()
                {
                    Id = m.AdapterOperation.AdapterOperationId,
                    DisplayName = m.AdapterOperation.Name,
                    RegisterObjectId = m.AdapterOperation.RegisterObjectId,
                    Description = m.AdapterOperation.Description
                }));
        }
    }
}