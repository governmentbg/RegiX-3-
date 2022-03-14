using System;
using System.Collections.Generic;
using System.Text;

namespace TechnoLogica.RegiX.Client.API.DataContracts.DTO.AuditReportExecution
{
    public class AuditReportExecutionWithResultOutDto : AuditReportExecutionOutDto
    {
        public string RequestXml { get; set; }
        public string ResponseXml { get; set; }
        public byte[] ResponsePdf { get; set; }
        public string RawRequestXml { get; set; }
        public string RawResponseXml { get; set; }
        public bool? SignatureVerified { get; set; }
        public byte[] SignatureCertirifcate { get; set; }
        public int AdapterOperationId { get; set; }
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
