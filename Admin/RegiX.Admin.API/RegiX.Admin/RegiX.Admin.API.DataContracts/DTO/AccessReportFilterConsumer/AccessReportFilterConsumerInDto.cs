namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.AccessReportFilterConsumer
{
    public class AccessReportFilterConsumerInDto
    {
        public string AdministrationName { get; set; }
        public string ConsumerName { get; set; }
        public string ConsumerCertificateName { get; set; }
        public decimal? AdministrationId { get; set; }
        public decimal? ConsumerId { get; set; }
        public decimal? ConsumerCertificateId { get; set; }
    }
}