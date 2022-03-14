using AutoMapper;
using RegiX.Info.DataContracts.DTO.ConsumerRequestElements;
using RegiX.Info.Infrastructure.Models;
using TechnoLogica.API.DataContracts;

namespace RegiX.Info.IoC.Configuration.Profiles
{
    public class ConsumerRequestElementsProfile : Profile
    {
        public ConsumerRequestElementsProfile()
        {
            CreateMap<ConsumerRequestElementsInDto, ConsumerRequestElements>();
            CreateMap<ConsumerRequestElements, ConsumerRequestElementsOutDto>()
                .ForMember(r => r.RegisterObjectElement, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.RegisterObjectElement.RegisterObjectElementId,
                    DisplayName = m.RegisterObjectElement.Name
                }));
        }
    }
}