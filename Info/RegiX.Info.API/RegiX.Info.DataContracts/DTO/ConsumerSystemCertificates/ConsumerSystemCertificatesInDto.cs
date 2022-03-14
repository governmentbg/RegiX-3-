using TechnoLogica.API.DataContracts;

namespace RegiX.Info.DataContracts.DTO.ConsumerSystemCertificates
{
    public class ConsumerSystemCertificatesInDto
    {
        public string Csr { get; set; }
        public string Name { get; set; }
        public string Environment { get; set; }
        public DisplayValue ConsumerSystem { get; set; }
    }
}
