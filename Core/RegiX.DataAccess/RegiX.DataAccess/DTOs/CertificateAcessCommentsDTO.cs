using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoLogica.RegiX.DataAccess.DTOs
{
    public class CertificateAcessCommentsDTO
    {
        public decimal Id { get; set; }
        public decimal ConsumerCertificateId { get; set; }
        public decimal AdapterOperationId { get; set; }
        public string Comment { get; set; }
        public DateTime DateTime { get; set; }
        public string Username { get; set; }
    }
}
