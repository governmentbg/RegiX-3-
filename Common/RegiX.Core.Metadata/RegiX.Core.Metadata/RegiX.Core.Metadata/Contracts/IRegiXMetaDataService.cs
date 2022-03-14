using RegiX.Core.Metadata.Models;
using RegiX.Core.Metadata.Services;
using System.Collections.Generic;
using System.ServiceModel;
using TechnoLogica.RegiX.Common.DataContracts.Health;
using TechnoLogica.RegiX.Common.DataContracts.Parameter;
using TechnoLogica.RegiX.Core.Data.Interfaces.Models;

namespace RegiX.Core.Metadata.Contracts
{
    [ServiceContract]
    public interface IRegiXMetaDataService
    {
        [OperationContract]
        string GetAdapterMetadata();

        [OperationContract]
        IEnumerable<AdapterInfo> GetAdaptersInfo();

        [OperationContract]
        IEnumerable<Administration> GetAdministrations();

        [OperationContract]
        IEnumerable<AdapterVersion> GetNotRegisteredAdapters();

        [OperationContract]
        AdapterDataDto GetAllAdapterData(string adapterName);

        [OperationContract]
        void SetParameter(string adapterInterface, string key, string value);

        [OperationContract]
        void SetParameters(string adapterInterface, Parameters parameters);

        [OperationContract]
        Parameters GetParameters(string adapterInterface);

        [OperationContract]
        string CheckHealthFunction(string adapterInterface, string key);

        [OperationContract]
        string GetPublicKeyString(string adapterInterface);

        [OperationContract]
        HealthCheckFunctions GetHealthCheckFunctions(string adapterInterface);

        [OperationContract]
        byte[] Ping(string adapterInterface, byte[] data);

        [OperationContract]
        string GetAdapterVersion(string adapterInterface);

        [OperationContract]
        uint GetAdapterUptime(string adapterInterface);

        [OperationContract]
        uint GetSystemUptime(string adapterInterface);

        [OperationContract]
        string GetHostMachineInfo(string adapterInterface);

        [OperationContract]
        string CheckRegisterConnection(string adapterInterface);
    }
}
