using System.Collections.Generic;

namespace TechnoLogica.RegiX.Client.Infrastructure.Models
{
    public partial class Parameters : BaseModel
    {
        public Parameters()
        {
            InverseParentParameter = new HashSet<Parameters>();
            ParametersToOperation = new HashSet<ParametersToOperation>();
        }

        public int Id { get; set; }
        public int ParameterTypeId { get; set; }
        public string ParameterName { get; set; }
        public bool IsXmlElement { get; set; }
        public string ParameterLabel { get; set; }
        public string RegexExpression { get; set; }
        public bool? IsRequired { get; set; }
        public int? ParentParameterId { get; set; }
        public int? OrderNumber { get; set; }
        public string Namespace { get; set; }
        public byte? IdentifierType { get; set; }

        public virtual ParameterTypes ParameterType { get; set; }
        public virtual Parameters ParentParameter { get; set; }
        public virtual ICollection<Parameters> InverseParentParameter { get; set; }
        public virtual ICollection<ParametersToOperation> ParametersToOperation { get; set; }
    }
}