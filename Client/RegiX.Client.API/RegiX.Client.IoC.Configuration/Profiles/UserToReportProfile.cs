using AutoMapper;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.UserToReport;
using TechnoLogica.RegiX.Client.Infrastructure.Models;

namespace TechnoLogica.RegiX.Client.IoC.Configuration.Profiles
{
    public class UserToReportProfile : Profile
    {
        public UserToReportProfile()
        {
            // Configuration for UsersToRoles
            CreateMap<UserToReportInDto, UsersToReports>();
            CreateMap<UsersToReports, UserToReportOutDto>()
                .ForMember(u => u.Report, role => role.MapFrom(ur => new DisplayValue
                    {
                        Id = ur.Report.Id,
                        DisplayName = ur.Report.Name
                    }
                ))
                .ForMember(u => u.User, user => user.MapFrom(ur => new DisplayValueAuthority
                {
                        Id = ur.User.Id,
                        DisplayName = ur.User.UserName,
                        AuthorityId = ur.User.FederationUsers.UserAuthorityId
                    }
                ));
        }
    }
}