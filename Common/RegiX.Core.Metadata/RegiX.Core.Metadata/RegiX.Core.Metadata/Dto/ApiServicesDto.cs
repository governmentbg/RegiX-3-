using System.Collections.Generic;

namespace RegiX.Core.Metadata.Dto
{
    public class ApiServicesDto
    {
        public string Code { get; set; }

        public string Contract { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public string ServiceUrl { get; set; }

        public IEnumerable<ApiServiceOperationDto> ApiServiceOperations { get; set; }
    }
}
