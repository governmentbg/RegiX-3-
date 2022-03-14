using System;

namespace TechnoLogica.RegiX.Admin.Infrastructure.Models
{
    public abstract class BaseModel
    {
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
    }
}