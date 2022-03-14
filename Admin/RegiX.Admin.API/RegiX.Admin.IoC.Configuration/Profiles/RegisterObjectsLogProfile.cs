using AutoMapper;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.RegisterObjectsLog;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace RegiX.Admin.IoC.Configuration.Profiles
{
    public class RegisterObjectsLogProfile : Profile
    {
        public RegisterObjectsLogProfile()
        {
            // Configuration for RegisterObjectsLog
            CreateMap<RegisterObjectsLogInDto, RegisterObjectsLog>();
            CreateMap<RegisterObjectsLog, RegisterObjectsLogOutDto>()
                .ForMember(r => r.Id, rd => rd.MapFrom(m => m.RegisterObjectsLogId));
        }
    }
}