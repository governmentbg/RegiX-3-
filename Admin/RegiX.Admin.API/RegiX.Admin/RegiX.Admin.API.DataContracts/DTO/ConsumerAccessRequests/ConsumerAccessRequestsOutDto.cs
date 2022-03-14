using TechnoLogica.API.DataContracts;

namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerAccessRequests
{
    public class ConsumerAccessRequestsOutDto
    {
        public decimal Id { get; set; }
        public int Status { get; set; }
        public string LawReason { get; set; }
        public string RelatedServices { get; set; }
        public string RelatedServicesCode { get; set; }
        public DisplayValue ConsumerSystemCertificate { get; set; }
        public DisplayValue ConsumerRequest { get; set; }
        public DisplayValueAdapterOperation AdapterOperation { get; set; }
    }


    public class DisplayValueAdapterOperation : DisplayValue
    {
        public decimal? RegisterObjectId { get; set; }
        public string Description { get; set; }
    }
}