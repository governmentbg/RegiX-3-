using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoLogica.RegiX.DataAccess.DTOs
{
    public class StatisticsDTO
    {
        public decimal LogID { get; set; }

        public string ConsumerAdministration { get; set; }
        public decimal ConsumerAdministrationID { get; set; }
        public string ConsumerName { get; set; }
        public decimal ConsumerID { get; set; }

        public string RegisterAdministration { get; set; }
        public decimal RegisterAdministrationID { get; set; }

        public string OperationName { get; set; }
        public string OperationDescription { get; set; }
        public decimal OperationID { get; set; }

        public string RegisterInterfaceDescription { get; set; }
        public string RegisterInterfaceName { get; set; }
        public decimal ServiceID { get; set; }

        public decimal Count { get; set; }
    }
}
