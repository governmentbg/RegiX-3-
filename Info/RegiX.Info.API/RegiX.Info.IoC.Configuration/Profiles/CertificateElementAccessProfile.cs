using AutoMapper;
using RegiX.Info.DataContracts.DTO.CertificateElementAccess;
using RegiX.Info.Infrastructure.Models;
using TechnoLogica.API.DataContracts;

namespace RegiX.Info.IoC.Configuration.Profiles
{
    public class CertificateElementAccessProfile : Profile
    {
        public CertificateElementAccessProfile()
        {
            //Configuration for CertificateElementAccess
            CreateMap<CertificateElementAccessInDto, CertificateElementAccess>();
            CreateMap<CertificateElementAccess, CertificateElementAccessOutDto>()
                .ForMember(r => r.ConsumerCertificate, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.ConsumerCertificate.ConsumerCertificateId,
                    DisplayName = m.ConsumerCertificate.Name
                }))
                .ForMember(r => r.RegisterObjectElement, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.RegisterObjectElement.RegisterObjectElementId,
                    DisplayName = m.RegisterObjectElement.Name
                }));
        }
    }
}