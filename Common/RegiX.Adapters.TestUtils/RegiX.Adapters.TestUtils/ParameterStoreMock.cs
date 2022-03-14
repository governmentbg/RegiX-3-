using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.DataContracts;
using TechnoLogica.RegiX.Adapters.Common.Interfaces;
using TechnoLogica.RegiX.Common.DataContracts.Parameter;

namespace TechnoLogica.RegiX.Adapters.TestUtils
{
    [Export(typeof(IParameterStore))]
    public class ParameterStoreMock : IParameterStore
    {
        public Parameters GetParameters(BaseAdapterService adapterService)
        {
            throw new NotImplementedException();
        }

        public T GetParameterValue<T>(ParameterInfo<T> parameterInfo)
        {
            return parameterInfo.Defaultvalue;
        }

        public void SetParameter(BaseAdapterService adapterService, string key, string value)
        {
            throw new NotImplementedException();
        }

        public void SetParameters(List<ParameterInfo> parameters)
        {
            throw new NotImplementedException();
        }

        public void SetParameters(BaseAdapterService adapterService, List<ParameterInfo> parameters)
        {
            throw new NotImplementedException();
        }

        public void SetParameterValue<T>(ParameterInfo<T> parameterInfo, T value)
        {
            throw new NotImplementedException();
        }
    }
}
