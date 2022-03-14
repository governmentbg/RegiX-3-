using System;

namespace TechnoLogica.RegiX.Admin.Infrastructure.Models
{
    public partial class AdapterPingResults
    {
        public decimal AdapterPingResultId { get; set; }
        public DateTime ExecuteTime { get; set; }
        public decimal? ReplyTime { get; set; }
        public decimal Timeout { get; set; }
        public decimal RegisterAdapterId { get; set; }
        public string IpAddress { get; set; }
        public string AppName { get; set; }
        public string CreatedBy { get; set; }

        public virtual RegisterAdapters RegisterAdapter { get; set; }
    }
}