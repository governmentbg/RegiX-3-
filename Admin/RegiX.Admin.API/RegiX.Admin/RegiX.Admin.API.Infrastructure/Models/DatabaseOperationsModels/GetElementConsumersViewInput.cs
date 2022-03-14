using System;
using System.Collections.Generic;
using System.Text;

namespace TechnoLogica.RegiX.Admin.Infrastructure.Models.DatabaseOperationsModels
{
    public class GetElementConsumersViewInput
    {
        public string ConsumerName { get; set; }
        public string ConsumerDescription { get; set; }
        public string ConsumerCertificate { get; set; }
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
    }
}
