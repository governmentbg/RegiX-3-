namespace TechnoLogica.RegiX.Admin.Infrastructure.Models
{
    public partial class CustomParameters
    {
        public int Id { get; set; }
        public decimal OperationParameterId { get; set; }
        public string Label { get; set; }
        public bool? IsRequired { get; set; }
        public string RegexExpression { get; set; }
        public string Code { get; set; }
        public int? Order { get; set; }
        public decimal ReportId { get; set; }

        public virtual OperationParameters OperationParameter { get; set; }
        public virtual Reports Report { get; set; }
    }
}