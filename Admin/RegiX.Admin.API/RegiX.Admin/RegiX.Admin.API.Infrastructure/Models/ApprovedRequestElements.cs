namespace TechnoLogica.RegiX.Admin.Infrastructure.Models
{
    public partial class ApprovedRequestElements
    {
        public decimal RegisterObjectElementId { get; set; }
        public decimal Id { get; set; }
        public decimal ConsumerAccessRequestId { get; set; }

        public virtual ConsumerAccessRequests ConsumerAccessRequest { get; set; }
        public virtual RegisterObjectElements RegisterObjectElement { get; set; }
    }
}
