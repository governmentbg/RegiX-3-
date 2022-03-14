using AutoMapper;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.AuditUserAction;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace RegiX.Admin.IoC.Configuration.Profiles
{
    public class AuditUserActionsProfile : Profile
    {
        public AuditUserActionsProfile()
        {
            //Configuration for AuditUserActions
            CreateMap<AuditUserActionInDto, AuditUserActions>();
            CreateMap<AuditUserActions, AuditUserActionOutDto>()
                .ForMember(r => r.Id, rd => rd.MapFrom(m => m.AuditUserActionId));

        }
    }
}