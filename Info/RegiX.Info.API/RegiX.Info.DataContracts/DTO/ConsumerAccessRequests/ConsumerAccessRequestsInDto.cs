using TechnoLogica.API.DataContracts;

namespace RegiX.Info.DataContracts.DTO.ConsumerAccessRequests
{
    public class ConsumerAccessRequestsInDto
    {
        public string LawReason { get; set; }
        public string RelatedServices { get; set; }
        public string RelatedServicesCode { get; set; }
        public int[] ElementsIds { get; set; }
        public DisplayValue AdapterOperation { get; set; }//
        public DisplayValue ConsumerSystemCertificate { get; set; }
        public decimal ConsumerRequestId { get; set; }//
    }
}
