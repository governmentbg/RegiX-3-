using AutoMapper;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.AdapterOperations;
using TechnoLogica.RegiX.Client.Infrastructure.Models;

namespace TechnoLogica.RegiX.Client.IoC.Configuration.Profiles
{
    public class AsyncReportExecutionProfile : Profile
    {
        public AsyncReportExecutionProfile()
        {
            CreateMap<AsyncReportExecutionsInDto, AsyncReportExecutions>();
            CreateMap<AsyncReportExecutions, AsyncReportExecutionsOutDto>()
                .ForMember(
                    r => r.AdapterOperationDisplayName, 
                    ad => ad.MapFrom(m => m.AdapterOperation.DisplayOperationName)
                );
        }
    }
}