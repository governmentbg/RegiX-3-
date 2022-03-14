using AutoMapper;
using TechnoLogica.API.DataContracts;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.CertificateConsumerRole;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.IoC.Configuration.Profiles
{
    public class CertificateConsumerRoleProfile : Profile
    {
        public CertificateConsumerRoleProfile()
        {
            //Configuration for RegisterAdapters
            CreateMap<CertificateConsumerRoleInDto, CertificateConsumerRole>();
            CreateMap<CertificateConsumerRole, CertificateConsumerRoleOutDto>()
                .ForMember(r => r.ConsumerRole, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.ConsumerRole.Id,
                    DisplayName = m.ConsumerRole.Name
                }))
                .ForMember(r => r.ConsumerCertificate, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.ConsumerCertificate.ConsumerCertificateId,
                    DisplayName = m.ConsumerCertificate.Name
                }));
        }
    }
}