using AutoMapper;
using TechnoLogica.API.DataContracts;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.OperationParameter;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace RegiX.Admin.IoC.Configuration.Profiles
{
    public class OperationParametersProfile : Profile
    {
        public OperationParametersProfile()
        {
            //Configuration for OperationParameters
            CreateMap<OperationParameterInDto, OperationParameters>();
            CreateMap<OperationParameters, OperationParameterOutDto>()
                .ForMember(r => r.Id, rd => rd.MapFrom(m => m.Id))
                .ForMember(r => r.ServiceOperation, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.ServiceOperation.ApiServiceOperationId,
                    DisplayName = m.ServiceOperation.Name
                }))
                .ForMember(r => r.ParameterType, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.ParameterType.Id,
                    DisplayName = m.ParameterType.Name
                }));
        }
    }
}