namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.CertificateAccessComment
{
    public class CertificateAccessCommentInDto
    {
        public string EditAccessComment { get; set; }
        public decimal UserId { get; set; }
        public decimal ConsumerCertificateId { get; set; }
        public decimal AdapterOperationId { get; set; }
    }
}