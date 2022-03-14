using AutoMapper;
using TechnoLogica.API.DataContracts;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerRoleElementAccess;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.IoC.Configuration.Profiles
{
    public class ConsumerRoleElementAccessProfile : Profile
    {
        public ConsumerRoleElementAccessProfile()
        {
            //Configuration for RegisterAdapters
            CreateMap<ConsumerRoleElementAccessInDto, ConsumerRoleElementAccess>();
            CreateMap<ConsumerRoleElementAccess, ConsumerRoleElementAccessOutDto>()
                .ForMember(r => r.ConsumerRole, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.ConsumerRole.Id,
                    DisplayName = m.ConsumerRole.Name
                }))
                .ForMember(r => r.RegisterObjectElement, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.RegisterObjectElement.RegisterObjectElementId,
                    DisplayName = m.RegisterObjectElement.Name
                }));
        }
    }
}