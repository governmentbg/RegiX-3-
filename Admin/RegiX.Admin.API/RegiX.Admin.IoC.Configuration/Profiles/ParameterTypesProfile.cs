using AutoMapper;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ParameterType;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace RegiX.Admin.IoC.Configuration.Profiles
{
    public class ParameterTypesProfile : Profile
    {
        public ParameterTypesProfile()
        {
            //Configuration for ParameterTypes
            CreateMap<ParameterTypeInDto, ParameterTypes>();
            CreateMap<ParameterTypes, ParameterTypeOutDto>()
                .ForMember(r => r.Id, rd => rd.MapFrom(m => m.Id));
        }
    }
}