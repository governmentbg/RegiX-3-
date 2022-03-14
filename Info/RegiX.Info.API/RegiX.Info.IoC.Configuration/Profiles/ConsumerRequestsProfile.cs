using AutoMapper;
using RegiX.Info.DataContracts.DTO.ConsumerRequests;
using RegiX.Info.Infrastructure.Models;
using TechnoLogica.API.DataContracts;

namespace RegiX.Info.IoC.Configuration.Profiles
{
   public class ConsumerRequestsProfile : Profile
    {
        public ConsumerRequestsProfile()
        {
            CreateMap<ConsumerRequestsInDto, ConsumerRequests>()
                //.ForMember(r => r.ConsumerSystemId, ad => ad.MapFrom(m => m.ConsumerSystem.Id))
                .ForMember(x => x.ConsumerSystem, opt => opt.Ignore());
            CreateMap<ConsumerRequests, ConsumerRequestsOutDto>()
                .ForMember(r => r.ConsumerSystem, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.ConsumerSystem.ConsumerSystemId,
                    DisplayName = m.ConsumerSystem.Name
                }));
        }
    }
}
