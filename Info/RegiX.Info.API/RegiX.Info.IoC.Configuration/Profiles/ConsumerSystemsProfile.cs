using AutoMapper;
using RegiX.Info.DataContracts.DTO.ConsumerSystems;
using RegiX.Info.Infrastructure.Models;
using TechnoLogica.API.DataContracts;

namespace RegiX.Info.IoC.Configuration.Profiles
{
    public class ConsumerSystemsProfile : Profile
    {
        public ConsumerSystemsProfile()
        {
            // Configuration for  ConsumerSystems
            CreateMap<ConsumerSystemsInDto, ConsumerSystems>();

            CreateMap<ConsumerSystems, ConsumerSystemsOutDto>()
                .ForMember(r => r.Id, rd => rd.MapFrom(m => m.ConsumerSystemId))
                .ForMember(r => r.ApiServiceConsumer, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.ApiServiceConsumer.ApiServiceConsumerId,
                    DisplayName = m.ApiServiceConsumer.Name
                }))
                .ForMember(r => r.ConsumerProfile, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.ConsumerProfile.ConsumerProfileId,
                    DisplayName = m.ConsumerProfile.Name
                }));
        }
    }
}
