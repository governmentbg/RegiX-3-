using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoLogica.RegiX.DataAccess.DTOs
{
    public class OperationDTO
    {
        public decimal ConsumerCertificateId { get; set; }
        public string ConsumerCertificateName { get; set; }
        public decimal  AdapterOperationId{ get; set; }
        public bool HasAccess{ get; set; }
        public string AdapterOperationName { get; set; }
        public string AdapterOperationDescription{ get; set; }
        public string RegisterAdapterName{ get; set; }
        public string RegisterAdapterDescription { get; set; }
        public string RegisterName { get; set; }
        public string RegisterDescription{ get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}