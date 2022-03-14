using AutoMapper;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerRole;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.IoC.Configuration.Profiles
{
    public class ConsumerRolesProfile : Profile
    {
        public ConsumerRolesProfile()
        {
            CreateMap<ConsumerRoleInDto, ConsumerRoles>();
            CreateMap<ConsumerRoles, ConsumerRoleOutDto>();
                //.ForMember(r => r.Id, rd => rd.MapFrom(m => m.ConsumerCertificateId))
                //.ForMember(r => r.ApiServiceConsumer, ad => ad.MapFrom(m => new DisplayValue()
                //{
                //    Id = m.ApiServiceConsumer.ApiServiceConsumerId,
                //    DisplayName = m.ApiServiceConsumer.Name
                //}));
        }
    }
}
