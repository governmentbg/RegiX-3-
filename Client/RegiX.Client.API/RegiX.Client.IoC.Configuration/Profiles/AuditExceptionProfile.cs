using AutoMapper;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.AuditExceptions;
using TechnoLogica.RegiX.Client.Infrastructure.Models;

namespace TechnoLogica.RegiX.Client.IoC.Configuration.Profiles
{
    public class AuditExceptionProfile : Profile
    {
        public AuditExceptionProfile()
        {
            CreateMap<AuditExceptionsInDto, AuditExceptions>();
            CreateMap<AuditExceptions, AuditExceptionsOutDto>()
                .ForMember(r => r.Authority, ad => ad.MapFrom(m => new DisplayValue
                    {
                        Id = m.Authority.Id,
                        DisplayName = m.Authority.Name
                    }
                ))
                .ForMember(r => r.User, ad => ad.MapFrom(m => new DisplayValue
                    {
                        Id = m.User.Id,
                        DisplayName = m.User.UserName
                    }
                ));
        }
    }
}