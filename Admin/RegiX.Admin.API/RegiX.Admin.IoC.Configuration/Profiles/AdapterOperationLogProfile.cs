using AutoMapper;
using TechnoLogica.API.DataContracts;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.AdapterOperationLog;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace RegiX.Admin.IoC.Configuration.Profiles
{
    public class AdapterOperationLogProfile : Profile
    {
        public AdapterOperationLogProfile()
        {
            //Configuration for AdapterOperationLog
            CreateMap<AdapterOperationLogInDto, AdapterOperationLog>();
            CreateMap<AdapterOperationLog, AdapterOperationLogOutDto>()
                .ForMember(r => r.Id, rd => rd.MapFrom(m => m.AdapterOperationLogId))
                .ForMember(r => r.AdapterOperation, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.AdapterOperation.AdapterOperationId,
                    DisplayName = m.AdapterOperation.Name
                }));
        }
    }
}