using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace TechnoLogica.RegiX.Client.API
{
    public class RegiXClientSettings
    {
        public string RegiXInfoURL { get; set; }
        public string RegiXCoreURL { get; set; }
        public string RegiXClientCallbackURL { get; set; }
        public PublicCallContext PublicCallContext { get; set; }
        public SystemCallContext SystemCallContext { get; set; }
        public CallBackService CallBackService { get; set; } = new CallBackService();
    }

    public class CallBackService
    {
        public long MaxReceivedMessageSize { get; set; } = 26214400;
        public int MaxBufferSize { get; set; } = 26214400;
        public int MaxDepth { get; set; } = 256;
        public int MaxStringContentLength { get; set; } = 2147483647;
        public int MaxArrayLength { get; set; } = 2147483647;
        public int MaxBytesPerRead { get; set; } = 2147483647;
        public int MaxNameTableCharCount { get; set; } = 2147483647;
    }

    public class BaseCallContext
    {
        public string ServiceURI { get; set; }
        public string ServiceType { get; set; }
        public string EmployeeIdentifier { get; set; }
        public string EmployeeNames { get; set; }
        public string EmployeeAditionalIdentifier { get; set; }
        public string EmployeePosition { get; set; }
        public string AdministrationOId { get; set; }
        public string AdministrationName { get; set; }
        public string ResponsiblePersonIdentifier { get; set; }
        public string LawReason { get; set; }
        public string Remark { get; set; }
    }


    public class PublicCallContext : BaseCallContext
    {
    }

    public class SystemCallContext : BaseCallContext
    {
        public string CertificateThumbprint { get; set; }
        public bool ReturnAccessMatrix { get; set; }
        public bool SignResult { get; set; }
    }
}
