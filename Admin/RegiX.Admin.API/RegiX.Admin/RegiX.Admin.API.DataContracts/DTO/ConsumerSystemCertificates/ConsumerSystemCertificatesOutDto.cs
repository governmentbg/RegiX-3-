using System;
using TechnoLogica.API.DataContracts;

namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerSystemCertificates
{
    public class ConsumerSystemCertificatesOutDto
    {
        public decimal Id { get; set; }
        public byte[] Csr { get; set; }
        public byte[] Content { get; set; }
        public DateTime RequestDate { get; set; }
        public string Environment { get; set; }
        public string Name { get; set; }
        public  DisplayValue ConsumerCertificate { get; set; }
        public DisplayValue ConsumerSystem { get; set; }
    }
}