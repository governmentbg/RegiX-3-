using AutoMapper;
using TechnoLogica.RegiX.AdapterConsole.DataContracts.Users;
using TechnoLogica.RegiX.AdapterConsole.Infrastructure.Models;

namespace RegiX.AdapterConsole.IoC.Configuration.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            //Configuration for  AdapterHealthResult
            CreateMap<UsersInDto, AspNetUsers>();
            CreateMap<AspNetUsers, UsersOutDto>();
        }
    }
}