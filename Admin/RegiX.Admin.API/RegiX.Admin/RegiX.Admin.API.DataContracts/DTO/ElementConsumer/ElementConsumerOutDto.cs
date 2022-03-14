using System;

namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ElementConsumer
{
    public class ElementConsumerOutDto
    {
        public string ConsumerName { get; set; }
        public string ConsumerDescription { get; set; }
        public string ConsumerNameWithoutOID { get; set; }
        public string ConsumerOID { get; set; }
        public string ConsumerCertificate { get; set; }
        public string CertificateThumbprint { get; set; }
        public string AdministrationName { get; set; }
        public string RegisterName { get; set; }
        public string AdapterName { get; set; }
        public string OperationName { get; set; }
        public string OperationNameEn { get; set; }
        public decimal? AdministrationId { get; set; }
        public decimal? RegisterId { get; set; }
        public decimal? AdapterId { get; set; }
        public decimal? OperationId { get; set; }
        public decimal? ConsumerId { get; set; }
        public decimal? CertificateId { get; set; }
        public decimal? ConsumerAdministrationId { get; set; }
        public bool? CertificateIsActive { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
