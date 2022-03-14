using AutoMapper;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.UserToReport;
using TechnoLogica.RegiX.Client.Infrastructure.Models;

namespace TechnoLogica.RegiX.Client.IoC.Configuration.Profiles
{
    public class UsersFavouriteReportsProfile : Profile
    {
        public UsersFavouriteReportsProfile()
        {
            // Configuration for UsersToRoles
            CreateMap<UsersFavouriteReportInDto, UsersFavouriteReports>();
            CreateMap<UsersFavouriteReports, UsersFavouriteReportOutDto>()
                .ForMember(u => u.Report, role => role.MapFrom(ur => new DisplayValue
                    {
                        Id = ur.Report.Id,
                        DisplayName = ur.Report.Name
                    }
                ))
                .ForMember(u => u.AdapterOperation, role => role.MapFrom(ur => new DisplayValue
                    {
                        Id = ur.Report.AdapterOperation.Id,
                        DisplayName = ur.Report.AdapterOperation.DisplayOperationName
                    }
                ))
                .ForMember(u => u.Register, role => role.MapFrom(ur => new DisplayValue
                    {
                        Id = ur.Report.AdapterOperation.Register.Id,
                        DisplayName = ur.Report.AdapterOperation.Register.Name
                    }
                ))
                .ForMember(u => u.Authority, role => role.MapFrom(ur => new DisplayValue
                    {
                        Id = ur.Report.AdapterOperation.Register.Authority.Id,
                        DisplayName = ur.Report.AdapterOperation.Register.Authority.Name
                    }
                ))
                .ForMember(u => u.User, user => user.MapFrom(ur => new DisplayValue
                    {
                        Id = ur.User.Id,
                        DisplayName = ur.User.UserName
                    }
                ));
        }
    }
}