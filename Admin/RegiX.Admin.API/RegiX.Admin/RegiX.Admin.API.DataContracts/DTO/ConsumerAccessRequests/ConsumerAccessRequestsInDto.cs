using TechnoLogica.API.DataContracts;

namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerAccessRequests
{
    public class ConsumerAccessRequestsInDto
    {
        public decimal Id { get; set; }
        public int Status { get; set; }
        public string LawReason { get; set; }
        public string RelatedServices { get; set; }
        public string RelatedServicesCode { get; set; }

        public string Comment { get; set; }
        public decimal[] ApprovedRequestElementIds { get; set; }

        public DisplayValue ConsumerSystemCertificate { get; set; }
        public DisplayValue ConsumerRequest { get; set; }
        public DisplayValueAdapterOperation AdapterOperation { get; set; }
    }
}