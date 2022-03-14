using AutoMapper;
using TechnoLogica.API.DataContracts;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerRoleOperationAccess;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.RegisterAdapter;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.IoC.Configuration.Profiles
{
    public class ConsumerRoleOperationAccessProfile : Profile
    {
        public ConsumerRoleOperationAccessProfile()
        {
            //Configuration for RegisterAdapters
            CreateMap<ConsumerRoleOperationAccessInDto, ConsumerRoleOperationAccess>();
            CreateMap<ConsumerRoleOperationAccess, ConsumerRoleOperationAccessOutDto>()
                .ForMember(r => r.ConsumerRole, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.ConsumerRole.Id,
                    DisplayName = m.ConsumerRole.Name
                }))
                .ForMember(r => r.AdapterOperationDisplayName, ad => ad.MapFrom(m => m.AdapterOperation.Description))
                .ForMember(r => r.RegisterDisplayName, ad => ad.MapFrom(m => m.AdapterOperation.RegisterAdapter.Register.Name))
                .ForMember(r => r.AdministrationDisplayName, ad => ad.MapFrom(m => m.AdapterOperation.RegisterAdapter.Register.Administration.Name))
                .ForMember(r => r.AdapterDisplayName, ad => ad.MapFrom(m => m.AdapterOperation.RegisterAdapter.Description));
        }
    }
}