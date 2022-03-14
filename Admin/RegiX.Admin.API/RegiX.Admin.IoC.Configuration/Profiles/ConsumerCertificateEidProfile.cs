using AutoMapper;
using TechnoLogica.API.DataContracts;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerCertificateEid;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace RegiX.Admin.IoC.Configuration.Profiles
{
    public class ConsumerCertificateEidProfile : Profile
    {
        public ConsumerCertificateEidProfile()
        {
            //Configuration for ConsumerCertificateEid
            CreateMap<ConsumerCertificateEidInDto, ConsumerCertificateEids>();
            CreateMap<ConsumerCertificateEids, ConsumerCertificateEidOutDto>()
                .ForMember(r => r.Id, rd => rd.MapFrom(m => m.ConsumerCertificateEidId))
                .ForMember(r => r.ConsumerCertificate, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.ConsumerCertificate.ConsumerCertificateId,
                    DisplayName = m.ConsumerCertificate.Name
                }));
        }
    }
}