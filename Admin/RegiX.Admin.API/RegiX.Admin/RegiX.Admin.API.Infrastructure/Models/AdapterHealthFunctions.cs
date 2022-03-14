using System.Collections.Generic;

namespace TechnoLogica.RegiX.Admin.Infrastructure.Models
{
    public partial class AdapterHealthFunctions
    {
        public AdapterHealthFunctions()
        {
            AdapterHealthResults = new HashSet<AdapterHealthResults>();
        }

        public decimal AdapterHealthFunctionId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal RegisterAdapterId { get; set; }

        public virtual RegisterAdapters RegisterAdapter { get; set; }
        public virtual ICollection<AdapterHealthResults> AdapterHealthResults { get; set; }
    }
}