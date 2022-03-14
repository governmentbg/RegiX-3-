using System.Collections.Generic;

namespace TechnoLogica.RegiX.Admin.Infrastructure.Models
{
    public partial class ParameterTypes
    {
        public ParameterTypes()
        {
            OperationParameters = new HashSet<OperationParameters>();
        }

        public decimal Id { get; set; }
        public string Name { get; set; }
        public bool IsEnum { get; set; }
        public string Code { get; set; }
        public string EnumValues { get; set; }

        public virtual ICollection<OperationParameters> OperationParameters { get; set; }
    }
}