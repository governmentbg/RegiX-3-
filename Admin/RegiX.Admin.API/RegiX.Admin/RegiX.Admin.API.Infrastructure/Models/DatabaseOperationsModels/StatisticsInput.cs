using System;

namespace TechnoLogica.RegiX.Admin.Infrastructure.Models
{
    public partial class StatisticsInput
    {
        public DateTime fromDate { get; set; }
        public DateTime toDate { get; set; }
        public string consumerDescription { get; set; }
        public decimal? consumerAdministrationId { get; set; }
        public decimal? consumerId { get; set; }
        public decimal? registerAdministrationId { get; set; }
        public decimal? registerId { get; set; }
        public decimal? adapterId { get; set; }
        public decimal? adapterOperationId { get; set; }
    }
}