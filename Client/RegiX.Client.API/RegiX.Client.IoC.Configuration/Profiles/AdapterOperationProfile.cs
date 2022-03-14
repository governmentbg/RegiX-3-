using AutoMapper;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.AdapterOperations;
using TechnoLogica.RegiX.Client.Infrastructure.Models;

namespace TechnoLogica.RegiX.Client.IoC.Configuration.Profiles
{
    public class AdapterOperationProfile : Profile
    {
        public AdapterOperationProfile()
        {
            CreateMap<AdapterOperationsInDto, AdapterOperations>();
            CreateMap<AdapterOperations, AdapterOperationsOutDto>()
                .ForMember(r => r.Register, ad => ad.MapFrom(m => new DisplayValue
                    {
                        Id = m.Register.Id,
                        DisplayName = m.Register.Name
                    }
                ))
                .ForMember( r => r.RegisterDisplayName, ad => ad.MapFrom( m => m.Register.Name)
            );
            CreateMap<AdapterOperations, AdapterOperationsWithMetadata>()
                .ForMember(r => r.Register, ad => ad.MapFrom(m => new DisplayValue
                {
                    Id = m.Register.Id,
                    DisplayName = m.Register.Name
                }
            ));
        }
    }
}