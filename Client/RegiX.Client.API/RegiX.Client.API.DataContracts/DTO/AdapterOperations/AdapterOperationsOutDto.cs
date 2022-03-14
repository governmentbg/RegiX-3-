using TechnoLogica.RegiX.Client.API.DataContracts.DTO.BaseDtos;

namespace TechnoLogica.RegiX.Client.API.DataContracts.DTO.AdapterOperations
{
    public class AdapterOperationsOutDto : ABaseOutDto
    {
        public string OperationName { get; set; }

        public string DisplayOperationName { get; set; }

        public DisplayValue Register { get; set; }

        public string RegisterDisplayName { get; set; }

        public string Resource { get; set; }

        public bool IsActive { get; set; }

        public string Code { get; set; }

        public string ControllerName { get; set; }

        public string RequestObjectName { get; set; }

        public string Namespace { get; set; }

        public string Url { get; set; }
    }
}