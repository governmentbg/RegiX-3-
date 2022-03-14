using System.Collections.Generic;

namespace TechnoLogica.RegiX.Client.Infrastructure.Models
{
    public partial class EnumItems : BaseModel
    {
        public EnumItems()
        {
            EnumItemsToParameterTypes = new HashSet<EnumItemsToParameterTypes>();
        }

        public int Id { get; set; }
        public string EnumValue { get; set; }
        public string EnumDisplayText { get; set; }
        public byte? IdentifierType { get; set; }

        public virtual ICollection<EnumItemsToParameterTypes> EnumItemsToParameterTypes { get; set; }
    }
}