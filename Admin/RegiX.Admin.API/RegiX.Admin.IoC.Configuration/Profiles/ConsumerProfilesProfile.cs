using AutoMapper;
using TechnoLogica.API.DataContracts;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerProfiles;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace RegiX.Admin.IoC.Configuration.Profiles
{
    public class ConsumerProfilesProfile : Profile
    {
        public ConsumerProfilesProfile()
        {
            //Configuration for ConsumerProfiles
            CreateMap<ConsumerProfilesInDto, ConsumerProfiles>()
                .ForMember(r => r.ConsumerProfileId, rd => rd.MapFrom(m => m.Id))
                .ForMember(r => r.AdministrationId, rd => rd.MapFrom(m => m.Administration.Id))
                .ForSourceMember(x => x.Comment, opt => opt.Ignore())
                .ForMember(x => x.Administration, opt => opt.Ignore());
                
            CreateMap<ConsumerProfiles, ConsumerProfilesOutDto>()
                .ForMember(r => r.Id, rd => rd.MapFrom(m => m.ConsumerProfileId))
                .ForMember(r => r.Administration, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.Administration.AdministrationId,
                    DisplayName = m.Administration.Name
                }));

        }
    }
}