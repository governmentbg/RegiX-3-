using System;

namespace TechnoLogica.RegiX.Admin.Infrastructure.Models
{
    public partial class AdapterHealthResults
    {
        public decimal AdapterHealthResultId { get; set; }
        public decimal RegisterAdapterId { get; set; }
        public decimal AdapterHealthFunctionId { get; set; }
        public DateTime ExecuteTime { get; set; }
        public string HealthResult { get; set; }
        public string HealthError { get; set; }
        public string IpAddress { get; set; }
        public string AppName { get; set; }
        public string CreatedBy { get; set; }

        public virtual AdapterHealthFunctions AdapterHealthFunction { get; set; }
        public virtual RegisterAdapters RegisterAdapter { get; set; }
    }
}