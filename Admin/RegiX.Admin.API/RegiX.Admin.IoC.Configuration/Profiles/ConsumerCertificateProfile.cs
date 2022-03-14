using AutoMapper;
using TechnoLogica.API.DataContracts;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerCertificate;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace RegiX.Admin.IoC.Configuration.Profiles
{
    public class ConsumerCertificateProfile :Profile
    {
        public ConsumerCertificateProfile()
        {
            //Configuration for ConsumerCertificate
            CreateMap<ConsumerCertificateInDto, ConsumerCertificates>();
            CreateMap<ConsumerCertificates, ConsumerCertificateOutDto>()
                .ForMember(r => r.Id, rd => rd.MapFrom(m => m.ConsumerCertificateId))
                .ForMember(r => r.ApiServiceConsumer, ad => ad.MapFrom(m => new ServiceConsumerInfo()
                {
                    Id = m.ApiServiceConsumer.ApiServiceConsumerId,
                    DisplayName = m.ApiServiceConsumer.Name,
                    Oid = m.ApiServiceConsumer.Oid
                }));
        }
    }
}