using System;
using TechnoLogica.API.DataContracts;
using TechnoLogica.RegiX.AdapterConsole.DataContracts.DTO;

namespace TechnoLogica.RegiX.AdapterConsole.DataContracts.OperationCalls
{
    public class MyOperationCallsOutDto
    {
        public int Id { get; set; }
        public DisplayValue AdapterOperation { get; set; }
        public int ApiServiceCallId { get; set; }
        public DateTime StartTime { get; set; }
        public string RequestXML { get; set; }
        public string ResponseXML { get; set; }
        public DisplayValue AssignedTo { get; set; }
        public ParamsValues[] RequestParamsValues { get; set; }
        public ParamsValues[] ResponseParamsValues { get; set; }
    }
}