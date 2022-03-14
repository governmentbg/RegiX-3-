using AutoMapper;
using TechnoLogica.API.DataContracts;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.CertificateElementAccess;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace RegiX.Admin.IoC.Configuration.Profiles
{
    public class CertificateElementAccessProfile : Profile
    {
        public CertificateElementAccessProfile()
        {
            //Configuration for CertificateElementAccess
            CreateMap<CertificateElementAccessInDto, CertificateElementAccess>();
            CreateMap<CertificateElementAccess, CertificateElementAccessOutDto>()
                .ForMember(r => r.Id, rd => rd.MapFrom(m => m.Id))
                .ForMember(r => r.ConsumerCertificate, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.ConsumerCertificate.ConsumerCertificateId,
                    DisplayName = m.ConsumerCertificate.Name
                }))
                .ForMember( 
                    r => r.RegisterObjectId, 
                    ad => ad.MapFrom(m=> m.RegisterObjectElement.RegisterObjectId)
                )
                .ForMember(r => r.RegisterObjectElement, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.RegisterObjectElement.RegisterObjectElementId,
                    DisplayName = m.RegisterObjectElement.Name
                }));
        }
    }
}