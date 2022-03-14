using AutoMapper;
using TechnoLogica.API.DataContracts;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.AdapterPingResult;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace RegiX.Admin.IoC.Configuration.Profiles
{
    public class AdapterPingResultProfile : Profile
    {
        public AdapterPingResultProfile()
        {
            //Configuration for AdapterPingResult
            CreateMap<AdapterPingResultInDto, AdapterPingResults>();
            CreateMap<AdapterPingResults, AdapterPingResultOutDto>()
                .ForMember(r => r.Id, rd => rd.MapFrom(m => m.AdapterPingResultId))
                .ForMember(r => r.RegisterAdapter, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.RegisterAdapter.RegisterAdapterId,
                    DisplayName = m.RegisterAdapter.Name
                }));
        }
    }
}