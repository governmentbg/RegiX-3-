using AutoMapper;
using TechnoLogica.API.DataContracts;
using TechnoLogica.RegiX.AdapterConsole.DataContracts.UsersToRoles;
using TechnoLogica.RegiX.AdapterConsole.Infrastructure.Models;

namespace RegiX.AdapterConsole.IoC.Configuration.Profiles
{
    public class UsersToRolesProfile : Profile
    {
        public UsersToRolesProfile()
        {
            //Configuration for  UsersToRoles
            CreateMap<UsersToRolesInDto, AspNetUserRoles>();
            CreateMap<AspNetUserRoles, UsersToRolesOutDto>()
                .ForMember(r => r.User, ad => ad.MapFrom(m => new DisplayValue
                {
                    Id = m.User.Id,
                    DisplayName = m.User.Name
                }))
                .ForMember(r => r.Role, ad => ad.MapFrom(m => new DisplayValue
                {
                    Id = m.Role.Id,
                    DisplayName = m.Role.Name
                }));
        }
    }
}