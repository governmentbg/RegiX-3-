using TechnoLogica.RegiX.DataAccess.Utils;
using System.Linq;
using System.ComponentModel.Composition;
using System;
using System.Collections.Generic;
using TechnoLogica.RegiX.Core.Data.Interfaces;
using System.Xml;
using TechnoLogica.RegiX.Core.Data.Interfaces.Models;

namespace TechnoLogica.RegiX.DataAccess.DataClasses
{
    [Export(typeof(IRegiXData))]
    public class RegiXData : IRegiXData
    {
        [Import(AllowDefault = true)]
        public ILogRecord LogRecord
        {
            get;
            set;
        }

        class CertificateInfo : ICertificateInfo
        {
            public DateTime? ValidFrom { get; set; }
            public DateTime? ValidTo { get; set; }
            public bool Active { get; set; }
        }

        class AdapterInfo : IAdapterInfo
        {
            public string AdapterServiceContract { get; set; }
            public string APIServiceContract { get; set; }
            public string APIServiceOperation { get; set; }
        }

        class AdapterVersion : IAdapterVersion
        {
            public string AdapterName { get; set; }
            public string AdapterContract { get; set; }
            public string AdapterAssembly { get; set; }
            public string VersionOfAdapter { get; set; }
        }

        public class RegisterBindingInfo : IRegisterBindingInfo
        {
            public string BindingType { get; set; }
            public string BindingConfigName { get; set; }
            public string Behavior { get; set; }
            public string AdapterURL { get; set; }
            public string ContractName { get; set; }
        }

        public ICertificateInfo GetAdministrationCertificate(string thumbprint)
        {
            using (var context = DbContextUtils.GetDbContext())
            {
                var result = 
                   (from ad in context.API_SERVICE_CONSUMERS
                    join cert in context.CONSUMER_CERTIFICATES on ad.API_SERVICE_CONSUMER_ID equals cert.API_SERVICE_CONSUMER_ID
                   where cert.THUMBPRINT.ToLower() == thumbprint.ToLower()
                  select new CertificateInfo
                         {
                            ValidFrom = cert.VALID_FROM,
                            ValidTo = cert.VALID_TO,
                            Active = cert.ACTIVE
                         }
                ).FirstOrDefault();
                return result;
            }
        }

        public string GetAPIServiceContract(decimal? serviceCallID)
        {
            if (serviceCallID.HasValue)
            {
                using (var context = DbContextUtils.GetDbContext())
                {
                    var res = from sc in context.API_SERVICE_CALLS
                              join so in context.API_SERVICE_OPERATIONS on sc.API_SERVICE_OPERATION_ID equals so.API_SERVICE_OPERATION_ID
                              join a in context.API_SERVICES on so.API_SERVICE_ID equals a.API_SERVICE_ID
                              where sc.API_SERVICE_CALL_ID == serviceCallID.Value
                              select a.CONTRACT;
                    var contract = res.FirstOrDefault();
                    return contract;
                }
            }
            else
            {
                return null;
            }
        }

        public Dictionary<string, bool> GetPropertyAccess(string operationName, decimal registerAdapterID, decimal certificateID)
        {
            return RegisterAdaptersData.GetPropertyAccess(DbContextUtils.GetDbContext(),certificateID, registerAdapterID, operationName);
        }

        public void UpdateAPIServiceCall(decimal apiServiceCallId, bool? resultReady = null, bool? resultReturned = null, bool? hasError = null, string errorContent = null)
        {
            APIServiceCallsData.UpdateAPIServiceCall(DbContextUtils.GetDbContext(), apiServiceCallId, LogRecord, resultReady, resultReturned, hasError, null, errorContent);
        }

        public decimal AddAPIServiceCall(
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
            string consumerOID = null)
        {
            return APIServiceCallsData.AddAPIServiceCall(
                certificateID, 
                operationID, 
                instanceID, 
                EIDToken, 
                remark,
                clientIPAddress,
                request,
                operationFullName,
                LogRecord,
                serviceURI, 
                serviceType, 
                employeeIdentifier, 
                employeeNames, 
                employeeAditionalIdentifier, 
                employeePosition, 
                administrationOId, 
                administrationName, 
                responsiblePersonIdentifier, 
                lawReason,
                OIDToken,
                consumerName,
                adapterOperationName,
                producerAdministration,
                consumerAdmin,
                producer,
                consumerOID);
        }

        public IAdapterInfo GetAdapterInfo(decimal apiServiceCall)
        {
            using (var context = DbContextUtils.GetDbContext())
            {
                var res = (from sc in context.API_SERVICE_CALLS
                           join so in context.API_SERVICE_OPERATIONS on sc.API_SERVICE_OPERATION_ID equals so.API_SERVICE_OPERATION_ID
                           join s in context.API_SERVICES on so.API_SERVICE_ID equals s.API_SERVICE_ID
                           join sao in context.API_SERVICE_ADAPTER_OPERATIONS on so.API_SERVICE_OPERATION_ID equals sao.API_SERVICE_OPERATION_ID
                           join ao in context.ADAPTER_OPERATIONS on sao.ADAPTER_OPERATION_ID equals ao.ADAPTER_OPERATION_ID
                           join ra in context.REGISTER_ADAPTERS on ao.REGISTER_ADAPTER_ID equals ra.REGISTER_ADAPTER_ID
                           where sc.API_SERVICE_CALL_ID == apiServiceCall
                           select new AdapterInfo { AdapterServiceContract = ra.CONTRACT, APIServiceContract = s.CONTRACT, APIServiceOperation = so.NAME }
                          ).FirstOrDefault();
                return res;
            }
        }

