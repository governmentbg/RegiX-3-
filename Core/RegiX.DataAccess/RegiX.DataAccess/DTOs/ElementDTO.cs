using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoLogica.RegiX.DataAccess.DTOs
{
    public class ElementDTO
    {
        public decimal AdapterOperationId { get; set; }
        public decimal ConsumerCertificateId { get; set; }
        public string ObjectName { get; set; }
        public string ObjectFullName { get; set; }
        public string ElementName { get; set; }
        public string ElementDescription { get; set; }
        public bool HasAccess { get; set; }
        public string Path { get; set; }
    }
    public class OperationElementDTO
    {
        public decimal AdapterOperationId { get; set; }
        public decimal ConsumerCertificateId { get; set; }
        public string Path { get; set; }
        public decimal OperationElementId { get; set; }
    }
    public class ElementConsumersDTO
    {
        public string ConsumerName { get; set; }
        public string ConsumerNameWithoutOID { get; set; }
        public string ConsumerOID { get; set; }
        public decimal ConsumerId { get; set; }
        public string ConsumerCertificate { get; set; }
        public string CertificateThumbprint { get; set; }
        public string RegisterName { get; set; }
        public string AdapterName { get; set; }
        public string OperationName { get; set; }
        public string OperationNameEN { get; set; }
        public string ElementPathToRoot { get; set; }
        public bool CertificateIsActive { get; set; }

        public decimal AdministrationId { get; set; }
        public decimal RegisterId { get; set; }
        public decimal AdapterId { get; set; }
        public decimal OperationId { get; set; }
        public decimal ElementId { get; set; }
        public decimal CertificateId { get; set; }
        public bool IncludeElements { get; set; }
        public decimal? ConsumerAdministrationId { get; set; }

        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
    public class ElementConsumersDTO2
    {
        public string ConsumerName { get; set; }
        public string ConsumerCertificate { get; set; }
        public string RegisterName { get; set; }
        public string AdapterName { get; set; }
        public string OperationName { get; set; }
        public string ElementPathToRoot { get; set; }
    }
}
