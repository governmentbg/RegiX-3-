using AutoMapper;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.HealthServiceLog;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace RegiX.Admin.IoC.Configuration.Profiles
{
    public class HealthServiceLogProfile : Profile
    {
        public HealthServiceLogProfile()
        {
            //Configuration for HealthServiceLog
            CreateMap<HealthServiceLogInDto, HealthServiceLog>();
            CreateMap<HealthServiceLog, HealthServiceLogOutDto>()
                .ForMember(r => r.Id, rd => rd.MapFrom(m => m.HealthServiceLogId));
        }
    }
}