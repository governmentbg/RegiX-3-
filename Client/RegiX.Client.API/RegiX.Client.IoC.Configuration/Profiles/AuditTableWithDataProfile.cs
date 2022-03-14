using AutoMapper;
using TechnoLogica.API.DataContracts;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.AuditTablesWithData;
using TechnoLogica.RegiX.Client.Infrastructure.Models;

namespace TechnoLogica.RegiX.Client.IoC.Configuration.Profiles
{
    public class AuditTableWithDataProfile : Profile
    {
        public AuditTableWithDataProfile()
        {
            // Configuration for AuditTables
            CreateMap<AuditTablesWithDataInDto, AuditTables>();
            CreateMap<AuditTables, AuditTablesWithDataOutDto>()
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
