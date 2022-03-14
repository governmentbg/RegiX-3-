using System;

namespace TechnoLogica.RegiX.Admin.Infrastructure.Models
{
    public partial class ParametersValuesLog
    {
        public decimal Id { get; set; }
        public string Key { get; set; }
        public decimal RegisterAdapterId { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public DateTime EditedTime { get; set; }
        public decimal UserId { get; set; }

        public virtual RegisterAdapters RegisterAdapter { get; set; }
        public virtual Users User { get; set; }
    }
}