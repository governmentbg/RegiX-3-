using AutoMapper;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.Reports;
using TechnoLogica.RegiX.Client.Infrastructure.Models;

namespace TechnoLogica.RegiX.Client.IoC.Configuration.Profiles
{
    public class ReportProfile : Profile
    {
        public ReportProfile()
        {
            // Configuration for Reports
            CreateMap<ReportsInDto, Reports>();
            CreateMap<Reports, ReportsOutDto>()
                .ForMember(r => r.AdapterOperation, ad => ad.MapFrom(m => new DisplayValue
                    {
                        Id = m.AdapterOperation.Id,
                        DisplayName = m.AdapterOperation.DisplayOperationName
                    }
                ))
                .ForMember(r => r.Register, ad => ad.MapFrom(m => new DisplayValue
                    {
                        Id = m.AdapterOperation.Register.Id,
                        DisplayName = m.AdapterOperation.Register.Name
                    }
                ))
                .ForMember(r => r.RegisterAuthority, ad => ad.MapFrom(m => new DisplayValue
                    {
                        Id = m.AdapterOperation.Register.Authority.Id,
                        DisplayName = m.AdapterOperation.Register.Authority.Name
                    }
                ))
                .ForMember(r => r.Authority, ad => ad.MapFrom(m => new DisplayValue
                {
                    Id = m.Authority.Id,
                    DisplayName = m.Authority.Name
                }));
        }
    }
}