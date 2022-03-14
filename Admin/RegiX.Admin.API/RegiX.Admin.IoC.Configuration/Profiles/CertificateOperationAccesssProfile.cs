using System.Linq;
using AutoMapper;
using TechnoLogica.API.DataContracts;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.AdapterOperation;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.CertificateOperationAccess;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerCertificate;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace RegiX.Admin.IoC.Configuration.Profiles
{
    public class CertificateOperationAccesssProfile : Profile
    {
        public CertificateOperationAccesssProfile()
        {
            //Configuration for  CertificateOperationAccesss
            CreateMap<CertificateOperationAccessInDto, CertificateOperationAccess>();
            CreateMap<CertificateOperationAccess, CertificateOperationAccessOutDto>()
                .ForMember(r => r.Id, rd => rd.MapFrom(m => m.Id))
                .ForMember(
                    r => r.EditComment,
                    rd => rd.MapFrom(
                        m => m.AdapterOperation.CertificateAccessComments
                              .Where( 
                                   cac => cac.ConsumerCertificateId == m.ConsumerCertificateId)
                              .OrderByDescending(x => x.CreatedTime)
                              .FirstOrDefault()
                              .EditAccessComment
                    )
                )
                .ForMember(r => r.AdapterOperation, ad => ad.MapFrom(m => new AdapterOperationDto()
                {
                    Id = m.AdapterOperation.AdapterOperationId,
                    DisplayName = m.AdapterOperation.Name,
                    Description = m.AdapterOperation.Description//,
                    // DisplayName = $"{m.AdapterOperation.RegisterAdapter.Contract}.{m.AdapterOperation.Name}"
                }))
                .ForMember( r=> r.RegisterObjectId, ad => ad.MapFrom( m => m.AdapterOperation.RegisterObjectId))
                .ForMember(r => r.ConsumerCertificate, ad => ad.MapFrom(m => new ConsumerCertificateDto()
                {
                    Id = m.ConsumerCertificate.ConsumerCertificateId,
                    DisplayName = m.ConsumerCertificate.Name,
                    Description = m.ConsumerCertificate.Description
                }));
        }
    }
}