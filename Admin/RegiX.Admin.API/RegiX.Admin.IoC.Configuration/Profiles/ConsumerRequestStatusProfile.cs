using AutoMapper;
using TechnoLogica.API.DataContracts;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerRequestStatus;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.IoC.Configuration.Profiles
{
    public class ConsumerRequestStatusProfile : Profile
    {
        public ConsumerRequestStatusProfile()
        {
            //Configuration for ConsumerRequestStatus
            CreateMap<ConsumerRequestStatusInDto, ConsumerRequestStatus>();
            CreateMap<ConsumerRequestStatus, ConsumerRequestStatusOutDto>()
                .ForMember(r => r.ConsumerRequest, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.ConsumerRequest.ConsumerRequestId,
                    DisplayName = m.ConsumerRequest.Name
                }));

        }
    }
}