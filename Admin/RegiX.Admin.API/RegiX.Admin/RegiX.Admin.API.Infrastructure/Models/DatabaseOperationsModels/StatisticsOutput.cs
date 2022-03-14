namespace TechnoLogica.RegiX.Admin.Infrastructure.Models.DatabaseOperationService
{
    public partial class StatisticsOutput
    {
        public string ConsumerAdministration { get; set; }
        public string ConsumerName { get; set; }
        public string ConsumerDescription { get; set; }
        public string RegisterAdministration { get; set; }
        public string RegisterName { get; set; }
        public string OperationName { get; set; }
        public decimal RecordsCount { get; set; }
        public decimal ApiServiceId { get; set; }
        public decimal ConsumerId { get; set; }
        public decimal ApiServiceOperationId { get; set; }
        public decimal AdministrationId { get; set; }
        public decimal ConsumerAdministrationId { get; set; }
        public decimal RegisterId { get; set; }
        public decimal AdapterId { get; set; }
        public decimal AdapterOperationId { get; set; }
    }
}