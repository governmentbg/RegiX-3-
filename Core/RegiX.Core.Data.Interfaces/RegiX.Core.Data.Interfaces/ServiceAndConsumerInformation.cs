namespace TechnoLogica.RegiX.Core.Data.Interfaces
{
    public class ServiceAndConsumerInformation
    {
        public bool Enabled { get; set; }
        public decimal APIServiceOperationID { get; set; }
        public bool? HasAccess { get; set; }
        public string ConsumerName { get; set; }
        public string ConsumerOID { get; set; }
        public decimal? CertificateID { get; set; }
        public string CertificateThumbprint { get; set; }
        public bool? IsCertificateActive { get; set; }
        public decimal AdapterOperationID { get; set; }
        public string AdapterOperationName { get; set; }
        public string ProducerAdministration { get; set; }
        public string ConsumerAdmin { get; set; }
        public string Producer { get; set; }
    }
}
