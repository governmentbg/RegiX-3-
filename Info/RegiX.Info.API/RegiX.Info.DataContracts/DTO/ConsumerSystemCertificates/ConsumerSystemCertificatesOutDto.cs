using TechnoLogica.API.DataContracts;

namespace RegiX.Info.DataContracts.DTO.ConsumerSystemCertificates
{
    public class ConsumerSystemCertificatesOutDto
    {
        public decimal Id { get; set; }
        public string Csr { get; set; }
        public byte[] Content { get; set; }
        public string Name { get; set; }
        public string Environment { get; set; }
        public  DisplayValue ConsumerSystem { get; set; }
        public  DisplayValue ConsumerCertificate { get; set; }

    }
}
