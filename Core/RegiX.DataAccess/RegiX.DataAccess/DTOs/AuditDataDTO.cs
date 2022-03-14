using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoLogica.RegiX.DataAccess.DTOs
{
    public class AuditDataDTO
    {
        public decimal ID { get; set; }
        public Nullable<decimal> USER_ID { get; set; }
        public string USER_NAME { get; set; }
        public System.DateTime AUDIT_DATE { get; set; }
        //public System.DateTime AUDIT_DATE_HIDDEN { get; set; }
        public string ACTION { get; set; }
        public string TABLE_NAME { get; set; }
        public decimal TABLE_ID { get; set; }
        public string DESCRIPTION { get; set; }
        public string APP_NAME { get; set; }
        public string IP_ADDRESS { get; set; }

        public IEnumerable<AuditValuesListViewModel> AUDIT_VALUES { get; set; }
    }

    public class AuditValuesListViewModel
    {
        public decimal ID { get; set; }
        public decimal AUDIT_TABLE_ID { get; set; }
        public string COLUMN_NAME { get; set; }
        public string OLD_VALUE { get; set; }
        public string NEW_VALUE { get; set; }
    }
}
