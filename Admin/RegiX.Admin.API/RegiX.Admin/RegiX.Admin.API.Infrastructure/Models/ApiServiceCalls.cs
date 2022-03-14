using System;
using System.Collections.Generic;

namespace TechnoLogica.RegiX.Admin.Infrastructure.Models
{
    public partial class ApiServiceCalls
    {
        public ApiServiceCalls()
        {
            OperationsErrorLog = new HashSet<OperationsErrorLog>();
        }

        public decimal ApiServiceCallId { get; set; }
        public Guid? InstanceId { get; set; }
        public bool ResultReady { get; set; }
        public decimal ApiServiceOperationId { get; set; }
        public decimal ConsumerCertificateId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public bool ResultReturned { get; set; }
        public string CallContext { get; set; }
        public string EidToken { get; set; }
        public string ClientIpAddress { get; set; }
        public string ResultContent { get; set; }
        public bool? HasError { get; set; }
        public string ErrorContent { get; set; }
        public string OidToken { get; set; }
        public string ContextSerivceUri { get; set; }
        public string ContextServiceType { get; set; }
        public string ContextEmployeeIdentifier { get; set; }
        public string ContextEmployeeNames { get; set; }
        public string ContextEmployeeAditionalId { get; set; }
        public string ContextEmployeePosition { get; set; }
        public string ContextAdministrationOid { get; set; }
        public string ContextAdministrationName { get; set; }
        public string ContextResponsibleNames { get; set; }
        public string ContextLawReason { get; set; }
        public string IpAddress { get; set; }
        public string AppName { get; set; }

        public virtual ApiServiceOperations ApiServiceOperation { get; set; }
        public virtual ConsumerCertificates ConsumerCertificate { get; set; }
        public virtual ICollection<OperationsErrorLog> OperationsErrorLog { get; set; }
    }
}