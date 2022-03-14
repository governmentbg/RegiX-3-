namespace RegiX.Core.Metadata.Models
{
    public class ApiServiceAdapterOperations : BaseModel
    {
        public decimal Id { get; set; }
        public decimal AdapterOperationId { get; set; }
        public decimal ApiServiceOperationId { get; set; }

        public virtual AdapterOperations AdapterOperations { get; set; }
        public virtual ApiServiceOperations ApiServiceOperations { get; set; }
    }
}