namespace TechnoLogica.RegiX.Client.API.DataContracts.DTO.AuditSystemReportExecutions
{
    public class AuditSystemReportExecutionsInDto
    {
        public int AdapterOperationId { get; set; }
        public string ExceptionMessage { get; set; }
        public string RequestXml { get; set; }
        public string ResponseXml { get; set; }
        public string Stacktrace { get; set; }
    }
}