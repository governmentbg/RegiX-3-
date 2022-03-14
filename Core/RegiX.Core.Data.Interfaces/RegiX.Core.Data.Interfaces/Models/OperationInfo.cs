namespace TechnoLogica.RegiX.Core.Data.Interfaces.Models
{
    public class OperationInfo
    {
        public string FullName { get; set; }
        public string Description { get; set; }
        public Parameter Request { get; set; }
        public Parameter Response { get; set; }
        public string RequestXSD { get; set; }
        public string ResponseXSD { get; set; }
        public string RequestXslt { get; set; }
        public string ResponseXslt { get; set; }
        public string SampleRequestXML { get; set; }
        public string SampleResponseXML { get; set; }
        public string MetaDataXML { get; set; }
        public string[] CommonXSD { get; set; }
        public string[] CommonXSDNames { get; set; }
    }
}