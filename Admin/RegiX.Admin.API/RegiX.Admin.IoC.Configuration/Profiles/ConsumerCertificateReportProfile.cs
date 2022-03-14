using AutoMapper;
using TechnoLogica.API.DataContracts;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerCertificatesReport;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace RegiX.Admin.IoC.Configuration.Profiles
{
    public class ConsumerCertificateReportProfile : Profile
    {
        public ConsumerCertificateReportProfile()
        {
            //Configuration for  ConsumerCertificateReport
            CreateMap<ConsumerCertificatesReportInDto, ConsumerCertificatesReports>();
            CreateMap<ConsumerCertificatesReports, ConsumerCertificatesReportOutDto>()
                .ForMember(r => r.Id, rd => rd.MapFrom(m => m.ConsumerCertificateReportId))
                .ForMember(r => r.ConsumerCertificate, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.ConsumerCertificate.ConsumerCertificateId,
                    DisplayName = m.ConsumerCertificate.Name
                }))
                .ForMember(r => r.Report, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.Report.ReportId,
                    DisplayName = m.Report.Name
                }));
        }
    }
}