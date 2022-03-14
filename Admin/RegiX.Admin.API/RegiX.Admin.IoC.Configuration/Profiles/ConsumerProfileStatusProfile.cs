using AutoMapper;
using TechnoLogica.API.DataContracts;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerProfileStatus;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.IoC.Configuration.Profiles
{
    public class ConsumerProfileStatusProfile : Profile
    {
        public ConsumerProfileStatusProfile()
        {
            //Configuration for ConsumerProfiles
            CreateMap<ConsumerProfileStatusInDto, ConsumerProfileStatus>();

            CreateMap<ConsumerProfileStatus, ConsumerProfileStatusOutDto>()
                .ForMember(r => r.Id, rd => rd.MapFrom(m => m.ConsumerProfileStatusId))
                .ForMember(r => r.ConsumerProfile, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.ConsumerProfile.ConsumerProfileId,
                    DisplayName = m.ConsumerProfile.Name
                }));

        }
    }
}