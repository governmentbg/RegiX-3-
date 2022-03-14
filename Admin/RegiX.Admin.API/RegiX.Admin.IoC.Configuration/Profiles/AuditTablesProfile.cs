using AutoMapper;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.AuditTable;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace RegiX.Admin.IoC.Configuration.Profiles
{
    public class AuditTablesProfile : Profile
    {
        public AuditTablesProfile()
        {
            //Configuration for AuditTables
            CreateMap<AuditTableInDto, AuditTables>();
            CreateMap<AuditTables, AuditTableOutDto>()
                .ForMember(r => r.Id, rd => rd.MapFrom(m => m.Id));
        }
    }
}