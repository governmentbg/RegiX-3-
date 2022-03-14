using AutoMapper;
using TechnoLogica.API.DataContracts;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerProfileUsers;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.IoC.Configuration.Profiles
{
    public class ConsumerProfileUsersProfile : Profile
    {
        public ConsumerProfileUsersProfile()
        {
            //Configuration for ConsumerProfiles
            CreateMap<ConsumerProfileUsersInDto, ConsumerProfileUsers>()
                .ForMember(r => r.ConsumerProfileUserId, rd => rd.MapFrom(m => m.Id));

            CreateMap<ConsumerProfileUsers, ConsumerProfileUsersOutDto>()
                .ForMember(r => r.Id, rd => rd.MapFrom(m => m.ConsumerProfileUserId))
                .ForMember(r => r.ConsumerProfile, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.ConsumerProfile.ConsumerProfileId,
                    DisplayName = m.ConsumerProfile.Name
                }));

        }
    }
}