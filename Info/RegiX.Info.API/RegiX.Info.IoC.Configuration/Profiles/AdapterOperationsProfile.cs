using AutoMapper;
using RegiX.Info.DataContracts.DTO.AdapterOperations;
using RegiX.Info.Infrastructure.Models;
using TechnoLogica.API.DataContracts;

namespace RegiX.Info.IoC.Configuration.Profiles
{
    public class AdapterOperationsProfile : Profile
    {
        public AdapterOperationsProfile()
        {
            //Configuration for AdapterOperations
            CreateMap<AdapterOperationInDto, AdapterOperations>();
            CreateMap<AdapterOperations, AdapterOperationOutDto>()
                .ForMember(r => r.Id, rd => rd.MapFrom(m => m.AdapterOperationId))
                .ForMember(r => r.RegisterAdapter, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.RegisterAdapter.RegisterAdapterId,
                    DisplayName = m.RegisterAdapter.Description
                }))
                .ForMember(r => r.RegisterObject, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.RegisterObject.RegisterObjectId,
                    DisplayName = m.RegisterObject.Name
                }));

        }
    }
}
