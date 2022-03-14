using AutoMapper;
using TechnoLogica.API.DataContracts;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.OperationsErrorLog;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace RegiX.Admin.IoC.Configuration.Profiles
{
    public class OperationsErrorLogProfile : Profile
    {
        public OperationsErrorLogProfile()
        {
            //Configuration for OperationsErrorLog
            CreateMap<OperationsErrorLogInDto, OperationsErrorLog>();
            CreateMap<OperationsErrorLog, OperationsErrorLogOutDto>()
                .ForMember(r => r.Id, rd => rd.MapFrom(m => m.OperationsErrorLogId))
                .ForMember(r => r.AdapterOperation, ad => ad.MapFrom(m => new DisplayValue()
                        {
                            Id = m.AdapterOperation.AdapterOperationId,
                            DisplayName = m.AdapterOperation.Name
                        }
                    )
                )
                .ForMember(r => r.ApiServiceCall, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.ApiServiceCall.ApiServiceCallId,
                    DisplayName = m.ApiServiceCall.ApiServiceOperation.ApiService.Name
                }))
                .ForMember(r => r.ApiServiceConsumer, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.ApiServiceCall.ConsumerCertificate.ApiServiceConsumer.ApiServiceConsumerId,
                    DisplayName = m.ApiServiceCall.ConsumerCertificate.ApiServiceConsumer.Name
                }))
                .ForMember(r => r.Administration, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.ApiServiceCall.ConsumerCertificate.ApiServiceConsumer.Administration.AdministrationId,
                    DisplayName = m.ApiServiceCall.ConsumerCertificate.ApiServiceConsumer.Administration.Name
                }))
                .ForMember(r => r.ConsumerCertificate, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.ApiServiceCall.ConsumerCertificate.ConsumerCertificateId,
                    DisplayName = m.ApiServiceCall.ConsumerCertificate.Name
                }))
                .ForMember(r => r.ApiServiceOperations, ad => ad.MapFrom(m => new DisplayValue()
                {
                    Id = m.ApiServiceOperation.ApiServiceOperationId,
                    DisplayName = m.ApiServiceOperation.Name

                }));
        }
    }
}