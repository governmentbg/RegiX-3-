using AutoMapper;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.Parameter;
using TechnoLogica.RegiX.Client.Infrastructure.Models;

namespace TechnoLogica.RegiX.Client.IoC.Configuration.Profiles
{
    public class ParameterProfile : Profile
    {
        public ParameterProfile()
        {
            // Configuration for Parameters
            CreateMap<ParameterInDto, Parameters>();
            CreateMap<Parameters, ParameterOutDto>()
                .ForMember(p => p.ParameterType, type => type.MapFrom(p => new DisplayValue
                    {
                        Id = p.ParameterType.Id,
                        DisplayName = p.ParameterType.Type
                    }
                ))
                .ForMember(p => p.ParentParameter, parent => parent.MapFrom(p => new DisplayValue
                    {
                        Id = p.ParentParameter.Id,
                        DisplayName = p.ParentParameter.ParameterName
                    }
                ));
        }
    }
}