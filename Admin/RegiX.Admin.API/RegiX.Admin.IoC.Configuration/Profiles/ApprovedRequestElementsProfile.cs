using AutoMapper;
using TechnoLogica.API.DataContracts;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ApprovedRequestElements;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.IoC.Configuration.Profiles
{
    public class ApprovedRequestElementsProfile : Profile
    {
        public ApprovedRequestElementsProfile()
        {
            //Configuration for ApiServiceCalls
            CreateMap<ApprovedRequestElementsInDto, ApprovedRequestElements>();
            CreateMap<ApprovedRequestElements, ApprovedRequestElementsOutDto>()
                .ForMember(r => r.RegisterObjectElement, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.RegisterObjectElement.RegisterObjectElementId,
                    DisplayName = m.RegisterObjectElement.Name
                }));
        }
    }
}