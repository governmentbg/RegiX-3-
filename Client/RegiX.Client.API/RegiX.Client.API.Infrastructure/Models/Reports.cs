using System.Collections.Generic;

namespace TechnoLogica.RegiX.Client.Infrastructure.Models
{
    public partial class Reports : BaseModel
    {
        public Reports()
        {
            AuditReportExecutions = new HashSet<AuditReportExecutions>();
            RolesToReports = new HashSet<RolesToReports>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int AdapterOperationId { get; set; }
        public string LawReason { get; set; }
        public int? OrderNumber { get; set; }
        public string Code { get; set; }
        public string ResponseXslt { get; set; }
        public int? AuthorityId { get; set; }

        public virtual AdapterOperations AdapterOperation { get; set; }
        public virtual Authorities Authority { get; set; }
        public virtual ICollection<AuditReportExecutions> AuditReportExecutions { get; set; }
        public virtual ICollection<RolesToReports> RolesToReports { get; set; }
    }
}