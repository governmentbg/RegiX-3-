using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoLogica.RegiX.DataAccess.DTOs
{
    public class AdapterDTO
    {
        public decimal AdapterId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AdapterUrl { get; set; }
        public string BingingConfigName { get; set; }
        public string Contract { get; set; }
        public string BindingType { get; set; }
        public string Behaviour { get; set; }
        public string RegisterName { get; set; }

        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
