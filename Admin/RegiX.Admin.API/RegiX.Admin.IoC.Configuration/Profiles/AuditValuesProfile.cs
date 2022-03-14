using AutoMapper;
using TechnoLogica.API.DataContracts;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.AuditValue;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace RegiX.Admin.IoC.Configuration.Profiles
{
    public class AuditValuesProfile : Profile
    {
        public AuditValuesProfile()
        {
            //Configuration for AuditValues
            CreateMap<AuditValueInDto, AuditValues>();

            CreateMap<AuditValues, AuditValueWithDataOutDto>()
            .ForMember(r => r.Id, rd => rd.MapFrom(m => m.Id))
            .ForMember(r => r.AuditTable, ad => ad.MapFrom(m => new DisplayValue()
            {
                Id = m.AuditTable.Id,
                DisplayName = m.AuditTable.TableName
            }));

            CreateMap<AuditValues, AuditValueOutDto>()
                  .ForMember(r => r.Id, rd => rd.MapFrom(m => m.Id))
                  .ForMember(r => r.AuditTable, ad => ad.MapFrom(m => new DisplayValue()
                  {
                      Id = m.AuditTable.Id,
                      DisplayName = m.AuditTable.TableName
                  }));
        }

    }
}