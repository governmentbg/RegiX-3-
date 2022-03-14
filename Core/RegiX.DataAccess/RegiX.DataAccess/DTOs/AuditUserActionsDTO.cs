using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoLogica.RegiX.DataAccess.DTOs
{
    public class AuditUserActionsDTO
    {
        public decimal AUDIT_USER_ACTION_ID { get; set; }
        public Nullable<System.DateTime> USER_ACTION_TIME { get; set; }
        public string USER_ACTION_TEXT { get; set; }
        public string USER_ACTION_TYPE { get; set; }
        public Nullable<decimal> USER_ID { get; set; }
        public string USER_NAME { get; set; }
        public string CONTROLLER { get; set; }
        public string ACTION_METHOD { get; set; }
        public string EXECUTE_STATUS { get; set; }
        public string PARAMS { get; set; }
        public string URL { get; set; }
        public string CHANGED_TABLES { get; set; }
        public string IP_ADDRESS { get; set; }
    }
}
