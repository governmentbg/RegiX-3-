using TechnoLogica.RegiX.Client.API.DataContracts.DTO.BaseDtos;

namespace TechnoLogica.RegiX.Client.API.DataContracts.DTO.AuditSystemReportExecutions
{
    public class AuditSystemReportExecutionsOutDto : ABaseOutDto
    {
        public DisplayValue AdapterOperation { get; set; }
        public string ExceptionMessage { get; set; }
        public string RequestXml { get; set; }
        public string ResponseXml { get; set; }
        public string Stacktrace { get; set; }
    }
}