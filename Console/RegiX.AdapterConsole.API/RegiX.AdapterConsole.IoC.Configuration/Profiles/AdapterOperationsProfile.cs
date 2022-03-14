using AutoMapper;
using TechnoLogica.RegiX.AdapterConsole.DataContracts.AdapterOperation;
using TechnoLogica.RegiX.AdapterConsole.Infrastructure.Models;

namespace RegiX.AdapterConsole.IoC.Configuration.Profiles
{
    public class AdapterOperationsProfile : Profile
    {
        public AdapterOperationsProfile()
        {
            //Configuration for  AdapterOperations
            CreateMap<AdapterOperationsInDto, AdapterOperations>();
            CreateMap<AdapterOperations, AdapterOperationsOutDto>();
        }
    }
}