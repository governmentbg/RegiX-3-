using AutoMapper;
using TechnoLogica.API.DataContracts;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ParametersValuesLog;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace RegiX.Admin.IoC.Configuration.Profiles
{
    public class ParameterValuesLogProfile : Profile
    {
        public ParameterValuesLogProfile()
        {
            //Configuration for ParameterValuesLog
            CreateMap<ParametersValuesLogInDto, ParametersValuesLog>();
            CreateMap<ParametersValuesLog, ParametersValuesLogOutDto>()
                .ForMember(r => r.Id, rd => rd.MapFrom(m => m.Id))
                .ForMember(r => r.RegisterAdapter, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.RegisterAdapter.RegisterAdapterId,
                    DisplayName = m.RegisterAdapter.Name
                }))
                .ForMember(r => r.User, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.User.UserId,
                    DisplayName = m.User.Name
                }));
        }

    }
}