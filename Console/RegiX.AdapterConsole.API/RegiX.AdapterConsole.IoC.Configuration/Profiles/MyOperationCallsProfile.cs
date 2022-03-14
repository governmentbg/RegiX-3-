using AutoMapper;
using TechnoLogica.API.DataContracts;
using TechnoLogica.RegiX.AdapterConsole.DataContracts.OperationCalls;
using TechnoLogica.RegiX.AdapterConsole.Infrastructure.Models;

namespace RegiX.AdapterConsole.IoC.Configuration.Profiles
{
    public class MyOperationCallsProfile : Profile
    {
        public MyOperationCallsProfile()
        {
            //Configuration for  OperationCalls
            CreateMap<MyOperationCallsInDto, OperationCalls>();
            CreateMap<OperationCalls, MyOperationCallsOutDto>()
                .ForMember(a => a.AdapterOperation, ad => ad.MapFrom(m => new DisplayValue
                {
                    Id = m.AdapterOperation.Id,
                    DisplayName = m.AdapterOperation.Description
                }))
                .ForMember(a => a.AssignedTo, ad => ad.MapFrom(m => new DisplayValue
                {
                    Id = m.AssignedToNavigation.Id,
                    DisplayName = m.AssignedToNavigation.Name
                }));
        }
    }
}