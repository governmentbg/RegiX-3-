using System.Collections.Generic;

namespace TechnoLogica.RegiX.Client.Infrastructure.Models
{
    public partial class AdapterOperations : BaseModel
    {
        public AdapterOperations()
        {
            AuditSystemReportExecutions = new HashSet<AuditSystemReportExecutions>();
            ParametersToOperation = new HashSet<ParametersToOperation>();
            Reports = new HashSet<Reports>();
            AsyncReportExecutions = new HashSet<AsyncReportExecutions>();
        }

        public int Id { get; set; }
        public string OperationName { get; set; }
        public string DisplayOperationName { get; set; }
        public int RegisterId { get; set; }
        public string Resource { get; set; }
        public bool IsActive { get; set; }
        public string Code { get; set; }
        public string ControllerName { get; set; }
        public string RequestObjectName { get; set; }
        public string Namespace { get; set; }
        public string Url { get; set; }
        public string ResponseXslt { get; set; }
        public string RequestXslt { get; set; }
        public string MetadataXml { get; set; }

        public virtual Registers Register { get; set; }
        public virtual ICollection<AuditSystemReportExecutions> AuditSystemReportExecutions { get; set; }
        public virtual ICollection<ParametersToOperation> ParametersToOperation { get; set; }
        public virtual ICollection<Reports> Reports { get; set; }
        public virtual ICollection<AsyncReportExecutions> AsyncReportExecutions { get; set; }
    }
}