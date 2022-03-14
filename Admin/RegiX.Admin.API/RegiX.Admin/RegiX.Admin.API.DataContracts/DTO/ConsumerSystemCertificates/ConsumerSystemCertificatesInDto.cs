using System;
using TechnoLogica.API.DataContracts;

namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerSystemCertificates
{
    public class ConsumerSystemCertificatesInDto
    {
        public decimal Id { get; set; }
        public byte[] Csr { get; set; }
        public string Content { get; set; }
        public DateTime RequestDate { get; set; }
        public string Environment { get; set; }
        public DisplayValue ConsumerCertificate { get; set; }
        public DisplayValue ConsumerSystem { get; set; }
    }
}