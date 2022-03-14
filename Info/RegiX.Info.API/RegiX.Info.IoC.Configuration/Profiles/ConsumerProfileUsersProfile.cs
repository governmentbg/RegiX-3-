using AutoMapper;
using RegiX.Info.API.DTOs.ConsumerProfileUsers;
using RegiX.Info.Infrastructure.Models;

namespace RegiX.Info.IoC.Configuration.Profiles
{
    public class ConsumerProfileUsersProfile : Profile
    {
        public ConsumerProfileUsersProfile()
        {
            CreateMap<ConsumerProfileUsersInDto, ConsumerProfileUsers>();
            CreateMap<ConsumerProfileUsers, ConsumerProfileUsersOutDto>()
                .ForMember(r => r.Id, rd => rd.MapFrom(m => m.ConsumerProfileUserId));
        }
    }
}
