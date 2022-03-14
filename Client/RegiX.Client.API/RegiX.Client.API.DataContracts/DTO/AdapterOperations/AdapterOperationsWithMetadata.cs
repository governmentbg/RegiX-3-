using System;
using System.Collections.Generic;
using System.Text;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.BaseDtos;

namespace TechnoLogica.RegiX.Client.API.DataContracts.DTO.AdapterOperations
{
    public class AdapterOperationsWithMetadata : AdapterOperationsOutDto
    { 
        public string MetadataXml { get; set; }
        public string RequestXSLT { get; set; }
        public string ResponseXSLT { get; set; }
    }
}
