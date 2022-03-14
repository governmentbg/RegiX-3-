using System.Collections.Generic;

namespace TechnoLogica.RegiX.Admin.Infrastructure.Models
{
    public partial class OperationParameters
    {
        public OperationParameters()
        {
            CustomParameters = new HashSet<CustomParameters>();
        }

        public decimal Id { get; set; }
        public string Name { get; set; }
        public decimal ParameterTypeId { get; set; }
        public decimal ServiceOperationId { get; set; }
        public string Label { get; set; }
        public bool? IsRequired { get; set; }
        public string RegexExpression { get; set; }
        public string Code { get; set; }
        public int? Order { get; set; }

        public virtual ParameterTypes ParameterType { get; set; }
        public virtual ApiServiceOperations ServiceOperation { get; set; }
        public virtual ICollection<CustomParameters> CustomParameters { get; set; }
    }
}