        public string GetAdapterContractName(string contract, string operationName)
        {
            using (var context = DbContextUtils.GetDbContext())
            {
                var res = from sao in context.API_SERVICE_ADAPTER_OPERATIONS
                          join so in context.API_SERVICE_OPERATIONS on sao.API_SERVICE_OPERATION_ID equals so.API_SERVICE_OPERATION_ID
                          join s in context.API_SERVICES on so.API_SERVICE_ID equals s.API_SERVICE_ID
                          join ao in context.ADAPTER_OPERATIONS on sao.ADAPTER_OPERATION_ID equals ao.ADAPTER_OPERATION_ID
                          join ra in context.REGISTER_ADAPTERS on ao.REGISTER_ADAPTER_ID equals ra.REGISTER_ADAPTER_ID
                          where s.CONTRACT == contract && so.NAME == operationName
                          select ra.CONTRACT;
                return res.FirstOrDefault();
            }
        }

        public void AddAdapterOperationErrorLog(decimal apiServiceOperationID, decimal adapterOperationID, decimal? apiServiceCallId, DateTime logTime, string message, string errorContent)
        {
            using (var context = DbContextUtils.GetDbContext())
            {
                var errorLog = context.OPERATIONS_ERROR_LOG.Create();
                errorLog.LOG_TIME = logTime;
                errorLog.ERROR_MESSAGE = message;
                errorLog.ERROR_CONTENT = errorContent;
                errorLog.ADAPTER_OPERATION_ID = adapterOperationID;
                errorLog.API_SERVICE_OPERATION_ID = apiServiceOperationID;
                errorLog.API_SERVICE_CALL_ID = apiServiceCallId;
                context.OPERATIONS_ERROR_LOG.Add(errorLog);
                context.SaveChanges();
            }
        }

        public void AddAdapterOperationLog(decimal apiServiceCallId, decimal adapterOperationID, DateTime startTime, DateTime endTime)
        {
            using (var context = DbContextUtils.GetDbContext())
            {
                var adapterOperationLog = context.ADAPTER_OPERATION_LOG.Create();
                adapterOperationLog.API_SERVICE_CALL_ID = apiServiceCallId;
                adapterOperationLog.ADAPTER_OPERATION_ID = adapterOperationID;
                adapterOperationLog.START_TIME = startTime;
                adapterOperationLog.END_TIME = endTime;
                context.ADAPTER_OPERATION_LOG.Add(adapterOperationLog);
                context.SaveChanges();
            }
        }

        public ServiceAndConsumerInformation GetServiceAndConsumerInformation(string thumbprint, string contractName, string operationName, string oid)
        {
            return APIServiceCallsData.GetServiceAndConsumerInformation(DbContextUtils.GetDbContext(), thumbprint, contractName, operationName, oid);
        }

        public decimal GetRegisterAdapterID(string adapterContractName)
        {
            using (var context = DbContextUtils.GetDbContext())
            {
                return context.REGISTER_ADAPTERS.Where(ra => ra.CONTRACT == adapterContractName).Select(ra => ra.REGISTER_ADAPTER_ID).Single();
            }
        }

        public IRegisterBindingInfo GetBindingInfo(string adapterContractName)
        {
            using (var context = DbContextUtils.GetDbContext())
            {
                return 
                    context.
                    REGISTER_ADAPTERS.
                    Where(ra => ra.CONTRACT == adapterContractName).
                    Select(
                        ra => 
                            new RegisterBindingInfo()
                            {
                                BindingType = ra.BINDING_TYPE,
                                AdapterURL = ra.ADAPTER_URL,
                                Behavior = ra.BEHAVIOUR,
                                BindingConfigName = ra.BINDING_CONFIG_NAME,
                                ContractName = ra.CONTRACT
                            }).
                    Single();
            }
        }

        public IEnumerable<IRegisterBindingInfo> GetBindingInfo()
        {
            using (var context = DbContextUtils.GetDbContext())
            {
                return
                    context.
                    REGISTER_ADAPTERS.
                    Select(
                        ra =>
                            new RegisterBindingInfo()
                            {
                                BindingType = ra.BINDING_TYPE,
                                AdapterURL = ra.ADAPTER_URL,
                                Behavior = ra.BEHAVIOUR,
                                BindingConfigName = ra.BINDING_CONFIG_NAME,
                                ContractName = ra.CONTRACT
                            }).
                    ToList();
            }
        }

        public IEnumerable<IAdapterVersion> GetAllAdapters()
        {
            using (var context = DbContextUtils.GetDbContext())
            {
                return context
                    .REGISTER_ADAPTERS
                    .Select(a => new AdapterVersion
                    {
                        AdapterContract = a.CONTRACT,
                        AdapterName = a.NAME,
                        AdapterAssembly = a.ASSEMBLY,
                        VersionOfAdapter = a.VERSION
                       
                    })
                    .ToList();
            }
        }

        public IEnumerable<Administration> GetAdministrations()
        {
            using (var context = DbContextUtils.GetDbContext())
            {
                return context.ADMINISTRATIONS
                    .Select(a => new Administration
                    {
                        Name = a.NAME,
                        Acronym = a.ACRONYM,
                        Code = a.CODE,
                        OID = a.OID,
                        Registers = a.REGISTERS.Select(r => new Register
                        {
                            Name = r.NAME,
                            Description = r.DESCRIPTION,
                            Code = r.CODE,
                            Adapters = r.REGISTER_ADAPTERS.Select(adp => new Core.Data.Interfaces.Models.AdapterInfo
                            {
                                Name = adp.NAME,
                                Version = adp.VERSION,
                                Description = adp.DESCRIPTION,
                            }),
                        })
                    }).ToList();
            }
        }
    }
}
