namespace TechnoLogica.RegiX.Admin.Infrastructure.Models.DatabaseOperationsModels
{
    public partial class AccessReportFilterView
    { 
        public string AdministrationName { get; set; }
        public string RegisterName { get; set; }
        public string AdapterName { get; set; }
        public string OperationName { get; set; }
        public decimal? AdministrationId { get; set; }
        public decimal? RegisterId { get; set; }
        public decimal? AdapterId { get; set; }
        public decimal? OperationId { get; set; }
    }
}
