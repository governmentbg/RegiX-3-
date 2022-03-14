using System;
using System.Collections.Generic;
using System.Xml;
using TechnoLogica.RegiX.Core.Data.Interfaces.Models;

namespace TechnoLogica.RegiX.Core.Data.Interfaces
{
    public interface IRegiXData
    {
        string GetAPIServiceContract(decimal? serviceCallID);
        ICertificateInfo GetAdministrationCertificate(string certificateThumbprint);

        Dictionary<string, bool> GetPropertyAccess(string operationName, decimal registerAdapterID,
            decimal certificateID);

        void UpdateAPIServiceCall(decimal apiServiceCallId, bool? resultReady = null, bool? resultReturned = null,
            bool? hasError = null, string errorContent = null);

        decimal AddAPIServiceCall(
            decimal certificateID,
            decimal operationID,
            Guid instanceID,
            string EIDToken,
            string remark,
            string clientIPAddress,
            XmlElement request,
            string operationFullName,
            string serviceURI = null,
            string serviceType = null,
            string employeeIdentifier = null,
            string employeeNames = null,
            string employeeAditionalIdentifier = null,
            string employeePosition = null,
            string administrationOId = null,
            string administrationName = null,
            string responsiblePersonIdentifier = null,
            string lawReason = null,
            string OIDToken = null,
            string consumerName = null,
            string adapterOperationName = null,
            string producerAdministration = null,
            string consumerAdmin = null,
            string producer = null,
            string consumerOID = null
        );

        IRegisterBindingInfo GetBindingInfo(string adapterContractName);
        IEnumerable<IRegisterBindingInfo> GetBindingInfo();
        IAdapterInfo GetAdapterInfo(decimal serviceCallID);
        string GetAdapterContractName(string contract, string operationName);

        void AddAdapterOperationErrorLog(decimal apiServiceOperationID, decimal adapterOperationID,
            decimal? apiServiceCallId, DateTime logTime, string message, string errorContent);

        void AddAdapterOperationLog(decimal apiServiceCallId, decimal adapterOperationID, DateTime startTime,
            DateTime endTime);

        ServiceAndConsumerInformation GetServiceAndConsumerInformation(string thumbprint, string contractName,
            string operationName, string oid);

        decimal GetRegisterAdapterID(string adapterContractName);

        IEnumerable<IAdapterVersion> GetAllAdapters();

        IEnumerable<Administration> GetAdministrations();
    }
}