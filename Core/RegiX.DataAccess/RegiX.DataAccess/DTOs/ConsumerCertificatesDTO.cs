using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoLogica.RegiX.DataAccess.DTOs
{
    public class ConsumerCertificatesDTO
    {
        public decimal ConsumerId { get; set; }
        public decimal AdapterOperationId { get; set; }
        public decimal ConsumerCertificateId { get; set; }
        public string CertificateName { get; set; }
        public string CertificateDescription { get; set; }
        public string ConsumerName { get; set; }
        public string ConsumerDescription { get; set; }
        public string OID { get; set; }
    }
}
