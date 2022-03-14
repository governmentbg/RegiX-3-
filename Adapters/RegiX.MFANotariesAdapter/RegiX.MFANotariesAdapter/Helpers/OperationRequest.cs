using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.MFANotariesAdapter.Helpers
{
    public class OperationRequest
    {
        public SendNotaryDocumentsRequest Request { get; set; }
        public AccessMatrix AccessMatrix { get; set; }
        public AdapterAdditionalParameters AdapterAdditionalParameters { get; set; }
    }
}
