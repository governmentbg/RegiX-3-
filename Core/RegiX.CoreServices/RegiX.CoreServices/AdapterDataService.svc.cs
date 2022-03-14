using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using TechnoLogica.RegiX.Common.DataContracts.Health;
using TechnoLogica.RegiX.Common.DataContracts.Parameter;
using TechnoLogica.RegiX.Core;

namespace TechnoLogica.RegiX.CoreServices
{
    [ServiceContract]
    public interface IRegiXMetaDataService2
    {
        [OperationContract]
        [WebInvoke(Method = "POST",
            UriTemplate = "/CheckHealthFunction/{adapterInterface}",
            BodyStyle = WebMessageBodyStyle.Bare,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        string CheckHealthFunction(string adapterInterface, string key);

        [OperationContract]
        [WebInvoke(Method = "POST",
            UriTemplate = "/GetPublicKeyString",
            BodyStyle = WebMessageBodyStyle.Bare,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        string GetPublicKeyString(string adapterInterface);

        [OperationContract]
        [WebInvoke(Method = "POST", 
            UriTemplate = "/GetHealthCheckFunctions", 
            BodyStyle = WebMessageBodyStyle.Bare, 
            RequestFormat = WebMessageFormat.Json, 
            ResponseFormat = WebMessageFormat.Json)]
        HealthCheckFunctions GetHealthCheckFunctions(string adapterInterface);

        [OperationContract]
        [WebInvoke(Method = "POST",
            UriTemplate = "/Ping",
            BodyStyle = WebMessageBodyStyle.Bare,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        uint Ping(string adapterInterface);

        [OperationContract]
        [WebInvoke(Method = "POST",
            UriTemplate = "/GetAdapterVersion",
            BodyStyle = WebMessageBodyStyle.Bare,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        string GetAdapterVersion(string adapterInterface);

        [OperationContract]
        [WebInvoke(Method = "POST",
            UriTemplate = "/GetAdapterUptime",
            BodyStyle = WebMessageBodyStyle.Bare,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        uint GetAdapterUptime(string adapterInterface);

        [OperationContract]
        [WebInvoke(Method = "POST",
            UriTemplate = "/GetSystemUptime",
            BodyStyle = WebMessageBodyStyle.Bare,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        uint GetSystemUptime(string adapterInterface);

        [OperationContract]
        [WebInvoke(Method = "POST",
            UriTemplate = "/GetHostMachineInfo",
            BodyStyle = WebMessageBodyStyle.Bare,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        string GetHostMachineInfo(string adapterInterface);

        [OperationContract]
        [WebInvoke(Method = "POST",
            UriTemplate = "/CheckRegisterConnection",
            BodyStyle = WebMessageBodyStyle.Bare,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        string CheckRegisterConnection(string adapterInterface);
    }

    public class AdapterDataService : IRegiXMetaDataService2
    {

        public string CheckHealthFunction(string adapterInterface, string key)
        {
            IExecutionAdapterContext executionContext = RegiXMetaDataService.CreateExecutionAdapterContext(adapterInterface);
            return executionContext.CheckHealthFunction(key);
        }

        public string GetPublicKeyString(string adapterInterface)
        {
            IExecutionAdapterContext executionContext = RegiXMetaDataService.CreateExecutionAdapterContext(adapterInterface);
            return executionContext.GetPublicKeyString();
        }

        public HealthCheckFunctions GetHealthCheckFunctions(string adapterInterface)
        {
            IExecutionAdapterContext executionContext = RegiXMetaDataService.CreateExecutionAdapterContext(adapterInterface);
            return executionContext.GetHealthCheckFunctions();
        }

        public uint Ping(string adapterInterface)
        {
            IExecutionAdapterContext executionContext = RegiXMetaDataService.CreateExecutionAdapterContext(adapterInterface);
            byte[] result =  executionContext.Ping(new byte[] { 1, 2, 3});
            return 1;
        }

        public string GetAdapterVersion(string adapterInterface)
        {
            IExecutionAdapterContext executionContext = RegiXMetaDataService.CreateExecutionAdapterContext(adapterInterface);
            return executionContext.GetAdapterVersion();
        }

        public uint GetAdapterUptime(string adapterInterface)
        {
            IExecutionAdapterContext executionContext = RegiXMetaDataService.CreateExecutionAdapterContext(adapterInterface);
            return executionContext.GetAdapterUptime();
        }

        public uint GetSystemUptime(string adapterInterface)
        {
            IExecutionAdapterContext executionContext = RegiXMetaDataService.CreateExecutionAdapterContext(adapterInterface);
            return executionContext.GetSystemUptime();
        }

        public string GetHostMachineInfo(string adapterInterface)
        {
            IExecutionAdapterContext executionContext = RegiXMetaDataService.CreateExecutionAdapterContext(adapterInterface);
            return executionContext.GetHostMachineInfo();
        }

        public string CheckRegisterConnection(string adapterInterface)
        {
            IExecutionAdapterContext executionContext = RegiXMetaDataService.CreateExecutionAdapterContext(adapterInterface);
            return executionContext.CheckRegisterConnection();
        }
    }
}
