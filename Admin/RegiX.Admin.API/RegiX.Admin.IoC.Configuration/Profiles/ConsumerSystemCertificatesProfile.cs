using System.Text;
using AutoMapper;
using TechnoLogica.API.DataContracts;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerSystemCertificates;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.IoC.Configuration.Profiles
{
    public class ConsumerSystemCertificatesProfile : Profile
    {
        public ConsumerSystemCertificatesProfile()
        {
            //Configuration for ConsumerSystemCertificates
            CreateMap<ConsumerSystemCertificatesInDto, ConsumerSystemCertificates>()
                .ForMember(r => r.ConsumerSystemCertificateId, rd => rd.MapFrom(m => m.Id))
                .ForMember(r => r.ConsumerCertificateId, rd => rd.MapFrom(m => m.ConsumerCertificate.Id))
                .ForMember(r => r.Content, rd => rd.MapFrom(m => Encoding.Unicode.GetBytes(m.Content)))
                .ForAllOtherMembers(x => x.Ignore());
                

            CreateMap<ConsumerSystemCertificates, ConsumerSystemCertificatesOutDto>()
                .ForMember(r => r.Id, rd => rd.MapFrom(m => m.ConsumerSystemCertificateId))
                .ForMember(r => r.ConsumerCertificate, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.ConsumerCertificate.ConsumerCertificateId,
                    DisplayName = m.ConsumerCertificate.Name
                }))
                .ForMember(r => r.ConsumerSystem, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.ConsumerSystem.ConsumerSystemId,
                    DisplayName = m.ConsumerSystem.Name
                }));
        }
    }
}