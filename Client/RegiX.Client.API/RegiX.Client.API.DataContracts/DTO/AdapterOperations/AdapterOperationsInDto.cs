namespace TechnoLogica.RegiX.Client.API.DataContracts.DTO.AdapterOperations
{
    public class AdapterOperationsInDto
    {
        public string OperationName { get; set; }

        public string DisplayOperationName { get; set; }

        public int RegisterId { get; set; }

        public string Resource { get; set; }

        public bool IsActive { get; set; }

        public string Code { get; set; }

        public string ControllerName { get; set; }

        public string RequestObjectName { get; set; }

        public string Namespace { get; set; }

        public string Url { get; set; }
    }
}