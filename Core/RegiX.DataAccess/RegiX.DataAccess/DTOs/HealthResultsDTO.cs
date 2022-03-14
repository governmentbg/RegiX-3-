using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoLogica.RegiX.DataAccess.DTOs
{
   public class HealthResultsDTO
    {
        public string AdapterName { get; set; }
        public DateTime ExecuteTime { get; set; }
        public DateTime EndPeriod { get; set; }
        public decimal? TIMEOUT { get; set; }
        public string HealthResult { get; set; }
        public string RowType { get; set; }

        public HealthResultsDTO() { }

        //public HealthResultsDTO(string adapterName) { }
    }
}
