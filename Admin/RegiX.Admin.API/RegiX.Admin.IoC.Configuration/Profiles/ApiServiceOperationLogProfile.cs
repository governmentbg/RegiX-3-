using AutoMapper;
using TechnoLogica.API.DataContracts;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ApiServiceOperationLog;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace RegiX.Admin.IoC.Configuration.Profiles
{
    public class ApiServiceOperationLogProfile : Profile
    {
        public ApiServiceOperationLogProfile()
        {
            //Configuration for ApiServiceOperationLog
            CreateMap<ApiServiceOperationLogInDto, ApiServiceOperationLog>();
            CreateMap<ApiServiceOperationLog, ApiServiceOperationLogOutDto>()
                .ForMember(r => r.Id, rd => rd.MapFrom(m => m.ApiServiceOperationLogId))
                .ForMember(r => r.ApiServiceOperation, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.ApiServiceOperation.ApiServiceOperationId,
                    DisplayName = m.ApiServiceOperation.Name
                }));
        }
    }
}