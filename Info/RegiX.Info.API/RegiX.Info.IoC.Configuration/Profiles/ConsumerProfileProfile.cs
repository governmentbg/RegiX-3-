using AutoMapper;
using RegiX.Info.DataContracts.DTO.ConsumerProfile;
using RegiX.Info.Infrastructure.Models;

namespace RegiX.Info.IoC.Configuration.Profiles
{
    public class ConsumerProfileProfile : Profile
    {
        public ConsumerProfileProfile()
        {
            CreateMap<ConsumerProfileInDto, ConsumerProfiles>();
            CreateMap<ConsumerProfiles, ConsumerProfileOutDto>()
                .ForMember(r => r.Id, rd => rd.MapFrom(m => m.ConsumerProfileId));
        }
    }
}
