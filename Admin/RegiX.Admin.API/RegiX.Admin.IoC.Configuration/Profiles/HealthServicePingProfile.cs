using AutoMapper;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.HealthServicePing;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace RegiX.Admin.IoC.Configuration.Profiles
{
    public class HealthServicePingProfile : Profile
    {
        public HealthServicePingProfile()
        {
            // Configuration for HealthServicePing
           CreateMap<HealthServicePingInDto, HealthServicePing>();
           CreateMap<HealthServicePing, HealthServicePingOutDto>()
                .ForMember(r => r.Id, rd => rd.MapFrom(m => m.HealthServicePingId));
        }
    }
}