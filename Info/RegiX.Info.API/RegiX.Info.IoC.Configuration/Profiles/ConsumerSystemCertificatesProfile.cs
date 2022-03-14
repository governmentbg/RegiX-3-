using System.Text;
using AutoMapper;
using RegiX.Info.DataContracts.DTO.ConsumerSystemCertificates;
using RegiX.Info.Infrastructure.Models;
using TechnoLogica.API.DataContracts;

namespace RegiX.Info.IoC.Configuration.Profiles
{
    public class ConsumerSystemCertificatesProfile : Profile
    {
        public ConsumerSystemCertificatesProfile()
        {
            //Configuration for ConsumerSystemCertificates
            CreateMap<ConsumerSystemCertificatesInDto, ConsumerSystemCertificates>()
                .ForMember(r => r.ConsumerSystemId, rd => rd.MapFrom(m => m.ConsumerSystem.Id))
                .ForMember(r => r.Csr, rd => rd.MapFrom(m => Encoding.Unicode.GetBytes(m.Csr)))
                .ForMember(x => x.ConsumerSystem, opt => opt.Ignore());

            CreateMap<ConsumerSystemCertificates, ConsumerSystemCertificatesOutDto>()
                .ForMember(r => r.Csr, rd => rd.MapFrom(m => Encoding.Unicode.GetString(m.Csr)))
                .ForMember(r => r.Id, rd => rd.MapFrom(m => m.ConsumerSystemCertificateId))
                .ForMember(r => r.ConsumerSystem, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.ConsumerSystem.ConsumerSystemId,
                    DisplayName = m.ConsumerSystem.Name
                }))
                .ForMember(r => r.ConsumerCertificate, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.ConsumerCertificate.ConsumerCertificateId,
                    DisplayName = m.ConsumerCertificate.Name
                }));
        }
    }
}
