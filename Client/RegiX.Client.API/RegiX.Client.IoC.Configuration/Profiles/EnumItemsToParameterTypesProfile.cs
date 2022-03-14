using AutoMapper;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.EnumItemsToParameterTypes;
using TechnoLogica.RegiX.Client.Infrastructure.Models;

namespace TechnoLogica.RegiX.Client.IoC.Configuration.Profiles
{
    public class EnumItemsToParameterTypesProfile : Profile
    {
        public EnumItemsToParameterTypesProfile()
        {
            // Configuration for EnumItemsToParameterTypes
            CreateMap<EnumItemsToParameterTypesInDto, EnumItemsToParameterTypes>();
            CreateMap<EnumItemsToParameterTypes, EnumItemsToParameterTypesOutDto>()
                .ForMember(p => p.ParameterType, type => type.MapFrom(p => new DisplayValue
                    {
                        Id = p.ParameterType.Id,
                        DisplayName = p.ParameterType.Type
                    }
                ))
                .ForMember(p => p.Enum, parent => parent.MapFrom(p => new DisplayValue
                    {
                        Id = p.Enum.Id,
                        DisplayName = p.Enum.EnumDisplayText
                    }
                ));
        }
    }
}