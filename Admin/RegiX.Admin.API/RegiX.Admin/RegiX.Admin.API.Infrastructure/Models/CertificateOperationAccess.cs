namespace TechnoLogica.RegiX.Admin.Infrastructure.Models
{
    public partial class CertificateOperationAccess : BaseModel
    {
        public decimal Id { get; set; }
        public decimal ConsumerCertificateId { get; set; }
        public decimal AdapterOperationId { get; set; }
        public bool HasAccess { get; set; }

        public virtual AdapterOperations AdapterOperation { get; set; }
        public virtual ConsumerCertificates ConsumerCertificate { get; set; }
    }
}