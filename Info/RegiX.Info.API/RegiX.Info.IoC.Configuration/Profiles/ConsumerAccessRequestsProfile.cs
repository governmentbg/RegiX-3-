using AutoMapper;
using RegiX.Info.DataContracts.DTO.ConsumerAccessRequests;
using RegiX.Info.Infrastructure.Models;
using TechnoLogica.API.DataContracts;

namespace RegiX.Info.IoC.Configuration.Profiles
{
    public class ConsumerAccessRequestsProfile : Profile
    {
        public ConsumerAccessRequestsProfile()
        {
            //Configuration for ConsumerCertificateEid
            CreateMap<ConsumerAccessRequestsInDto, ConsumerAccessRequests>()
                .ForMember(r => r.AdapterOperationId, rd => rd.MapFrom(m => m.AdapterOperation.Id))
                .ForMember(r => r.ConsumerSystemCertificateId, rd => rd.MapFrom(m => m.ConsumerSystemCertificate.Id))
                .ForMember(x => x.AdapterOperation, opt => opt.Ignore())
                .ForMember(x => x.ConsumerSystemCertificate, opt => opt.Ignore())
                .ForMember(x => x.ConsumerRequest, opt => opt.Ignore())
                .ForSourceMember(x => x.ElementsIds, opt => opt.Ignore());//is last row needed ? 

            CreateMap<ConsumerAccessRequests, ConsumerAccessRequestsOutDto>()
                .ForMember(r => r.Id, rd => rd.MapFrom(m => m.ConsumerAccessRequestId))
                .ForMember(r => r.AdapterOperation, ad => ad.MapFrom( m => new DisplayValueAdapterOperation()
                {
                    Id = m.AdapterOperation.AdapterOperationId,
                    DisplayName = m.AdapterOperation.Description,
                    RegisterObjectId = (decimal)m.AdapterOperation.RegisterObjectId
                }))
                .ForMember(r => r.ConsumerSystemCertificate, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.ConsumerSystemCertificate.ConsumerSystemCertificateId,
                    DisplayName = m.ConsumerSystemCertificate.Name
                }))
                .ForMember(r => r.ConsumerRequest, ad => ad.MapFrom(m => new DisplayValueConsumerRequest()
                {
                    Id = m.ConsumerRequest.Id,
                    DisplayName = m.ConsumerRequest.Name,
                    Status = m.ConsumerRequest.Status
                }));
        }
    }
}
