namespace TechnoLogica.RegiX.Client.Infrastructure.Models
{
    public partial class ParametersToOperation
    {
        public int AdapterOperationId { get; set; }
        public int ParameterId { get; set; }

        public virtual AdapterOperations AdapterOperation { get; set; }
        public virtual Parameters Parameter { get; set; }
    }
}