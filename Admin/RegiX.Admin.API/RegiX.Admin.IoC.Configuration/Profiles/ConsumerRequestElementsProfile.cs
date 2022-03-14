using AutoMapper;
using TechnoLogica.API.DataContracts;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerRequestElements;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.IoC.Configuration.Profiles
{
    public class ConsumerRequestElementsProfile : Profile
    {
        public ConsumerRequestElementsProfile()
        {
            //Configuration for ApiServiceCalls
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