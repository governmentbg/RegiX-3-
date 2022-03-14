using AutoMapper;
using TechnoLogica.API.DataContracts;
using TechnoLogica.RegiX.AdapterConsole.DataContracts.OperationsToRoles;
using TechnoLogica.RegiX.AdapterConsole.Infrastructure.Models;

namespace RegiX.AdapterConsole.IoC.Configuration.Profiles
{
    public class OperationsToRolesProfile : Profile
    {
        public OperationsToRolesProfile()
        {
            //Configuration for  OperationsToRoles
            CreateMap<OperationsToRolesInDto, OperationsToRoles>();
            CreateMap<OperationsToRoles, OperationsToRolesOutDto>()
                .ForMember(r => r.AdapterOperation, ad => ad.MapFrom(m => new DisplayValue
                {
                    Id = m.AdapterOperation.Id,
                    DisplayName = m.AdapterOperation.Name
                }))
                .ForMember(r => r.Role, ad => ad.MapFrom(m => new DisplayValue
                {
                    Id = m.Role.Id,
                    DisplayName = m.Role.Name
                }));
        }
    }
}