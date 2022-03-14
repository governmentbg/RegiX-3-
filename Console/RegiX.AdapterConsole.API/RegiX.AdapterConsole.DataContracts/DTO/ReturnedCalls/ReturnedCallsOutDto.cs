using System;
using TechnoLogica.API.DataContracts;
using TechnoLogica.RegiX.AdapterConsole.DataContracts.DTO;

namespace TechnoLogica.RegiX.AdapterConsole.DataContracts.ReturnedCalls
{
    public class ReturnedCallsOutDto
    {
        public int Id { get; set; }
        public DisplayValue AdapterOperation { get; set; }
        public DisplayValue ApiServiceCall { get; set; }
        public DateTime StartTime { get; set; }
        public DisplayValue ReturnedBy { get; set; }
        public ParamsValues[] RequestParamsValues { get; set; }
        public ParamsValues[] ResponseParamsValues { get; set; }
        public string Response { get; set; }
        public string Request { get; set; }
    }
}