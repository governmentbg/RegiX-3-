using System.Collections.Generic;

namespace TechnoLogica.RegiX.Client.Infrastructure.Models
{
    public partial class ParameterTypes : BaseModel
    {
        public ParameterTypes()
        {
            EnumItemsToParameterTypes = new HashSet<EnumItemsToParameterTypes>();
            Parameters = new HashSet<Parameters>();
        }

        public int Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<EnumItemsToParameterTypes> EnumItemsToParameterTypes { get; set; }
        public virtual ICollection<Parameters> Parameters { get; set; }
    }
}