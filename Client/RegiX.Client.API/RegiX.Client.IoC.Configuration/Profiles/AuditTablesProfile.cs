using AutoMapper;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.AuditTables;
using TechnoLogica.RegiX.Client.Infrastructure.Models;

namespace TechnoLogica.RegiX.Client.IoC.Configuration.Profiles
{
    public class AuditTablesProfile : Profile
    {
        public AuditTablesProfile()
        {
            // Configuration for AuditTables
            CreateMap<AuditTablesInDto, AuditTables>();
            CreateMap<AuditTables, AuditTablesOutDto>()
                .ForMember(r => r.User, ad => ad.MapFrom(m => new DisplayValue
                    {
                        Id = m.User.Id,
                        DisplayName = m.User.UserName
                    }
                ))
                .ForMember(r => r.Authority, ad => ad.MapFrom(m => new DisplayValue
                    {
                        Id = m.Authority.Id,
                        DisplayName = m.Authority.Name
                    }
                ));
        }
    }
}