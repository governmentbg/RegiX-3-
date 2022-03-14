namespace RegiX.Info.Infrastructure.Models
{
    public partial class CertificateElementAccess
    {
        public decimal Id { get; set; }
        public decimal ConsumerCertificateId { get; set; }
        public decimal RegisterObjectElementId { get; set; }
        public bool HasAccess { get; set; }

        public virtual ConsumerCertificates ConsumerCertificate { get; set; }
        public virtual RegisterObjectElements RegisterObjectElement { get; set; }
    }
}
