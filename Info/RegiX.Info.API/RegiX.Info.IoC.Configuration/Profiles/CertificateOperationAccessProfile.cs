using AutoMapper;
using RegiX.Info.DataContracts.DTO.CertificateOperationAccess;
using RegiX.Info.Infrastructure.Models;
using TechnoLogica.API.DataContracts;

namespace RegiX.Info.IoC.Configuration.Profiles
{
    public class CertificateOperationAccessProfile : Profile
    {
        public CertificateOperationAccessProfile()
        {
            CreateMap<CertificateOperationAccessInDto, CertificateOperationAccess>();
            CreateMap<CertificateOperationAccess, CertificateOperationAccessOutDto>()
                .ForMember(r => r.ConsumerCertificate, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.ConsumerCertificate.ConsumerCertificateId,
                    DisplayName = m.ConsumerCertificate.Name
                }))
                .ForMember(r => r.AdapterOperation, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.AdapterOperation.AdapterOperationId,
                    DisplayName = m.AdapterOperation.Name
                }));
        }
    }
}