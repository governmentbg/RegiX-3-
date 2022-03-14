using System;
using TechnoLogica.API.DataContracts;

namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.CertificateConsumerRole
{
    public class CertificateConsumerRoleOutDto
    {
        public decimal Id { get; set; }
        public DisplayValue ConsumerCertificate { get; set; }
        public DisplayValue ConsumerRole { get; set; }
        public DateTime CreatedTime { get; set; }
        public string EditAccessComment { get; set; }
        public decimal UserId { get; set; }
    }
}