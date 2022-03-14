using AutoMapper;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.AuditValues;
using TechnoLogica.RegiX.Client.Infrastructure.Models;

namespace TechnoLogica.RegiX.Client.IoC.Configuration.Profiles
{
    public class AuditValuesProfile : Profile
    {
        public AuditValuesProfile()
        {
            // Configuration for AuditValues
            CreateMap<AuditValuesInDto, AuditValues>();
            CreateMap<AuditValues, AuditValuesOutDto>()
                .ForMember(r => r.AuditTable, ad => ad.MapFrom(m => new DisplayValue
                    {
                        Id = m.AuditTable.Id,
                        DisplayName = m.AuditTable.TableName
                    }
                ));
        }
    }
}