using AutoMapper;
using TechnoLogica.API.DataContracts;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.AdapterHealthResult;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace RegiX.Admin.IoC.Configuration.Profiles
{
    public class AdapterHealthResultProfile : Profile
    {
        public AdapterHealthResultProfile()
        {
            //Configuration for  AdapterHealthResult
            CreateMap<AdapterHealthResultInDto, AdapterHealthResults>();
            CreateMap<AdapterHealthResults, AdapterHealthResultOutDto>()
                .ForMember(r => r.Id, rd => rd.MapFrom(m => m.AdapterHealthResultId))
                .ForMember(r => r.RegisterAdapter, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.RegisterAdapter.RegisterAdapterId,
                    DisplayName = m.RegisterAdapter.Name
                }))
                .ForMember(r => r.AdapterHealthFunction, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.AdapterHealthFunction.AdapterHealthFunctionId,
                    DisplayName = m.AdapterHealthFunction.Description
                }));
        }
    }
}