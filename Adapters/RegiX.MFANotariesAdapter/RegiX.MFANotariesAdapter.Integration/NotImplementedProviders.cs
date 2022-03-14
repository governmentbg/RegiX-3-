using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.DataContracts;
using TechnoLogica.RegiX.Adapters.Common.Interfaces;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts.Parameter;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.MFANotariesAdapter.AdapterService;

namespace TechnoLogica.RegiX.MFANotariesAdapter.Integration
{
    [Export(typeof(IParameterStore))]
    public class NotImplementedParameterStore : IParameterStore
    {
        public Parameters GetParameters(BaseAdapterService adapterService)
        {
            return new Parameters();
        }

        public T GetParameterValue<T>(ParameterInfo<T> parameterInfo)
        {
            string value;
            if (parameterInfo.Key == Constants.ConnectionStringParameterKeyName)
            {
                value = "Host=172.31.12.64;Database=aises;Username=aises;Password=ais3s;Timeout=1024";
            }
            else if (parameterInfo.Key == "RegiXCallbackService")
            {
                value = "http://localhost/RegiX.Workflows/RegiXReceiveResult.svc";
            }
            else
            {
                value = "";
            }
            
            return (T)(value as object);
        }

        public void SetParameter(BaseAdapterService adapterService, string key, string value)
        {
        }

        public void SetParameters(BaseAdapterService adapterService, List<ParameterInfo> parameters)
        {
        }

        public void SetParameterValue<T>(ParameterInfo<T> parameterInfo, T value)
        {
        }
    }

    [Export(typeof(IPersistanceProvider))]
    public class NotImplementedPersistanceProvider : IPersistanceProvider
    {
        public void PersistProcessing(decimal persistanceID, string verificationCode)
        {
        }

        public void PersistResult(decimal persistanceID, ServiceResultData result)
        {
        }

        public void Remove(decimal persistanceID, string verificationCode)
        {
        }

        public ServiceResultData RetrieveResult(decimal persistanceID, string verificationCode)
        {
            return null;
        }
    }
}
