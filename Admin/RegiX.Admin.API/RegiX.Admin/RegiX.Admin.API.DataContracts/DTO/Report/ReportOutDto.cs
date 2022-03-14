using TechnoLogica.API.DataContracts;

namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.Report
{
    public class ReportOutDto
    {
        public decimal Id { get; set; }

        public string Name { get; set; }
        public string LawReason { get; set; }
        public string Claim { get; set; }
        public string Xslt { get; set; }
        public int? OrderNumber { get; set; }
        public DisplayValue ApiServiceConsumer { get; set; }
        public DisplayValue ApiServiceOperation { get; set; }
    }
}