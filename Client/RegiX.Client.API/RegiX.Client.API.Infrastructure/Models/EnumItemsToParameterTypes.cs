namespace TechnoLogica.RegiX.Client.Infrastructure.Models
{
    public partial class EnumItemsToParameterTypes
    {
        public int EnumId { get; set; }
        public int ParameterTypeId { get; set; }

        public virtual EnumItems Enum { get; set; }
        public virtual ParameterTypes ParameterType { get; set; }
    }
}