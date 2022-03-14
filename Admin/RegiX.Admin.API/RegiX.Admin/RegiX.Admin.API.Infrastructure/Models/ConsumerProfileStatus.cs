using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechnoLogica.RegiX.Admin.Infrastructure.Models
{
    public partial class ConsumerProfileStatus
    {
        
        public decimal ConsumerProfileStatusId { get; set; }
        public decimal ConsumerProfileId { get; set; }
        public int OldStatus { get; set; }
        public int NewStatus { get; set; }
        public string Comment { get; set; }
        public DateTime? Date { get; set; }

        public virtual ConsumerProfiles ConsumerProfile { get; set; }
    }
}
