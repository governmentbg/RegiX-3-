using AutoMapper;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.AuditException;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace RegiX.Admin.IoC.Configuration.Profiles
{
    public class AuditExceptionsProfile : Profile
    {
        public AuditExceptionsProfile()
        {
            //Configuration for AuditExceptions
            CreateMap<AuditExceptionInDto, AuditExceptions>();
            CreateMap<AuditExceptions, AuditExceptionOutDto>()
                .ForMember(r => r.Id, rd => rd.MapFrom(m => m.AuditExceptionId));
        }
    }
}