namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerRoleElementAccess
{
    public class ConsumerRoleElementAccessInDto
    {
        public decimal ConsumerRoleId { get; set; }
        public decimal AdapterOperationId { get; set; }
        public decimal[] RegisterObjectElementIds { get; set; }
        public bool HasAccess { get; set; }
        //public string EditAccessComment { get; set; }
        //public decimal ConsumerCertificateId { get; set; }
        public decimal UserId { get; set; }
    }
}