using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoLogica.RegiX.DataAccess.DTOs
{
    public class AuditDTO
    {
        public decimal AUDIT_EXCEPTION_ID { get; set; }
        public Nullable<System.DateTime> EXCEPTION_TIME { get; set; }
        public string EXCEPTION_TEXT { get; set; }
        public Nullable<decimal> USER_ID { get; set; }
        public string USER_NAME { get; set; }
        public string CONTROLLER { get; set; }
        public string ACTION_METHOD { get; set; }
    }
}