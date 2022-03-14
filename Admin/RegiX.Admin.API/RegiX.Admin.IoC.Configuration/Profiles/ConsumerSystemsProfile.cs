using AutoMapper;
using TechnoLogica.API.DataContracts;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerSystems;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.IoC.Configuration.Profiles
{
    public class ConsumerSystemsProfile : Profile
    {
        public ConsumerSystemsProfile()
        {
            // Configuration for  ConsumerSystems
            CreateMap<ConsumerSystemsInDto, ConsumerSystems>()
                .ForMember(r => r.ConsumerSystemId, rd => rd.MapFrom(m => m.Id))
                .ForMember(r => r.ApiServiceConsumerId, rd => rd.MapFrom(m => m.ApiServiceConsumer.Id))
                .ForMember(r => r.ConsumerProfileId, rd => rd.MapFrom(m => m.ConsumerProfile.Id))
                .ForMember(x => x.ApiServiceConsumer, opt => opt.Ignore())
                .ForMember(x => x.ConsumerProfile, opt => opt.Ignore());


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