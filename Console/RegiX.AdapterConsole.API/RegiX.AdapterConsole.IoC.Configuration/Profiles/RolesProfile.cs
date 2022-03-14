using AutoMapper;
using TechnoLogica.RegiX.AdapterConsole.DataContracts;
using TechnoLogica.RegiX.AdapterConsole.Infrastructure.Models;

namespace RegiX.AdapterConsole.IoC.Configuration.Profiles
{
    public class RolesProfile : Profile
    {
        public RolesProfile()
        {
            //Configuration for  Roles
            CreateMap<RolesInDto, AspNetUserRoles>();
            CreateMap<AspNetUserRoles, RolesOutDto>();
        }
    }
}