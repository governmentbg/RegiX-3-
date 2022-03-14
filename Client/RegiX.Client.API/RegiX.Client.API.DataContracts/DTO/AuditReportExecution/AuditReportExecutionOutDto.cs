using System;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.BaseDtos;

namespace TechnoLogica.RegiX.Client.API.DataContracts.DTO.AuditReportExecution
{
    public class AuditReportExecutionOutDto
    {
        public int Id { get; set; }
        public DisplayValue Report { get; set; }
        public DisplayValue Authority { get; set; }
        public DisplayValue User { get; set; }
        public DateTime ReportExecutionTime { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ContextServiceURI { get; set; }
        public string ContextServiceType { get; set; }
        public string ContextLawReason { get; set; }
        public string ContextEmployeeAdditionalId { get; set; }
        public decimal? ApiServiceCallId { get; set; }
        public bool? HasError { get; set; }
    }
}