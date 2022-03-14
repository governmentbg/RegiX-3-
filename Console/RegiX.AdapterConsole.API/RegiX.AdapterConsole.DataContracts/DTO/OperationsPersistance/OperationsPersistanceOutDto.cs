using System;
using System.Collections.Generic;
using System.Text;

namespace TechnoLogica.RegiX.AdapterConsole.DataContracts.DTO.OperationsPersistance
{
    public class OperationsPersistanceOutDto
    {
        public int Id { get; set; }
        public int ApiServiceCallId { get; set; }        
        public int? AdapterOperationId { get; set; }        
        public string RawResult { get; set; }                                
        public string RawUnsignedResult { get; set; }
        public string AdapterOperationName { get; set; }
    }
}
