using AutoMapper;
using TechnoLogica.API.DataContracts;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerRequests;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.IoC.Configuration.Profiles
{
    public class ConsumerRequestsProfile : Profile
    {
        public ConsumerRequestsProfile()
        {
            //Configuration for ConsumerRequestStatus
            CreateMap<ConsumerRequestsInDto, ConsumerRequests>();
            CreateMap<ConsumerRequests, ConsumerRequestsOutDto>()
                .ForMember(r => r.Id, rd => rd.MapFrom(m => m.ConsumerRequestId))
                .ForMember(r => r.ConsumerProfile, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.ConsumerProfile.ConsumerProfileId,
                    DisplayName = m.ConsumerProfile.Name
                }));

        }
    }
}

