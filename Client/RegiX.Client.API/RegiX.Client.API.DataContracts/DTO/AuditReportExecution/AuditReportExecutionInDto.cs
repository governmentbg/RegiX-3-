using System;

namespace TechnoLogica.RegiX.Client.API.DataContracts.DTO.AuditReportExecution
{
    public class AuditReportExecutionInDto
    {
        public int ReportId { get; set; }
        public int AuthorityId { get; set; }
        public int UserId { get; set; }
        public DateTime ReportExecutionTime { get; set; }
        public string RequestXml { get; set; }
        public string ResponseXml { get; set; }
        public string ContextServiceURI { get; set; }
        public string ContextServiceType { get; set; }
        public string ContextLawReason { get; set; }
        public string CallContext { get; set; }
        public string ContextEmployeeAdditionalId { get; set; }
        public decimal? ApiServiceCallId { get; set; }
        public bool? HasError { get; set; }
        public string RegisterErrorMessage { get; set; }
        public string RegisterErrorContent { get; set; }
        public string UnhandledErrorMessage { get; set; }
        public string UnhandledErrorContent { get; set; }
    }
}