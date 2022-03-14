using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoLogica.RegiX.DataAccess.DTOs
{
    public class HealthServicePingDTO
    {
        public int ID { get; set; }
        public DateTime Time { get; set; }
        public string ServiceName { get; set; }
    }
}
