using AutoMapper;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.ParameterType;
using TechnoLogica.RegiX.Client.Infrastructure.Models;

namespace TechnoLogica.RegiX.Client.IoC.Configuration.Profiles
{
    public class ParameterTypeProfile : Profile
    {
        public ParameterTypeProfile()
        {
            // Configuration for ParameterTypes
            CreateMap<ParameterTypeInDto, ParameterTypes>();
            CreateMap<ParameterTypes, ParameterTypeOutDto>();
        }
    }
}