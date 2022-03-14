using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoLogica.RegiX.DataAccess.DTOs
{
   public class ParameterValueLogsDTO
    {
        public decimal Id { get; set; }
        public string Key{get; set;}
        public decimal AdapterId { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public DateTime EditedTime { get; set; }
        public string Username { get; set; }
    }
}
              