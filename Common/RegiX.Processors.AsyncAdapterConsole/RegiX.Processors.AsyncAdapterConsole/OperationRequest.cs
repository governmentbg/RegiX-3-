using System;
using System.Collections.Generic;
using System.Text;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.Processors.AsyncAdapterConsole
{
    public class OperationRequest<Req, Resp>
    {
        public Req Request { get; set; }
        public AccessMatrix AccessMatrix { get; set; }
        public AdapterAdditionalParameters AdapterAdditionalParameters { get; set; }
        public Resp Response { get; set; }
    }
}
