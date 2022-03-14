using TechnoLogica.API.DataContracts;

namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.CertificateElementAccess
{
    public class CertificateElementAccessOutDto
    {
        public decimal Id { get; set; }
        public bool HasAccess { get; set; }
        public decimal RegisterObjectId { get; set; }
        public DisplayValue ConsumerCertificate { get; set; }
        public DisplayValue RegisterObjectElement { get; set; }
    }
}