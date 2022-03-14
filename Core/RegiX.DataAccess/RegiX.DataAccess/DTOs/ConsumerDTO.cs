using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoLogica.RegiX.DataAccess.DTOs
{
    public class ConsumerDTO
    {
        public decimal ConsumerId { get; set; }
        public string ConsumerName { get; set; }
        public string Description { get; set; }
        public string OID { get; set; }
        public decimal? AdministrationId { get; set; }
        public string AdministrationName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
