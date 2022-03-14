using AutoMapper;
using TechnoLogica.API.DataContracts;
using TechnoLogica.RegiX.AdapterConsole.DataContracts.ReturnedCalls;
using TechnoLogica.RegiX.AdapterConsole.Infrastructure.Models;

namespace RegiX.AdapterConsole.IoC.Configuration.Profiles
{
    public class ReturnedCallsProfile : Profile
    {
        public ReturnedCallsProfile()
        {
            //Configuration for  ReturnedCalls
            CreateMap<ReturnedCallsInDto, ReturnedCalls>();
            CreateMap<ReturnedCalls, ReturnedCallsOutDto>()
                .ForMember(a => a.AdapterOperation, ad => ad.MapFrom(m => new DisplayValue
                {
                    Id = m.AdapterOperation.Id,
                    DisplayName = m.AdapterOperation.Description
                }))
                .ForMember(a => a.ReturnedBy, ad => ad.MapFrom(m => new DisplayValue
                {
                    Id = m.ReturnedByNavigation.Id,
                    DisplayName = m.ReturnedByNavigation.Name
                }));
        }
    }
}