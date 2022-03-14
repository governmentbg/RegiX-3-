namespace TechnoLogica.RegiX.Client.Infrastructure.Models
{
    public partial class AuditSystemReportExecutions : BaseModel
    {
        public int Id { get; set; }
        public int AdapterOperationId { get; set; }
        public string ExceptionMessage { get; set; }
        public string RequestXml { get; set; }
        public string ResponseXml { get; set; }
        public string Stacktrace { get; set; }

        public virtual AdapterOperations AdapterOperation { get; set; }
    }
}