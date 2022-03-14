using RegiX.Core.Metadata;
using RegiX.Core.Metadata.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.ReflectionModel;
using System.Linq;
using RegiX.Core.Metadata.Models;
using RegiX.Core.Metadata.Services;
using TechnoLogica.RegiX.Adapters.Common.Utils;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Core.Data.Interfaces;
using TechnoLogica.RegiX.Core.Data.Interfaces.Models;
using TechnoLogica.RegiX.Core;
using TechnoLogica.RegiX.Common.DataContracts.Parameter;
using TechnoLogica.RegiX.Common.DataContracts.Health;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace TechnoLogica.RegiX.CoreServices
{

    public class RegiXMetaDataService : IRegiXMetaDataService
    {
        public string GetAdapterMetadata()
        {
            try
            {
                var regixData = Composition.CompositionContainer.GetExportedValue<IRegiXData>();
                var bindingInfo = regixData.GetBindingInfo();

                var res = bindingInfo.GroupBy(x => x.ContractName).Where(g => g.Count() > 1).ToList();

                var adapters =
                    Composition
                        .CompositionContainer
                        .Catalog
                        .Parts
                        .Where(p => p.ExportDefinitions.Any(e => e.ContractName == typeof(IAdapterService).FullName))
                        .Select(ed => ReflectionModelServices.GetPartType(ed).Value)
                        .ToList();
                /*
                 * a.Assembly.GetName().Version
                 */
                var result = adapters
                    .Select(
                        a => {

                            string fullName = a.GetAdapterServiceInterface().FullName;
                            return
                            "{" +
                            $"\"{{#ADAPTER_NAME}}\":\"{a.Name}\"," +
                            $"\"{{#ADAPTER_CONTRACT}}\":\"{fullName}\"," +
                            $"\"{{#ADAPTER_URL}}\":\"{GetAdapterURL(fullName, bindingInfo)}\"" +
                            "}";
                        })
                    .ToList();
                var resultString =
                    "[" +
                    $"{String.Join(",", result)}" +
                    "]";
                return resultString;    
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private static string GetAdapterURL(string adapterServiceInterfaceName, IEnumerable<IRegisterBindingInfo> bindingInfo)
        {
            return bindingInfo.Where(bi => bi.ContractName == adapterServiceInterfaceName).Select(bi => bi.AdapterURL).SingleOrDefault();
        }

        public IEnumerable<AdapterInfo> GetAdaptersInfo()
        {
            try
            {
                var regixData = Composition.CompositionContainer.GetExportedValue<IMetadataService>();
                var result = regixData.GetAdaptersInfo();
                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Administration> GetAdministrations()
        {
            var regixData = Composition.CompositionContainer.GetExportedValue<IRegiXData>();
            var result = regixData.GetAdministrations();
            return result;
        }

        public IEnumerable<AdapterVersion> GetNotRegisteredAdapters()
        {
            var regixData = Composition.CompositionContainer.GetExportedValue<IMetadataService>();
            var result = regixData.GetNotRegisteredAdapters();
            return result;
        }

        public AdapterDataDto GetAllAdapterData(string adapterName)
        {
            var regixData = Composition.CompositionContainer.GetExportedValue<IMetadataService>();
            var result = regixData.GetAllAdapterData(adapterName);
            return result;
        }

        public void SetParameter(string adapterInterface, string key, string value)
        {
            IExecutionAdapterContext executionContext = CreateExecutionAdapterContext(adapterInterface);
            executionContext.SetParameter(key, value);
        }

        public void SetParameters(string adapterInterface, Parameters parameters)
        {
            IExecutionAdapterContext executionContext = CreateExecutionAdapterContext(adapterInterface);
            executionContext.SetParameters(parameters);
        }

        public static IExecutionAdapterContext CreateExecutionAdapterContext(string adapterInterface)
        {
            var adapterList =
                    Composition
                        .CompositionContainer
                        .Catalog
                        .Parts
                        .Where(p => p.ExportDefinitions.Any(e => e.ContractName == typeof(IAdapterService).FullName))
                        .Select(ed => ReflectionModelServices.GetPartType(ed).Value).ToList();

            var adapterType =
                adapterList.Single(t => t.GetInterfaces().Any(i => i.FullName == adapterInterface));

            var adapterInterfaceType = adapterType.GetAdapterServiceInterface();

            var executionAdapterContextType = typeof(ExecutionAdapterContext<>).MakeGenericType(adapterInterfaceType);

            var getExportedValueMethod =
                Composition
                    .CompositionContainer
                    .GetType()
                    .GetMethod(
                        nameof(Composition.CompositionContainer.GetExportedValue),
                        new Type[] { }
                    ).MakeGenericMethod(new Type[] { executionAdapterContextType });

            var executionContext =
                getExportedValueMethod.Invoke(Composition.CompositionContainer, new object[] { }) as IExecutionAdapterContext;
            return executionContext;
        }

        public Parameters GetParameters(string adapterInterface)
        {
            IExecutionAdapterContext executionContext = CreateExecutionAdapterContext(adapterInterface);

            return executionContext.GetParameters();
        }

        public string CheckHealthFunction(string adapterInterface, string key)
        {
            IExecutionAdapterContext executionContext = CreateExecutionAdapterContext(adapterInterface);
            return executionContext.CheckHealthFunction(key);
        }

        public string GetPublicKeyString(string adapterInterface)
        {
            IExecutionAdapterContext executionContext = CreateExecutionAdapterContext(adapterInterface);
            return executionContext.GetPublicKeyString();
        }

        public HealthCheckFunctions GetHealthCheckFunctions(string adapterInterface)
        {
            IExecutionAdapterContext executionContext = CreateExecutionAdapterContext(adapterInterface);
            return executionContext.GetHealthCheckFunctions();
        }

        public byte[] Ping(string adapterInterface, byte[] data)
        {
            IExecutionAdapterContext executionContext = CreateExecutionAdapterContext(adapterInterface);
            return executionContext.Ping(data);
        }

        public string GetAdapterVersion(string adapterInterface)
        {
            IExecutionAdapterContext executionContext = CreateExecutionAdapterContext(adapterInterface);
            return executionContext.GetAdapterVersion();
        }

        public uint GetAdapterUptime(string adapterInterface)
        {
            IExecutionAdapterContext executionContext = CreateExecutionAdapterContext(adapterInterface);
            return executionContext.GetAdapterUptime();
        }

        public uint GetSystemUptime(string adapterInterface)
        {
            IExecutionAdapterContext executionContext = CreateExecutionAdapterContext(adapterInterface);
            return executionContext.GetSystemUptime();
        }

        public string GetHostMachineInfo(string adapterInterface)
        {
            IExecutionAdapterContext executionContext = CreateExecutionAdapterContext(adapterInterface);
            return executionContext.GetHostMachineInfo();
        }

        public string CheckRegisterConnection(string adapterInterface)
        {
            IExecutionAdapterContext executionContext = CreateExecutionAdapterContext(adapterInterface);
            return executionContext.CheckRegisterConnection();
        }
    }
}
