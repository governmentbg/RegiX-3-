namespace TechnoLogica.RegiX.Admin.Infrastructure.Models
{
    public partial class ApiServiceAdapterOperations : BaseModel
    {
        public decimal Id { get; set; }
        public decimal AdapterOperationId { get; set; }
        public decimal ApiServiceOperationId { get; set; }

        public virtual AdapterOperations AdapterOperation { get; set; }
        public virtual ApiServiceOperations ApiServiceOperation { get; set; }
    }
}