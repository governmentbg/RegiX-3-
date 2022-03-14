using AutoMapper;
using RegiX.Info.DataContracts.DTO.ConsumerProfileUsersApproved;
using RegiX.Info.Infrastructure.Models;

namespace RegiX.Info.IoC.Configuration.Profiles
{
    public class ConsumerProfileUsersApprovedProfile : Profile
    {
        public ConsumerProfileUsersApprovedProfile()
        {
            CreateMap<ConsumerProfileUsersApprovedInDto, ConsumerProfileUsers>();
            CreateMap<ConsumerProfileUsers, ConsumerProfileUsersApprovedOutDto>()
                .ForMember(r => r.Id, rd => rd.MapFrom(m => m.ConsumerProfileUserId));
        }
    }
}
