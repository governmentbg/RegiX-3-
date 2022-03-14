using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Web;
using TechnoLogica.RegiX.Adapters.Common.Interfaces;
using TechnoLogica.RegiX.Adapters.Common.Utils;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Common.Utils;

namespace TechnoLogica.RegiX.Adapters.WCFAdapterHost.MessageInspector
{
    public class Inspector : IParameterInspector, IErrorHandler
    {
        protected string AdapterContract { get; set; }
        protected IAdapterLogger LogstashLogger { get; set; }

        public Inspector(string adapterContracct)
        {
            AdapterContract = adapterContracct;
            LogstashLogger = Composition.CompositionContainer.GetExportedValueOrDefault<IAdapterLogger>();
        }

        public void AfterCall(string operationName, object[] outputs, object returnValue, object correlationState)
        {
            try
            {
                decimal serviceCallId = 0;
                if (WcfOperationContext.Current.Items.ContainsKey("ApiServiceCallId"))
                {
                    serviceCallId = Convert.ToDecimal(WcfOperationContext.Current.Items["ApiServiceCallId"]);
                }
                var operationFullName = WcfOperationContext.Current.Items["OperationFullName"].ToString();

                LogstashLogger.LogRecord(
                    operationFullName,
                    new Common.DataContracts.AdapterLogRecordType()
                    {
                        ApiServiceCallId = serviceCallId,
                        ApiServiceCallIdSpecified = (serviceCallId != 0),
                        Response = (returnValue != null) ? returnValue.XmlSerialize().ToXmlElement() : null
                    }
                );
            }
            catch(Exception ex)
            {
                // Add Logging
            }
        }

        public object BeforeCall(string operationName, object[] inputs)
        {
            try
            {
                var argument = inputs[0];
                if (operationName == nameof(IAdapterService.Execute))
                {
                    argument = (argument as ServiceRequestData)?.Argument;
                }
                var accessMatrix = inputs[1] as AccessMatrix;
                var adapterAdditionalParameters = inputs[2] as AdapterAdditionalParameters;
                var current = OperationContext.Current;
                string operationFullName =
                    $"{OperationContext.Current.Host.Description.ServiceType.GetAdapterServiceInterface().FullName}.{operationName}";
                WcfOperationContext.Current.Items["OperationFullName"] = operationFullName;
                if (adapterAdditionalParameters != null &&
                    adapterAdditionalParameters.ApiServiceCallId != 0)
                {
                    WcfOperationContext.Current.Items["ApiServiceCallId"] = adapterAdditionalParameters.ApiServiceCallId;
                }

                LogstashLogger.LogRecord(
                    operationFullName,
                    new Common.DataContracts.AdapterLogRecordType()
                    {
                        AccessMatrix = accessMatrix,
                        AdditionalParameters = adapterAdditionalParameters,
                        ApiServiceCallId = (adapterAdditionalParameters != null) ? adapterAdditionalParameters.ApiServiceCallId : 0,
                        ApiServiceCallIdSpecified = (adapterAdditionalParameters != null),
                        Argument = (argument != null) ? argument.XmlSerialize().ToXmlElement() : null
                    }
                );
            }
            catch(Exception ex)
            {
                // Add Logging
            }
            return null;
        }

        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            try
            {
                decimal serviceCallId = 0;
                if (WcfOperationContext.Current.Items.ContainsKey("ApiServiceCallId"))
                {
                    serviceCallId = Convert.ToDecimal(WcfOperationContext.Current.Items["ApiServiceCallId"]);
                }
                string operationFullName = "";
                if (WcfOperationContext.Current.Items.ContainsKey("OperationFullName")) 
                {
                    operationFullName = WcfOperationContext.Current.Items["OperationFullName"].ToString();
                }

                LogstashLogger.LogRecord(
                    operationFullName,
                    new Common.DataContracts.AdapterLogRecordType()
                    {
                        ApiServiceCallId = serviceCallId,
                        ApiServiceCallIdSpecified  = (serviceCallId != 0),
                        ErrorMessage = error.Message
                    }
                );
            }
            catch (Exception ex)
            {
                // Add Logging
            }
        }

        public bool HandleError(Exception error)
        {
            return false;
        }
    }
}