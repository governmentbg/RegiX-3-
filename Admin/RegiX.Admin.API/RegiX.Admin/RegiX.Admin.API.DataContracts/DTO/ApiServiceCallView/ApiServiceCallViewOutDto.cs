using System;

namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ApiServiceCallView
{
    public class ApiServiceCallViewOutDto
    {
        public decimal PrimaryAdministrationId { get; set; } //Първична администрация
        public string PrimaryAdministrationName { get; set; }
        public decimal ApiServiceId { get; set; } //интерфейс
        public string ApiServiceName { get; set; }
        public decimal ApiServiceOperationId { get; set; } // операция
        public string ApiServiceOperationName { get; set; }
        public decimal ConsumerCertificateId { get; set; } //сертификат 
        public string ConsumerCertificateName { get; set; }
        public decimal ApiServiceConsumerId { get; set; }  //консуматор 
        public string ApiServiceConsumerName { get; set; }
        public decimal AdministrationId { get; set; } //администрация
        public string AdministrationName { get; set; }

        public decimal ApiServiceCallId { get; set; }
        public Guid? InstanceId { get; set; }
        public bool ResultReady { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public bool ResultReturned { get; set; }
        public string CallContext { get; set; }
        public string EidToken { get; set; }
        public string ClientIpAddress { get; set; }
        public string ResultContent { get; set; }
        public bool? HasError { get; set; }
        public string ErrorContent { get; set; }
        public string OidToken { get; set; }
        public string ContextSerivceUri { get; set; }
        public string ContextServiceType { get; set; }
        public string ContextEmployeeIdentifier { get; set; }
        public string ContextEmployeeNames { get; set; }
        public string ContextEmployeeAditionalId { get; set; }
        public string ContextEmployeePosition { get; set; }
        public string ContextAdministrationOid { get; set; }
        public string ContextAdministrationName { get; set; }
        public string ContextResponsibleNames { get; set; }
        public string ContextLawReason { get; set; }
        public string IpAddress { get; set; }
        public string AppName { get; set; }
    }
}
