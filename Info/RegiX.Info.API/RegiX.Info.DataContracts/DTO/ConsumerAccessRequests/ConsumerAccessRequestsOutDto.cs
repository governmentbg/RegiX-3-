using TechnoLogica.API.DataContracts;

namespace RegiX.Info.DataContracts.DTO.ConsumerAccessRequests
{
    public class ConsumerAccessRequestsOutDto
    {
        public decimal Id { get; set; }
        public string LawReason { get; set; }
        public string RelatedServices { get; set; }
        public string RelatedServicesCode { get; set; }
        public int Status { get; set; }
        public DisplayValueAdapterOperation AdapterOperation { get; set; }
        public DisplayValue ConsumerSystemCertificate { get; set; }
        public DisplayValueConsumerRequest ConsumerRequest { get; set; }
    }

    public class DisplayValueAdapterOperation : DisplayValue
    {
        public decimal RegisterObjectId { get; set; }
    }

    public class DisplayValueConsumerRequest : DisplayValue
    {
        public int Status { get; set; }
    }
}
