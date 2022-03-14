using AutoMapper;
using TechnoLogica.API.DataContracts;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.AdapterHealthFunction;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace RegiX.Admin.IoC.Configuration.Profiles
{
    public class AdapterHealthFunctionProfile : Profile
    {
        public AdapterHealthFunctionProfile()
        {
            //Configuration for AdapterHealthFunction
            CreateMap<AdapterHealthFunctionInDto, AdapterHealthFunctions>();
            CreateMap<AdapterHealthFunctions, AdapterHealthFunctionOutDto>()
                .ForMember(r => r.Id, rd => rd.MapFrom(m => m.AdapterHealthFunctionId))
                .ForMember(r => r.RegisterAdapter, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.RegisterAdapter.RegisterAdapterId,
                    DisplayName = m.RegisterAdapter.Name
                }));
        }
    }
}