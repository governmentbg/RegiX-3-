namespace TechnoLogica.RegiX.Admin.Infrastructure.Models.DatabaseOperationsModels
{
    public partial class AccessReportFilterConsumerView
    {
        public string AdministrationName { get; set; }
        public string ConsumerName { get; set; }
        public string ConsumerCertificateName { get; set; }
        public decimal? AdministrationId { get; set; }
        public decimal? ConsumerId { get; set; }
        public decimal? ConsumerCertificateId { get; set; }
        
    }
}