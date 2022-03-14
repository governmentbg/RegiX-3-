using System;

namespace RegiX.Info.Infrastructure.Models
{
    public class Statistics
    {
        public string Code { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Records { get; set; }
    }
}