using AutoMapper;
using TechnoLogica.API.DataContracts;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.CertificateAccessComment;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace RegiX.Admin.IoC.Configuration.Profiles
{
    public class CertificateAccessCommentProfile : Profile
    {
        public CertificateAccessCommentProfile()
        {
            //Configuration for CertificateAccessComment
            CreateMap<CertificateAccessCommentInDto, CertificateAccessComments>();
            CreateMap<CertificateAccessComments, CertificateAccessCommentOutDto>()
                .ForMember(r => r.Id, rd => rd.MapFrom(m => m.Id))
                .ForMember(r => r.AdapterOperation, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.AdapterOperation.AdapterOperationId,
                    DisplayName = m.AdapterOperation.Name
                }))
                .ForMember(r => r.ConsumerCertificate, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.ConsumerCertificate.ConsumerCertificateId,
                    DisplayName = m.ConsumerCertificate.Name
                }))
                .ForMember(r => r.User, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.User.UserId,
                    DisplayName = m.User.Name

                }));
        }
    }
}