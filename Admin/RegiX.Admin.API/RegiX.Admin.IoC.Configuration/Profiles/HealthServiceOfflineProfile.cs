using AutoMapper;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.HealthServiceOffline;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace RegiX.Admin.IoC.Configuration.Profiles
{
    public class HealthServiceOfflineProfile : Profile
    {
        public HealthServiceOfflineProfile()
        {
            // Configuration for HealthServiceOffline
            CreateMap<HealthServiceOfflineInDto, HealthServiceOffline>();
            CreateMap<HealthServiceOffline, HealthServiceOfflineOutDto>()
                .ForMember(r => r.Id, rd => rd.MapFrom(m => m.HealthServiceOfflineId));
        }
    }
}