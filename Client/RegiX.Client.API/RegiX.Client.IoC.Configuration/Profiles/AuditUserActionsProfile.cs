using AutoMapper;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.AuditUserActions;
using TechnoLogica.RegiX.Client.Infrastructure.Models;

namespace TechnoLogica.RegiX.Client.IoC.Configuration.Profiles
{
    public class AuditUserActionsProfile : Profile
    {
        public AuditUserActionsProfile()
        {
            // Configuration for AuditUserActions
            CreateMap<AuditUserActionsInDto, AuditUserActions>();
            CreateMap<AuditUserActions, AuditUserActionsOutDto>()
                .ForMember(r => r.Authority, ad => ad.MapFrom(m => new DisplayValue
                    {
                        Id = m.Authority.Id,
                        DisplayName = m.Authority.Name
                    }
                ))
                .ForMember(r => r.User, ad => ad.MapFrom(m => new DisplayValue
                    {
                        Id = m.User.Id,
                        DisplayName = m.User.UserName
                    }
                ));
        }
    }
}