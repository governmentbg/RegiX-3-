using AutoMapper;
using TechnoLogica.API.DataContracts;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.Report;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace RegiX.Admin.IoC.Configuration.Profiles
{
    public class ReportsProfile  : Profile
    {
        public ReportsProfile()
        {
            //Configuration for  Reports
           CreateMap<ReportInDto, Reports>();
           CreateMap<Reports, ReportOutDto>()
                .ForMember(r => r.Id, rd => rd.MapFrom(m => m.ReportId))
                .ForMember(r => r.ApiServiceConsumer, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.ApiServiceConsumer.ApiServiceConsumerId,
                    DisplayName = m.ApiServiceConsumer.Name
                }))
                .ForMember(r => r.ApiServiceOperation, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.ApiServiceOperation.ApiServiceOperationId,
                    DisplayName = m.ApiServiceOperation.Name
                }));
        }
    }
}