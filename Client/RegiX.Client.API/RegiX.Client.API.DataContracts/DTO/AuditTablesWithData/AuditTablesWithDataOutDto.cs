using System.Collections.Generic;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.AuditValues;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.BaseDtos;

namespace TechnoLogica.RegiX.Client.API.DataContracts.DTO.AuditTablesWithData
{
    public class AuditTablesWithDataOutDto : ABaseOutDto
    {
        public string Action { get; set; }

        public string TableName { get; set; }

        public DisplayValue Authority { get; set; }

        public DisplayValue User { get; set; }

        public int TableId { get; set; }

        public IEnumerable<AuditValuesOutDto> AuditValues { get; set; }
    }
}