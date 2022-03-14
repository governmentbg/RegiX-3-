using System;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.AdapterOperation;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerCertificate;

namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.CertificateOperationAccess
{
    public class CertificateOperationAccessOutDto
    {
        public decimal Id { get; set; }

        public bool HasAccess { get; set; }
        public string EditComment { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public decimal RegisterObjectId { get; set; }
        public AdapterOperationDto AdapterOperation { get; set; }
        public ConsumerCertificateDto ConsumerCertificate { get; set; }
    }
}