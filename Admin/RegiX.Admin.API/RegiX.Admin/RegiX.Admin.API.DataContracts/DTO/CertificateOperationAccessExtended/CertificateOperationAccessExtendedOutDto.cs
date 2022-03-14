namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ElementConsumers
{
    public class CertificateOperationAccessExtendedOutDto
    {
        public decimal CertificateOperationAccessId { get; set; }
        public bool CertificateOperationAccessHasAccess { get; set; }
        public string AdapterOperationName { get; set; }
        public string AdapterOperationDescription { get; set; }
        public string RegisterObjectName { get; set; }
        public string RegisterObjectFullName { get; set; }
        public string RegisterObjectDescription { get; set; }
        public string RegisterObjectContent { get; set; }
        public string RegisterObjectXslt { get; set; }
    }
}