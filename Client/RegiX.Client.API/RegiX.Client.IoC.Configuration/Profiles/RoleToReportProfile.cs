using AutoMapper;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.RoleToReport;
using TechnoLogica.RegiX.Client.Infrastructure.Models;

namespace TechnoLogica.RegiX.Client.IoC.Configuration.Profiles
{
    public class RoleToReportProfile : Profile
    {
        public RoleToReportProfile()
        {
            // Configuration for RolesToReports
            CreateMap<RoleToReportInDto, RolesToReports>();
            CreateMap<RolesToReports, RoleToReportOutDto>()
                .ForMember(rr => rr.Role, role => role.MapFrom(rr => new DisplayValue
                    {
                        Id = rr.Role.Id,
                        DisplayName = rr.Role.Name
                    }
                ))
                .ForMember(rr => rr.Report, report => report.MapFrom(rr => new DisplayValueAuthority
                    {
                        Id = rr.Report.Id,
                        DisplayName = rr.Report.Name,
                        AuthorityId = (int)rr.Report.AuthorityId
                    }
                ));
        }
    }
}