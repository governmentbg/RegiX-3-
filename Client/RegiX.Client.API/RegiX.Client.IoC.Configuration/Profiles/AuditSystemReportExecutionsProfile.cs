using AutoMapper;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.AuditSystemReportExecutions;
using TechnoLogica.RegiX.Client.Infrastructure.Models;

namespace TechnoLogica.RegiX.Client.IoC.Configuration.Profiles
{
    public class AuditSystemReportExecutionsProfile : Profile
    {
        public AuditSystemReportExecutionsProfile()
        {
            // Configuration for AuditSystemReportExecutions
            CreateMap<AuditSystemReportExecutionsInDto, AuditSystemReportExecutions>();
            CreateMap<AuditSystemReportExecutions, AuditSystemReportExecutionsOutDto>()
                .ForMember(r => r.AdapterOperation, ad => ad.MapFrom(m => new DisplayValue
                    {
                        Id = m.AdapterOperation.Id,
                        DisplayName = m.AdapterOperation.DisplayOperationName
                    }
                ));
        }
    }
}