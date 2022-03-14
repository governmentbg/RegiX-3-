using TechnoLogica.API.DataContracts;

namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerCertificatesReport
{
    public class ConsumerCertificatesReportOutDto
    {
        public decimal Id { get; set; }
        public DisplayValue Report { get; set; }
        public DisplayValue ConsumerCertificate { get; set; }
    }
}