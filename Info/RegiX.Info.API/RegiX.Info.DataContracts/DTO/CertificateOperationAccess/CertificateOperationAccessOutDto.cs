using TechnoLogica.API.DataContracts;

namespace RegiX.Info.DataContracts.DTO.CertificateOperationAccess
{
    public class CertificateOperationAccessOutDto
    {
        public decimal Id { get; set; }
        public bool HasAccess { get; set; }
        public DisplayValue ConsumerCertificate { get; set; }
        public DisplayValue AdapterOperation { get; set; }
    }
}