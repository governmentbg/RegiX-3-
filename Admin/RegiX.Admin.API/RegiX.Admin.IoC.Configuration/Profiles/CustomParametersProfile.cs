using AutoMapper;
using TechnoLogica.API.DataContracts;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.CustomParameter;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace RegiX.Admin.IoC.Configuration.Profiles
{
    public class CustomParametersProfile : Profile
    {
        public CustomParametersProfile()
        {
            // Configuration for  CustomParameters
 
            CreateMap<CustomParameterInDto, CustomParameters>();
            CreateMap<CustomParameters, CustomParameterOutDto>()
                .ForMember(r => r.Id, rd => rd.MapFrom(m => m.Id))
                .ForMember(r => r.OperationParameter, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.OperationParameter.Id,
                    DisplayName = m.OperationParameter.Name
                }))
                .ForMember(r => r.Report, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.Report.ReportId,
                    DisplayName = m.Report.Name
                }));
        }
    }
}