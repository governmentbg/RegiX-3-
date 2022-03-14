using TechnoLogica.API.DataContracts;

namespace RegiX.Info.DataContracts.DTO.CertificateElementAccess
{
    public class CertificateElementAccessOutDto
    {
        public decimal Id { get; set; }
        public DisplayValue ConsumerCertificate { get; set; }
        public DisplayValue RegisterObjectElement { get; set; }
        public bool HasAccess { get; set; }
    }
}