using AutoMapper;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.ReportsForUsersView;
using TechnoLogica.RegiX.Client.Infrastructure.Models.DatabaseObjectModels;

namespace TechnoLogica.RegiX.Client.IoC.Configuration.Profiles
{
    public class ReportsForUsersViewProfile : Profile
    {
        public ReportsForUsersViewProfile()
        {
            // Configuration for ParameterTypes
            CreateMap<ReportsForUsersViewInDto, ReportsForUsersView>();
            CreateMap<ReportsForUsersView, ReportsForUsersViewOutDto>();
        }
    }
}