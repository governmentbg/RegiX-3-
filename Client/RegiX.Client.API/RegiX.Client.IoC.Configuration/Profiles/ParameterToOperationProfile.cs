using AutoMapper;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.ParameterToOperation;
using TechnoLogica.RegiX.Client.Infrastructure.Models;

namespace TechnoLogica.RegiX.Client.IoC.Configuration.Profiles
{
    public class ParameterToOperationProfile : Profile
    {
        public ParameterToOperationProfile()
        {
            // Configuration for ParametersToOperation
            CreateMap<ParameterToOperationInDto, ParametersToOperation>();
            CreateMap<ParametersToOperation, ParameterToOperationOutDto>()
                .ForMember(po => po.Parameter, parameter => parameter.MapFrom(po => new DisplayValue
                    {
                        Id = po.Parameter.Id,
                        DisplayName = po.Parameter.ParameterName
                    }
                ))
                .ForMember(po => po.AdapterOperation, adapterOperation => adapterOperation.MapFrom(po =>
                    new DisplayValue
                    {
                        Id = po.AdapterOperation.Id,
                        DisplayName = po.AdapterOperation.DisplayOperationName
                    }
                ));
        }
    }
}