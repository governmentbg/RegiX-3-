using System;
using System.Xml;
using System.Xml.Serialization;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.Utils;
using TechnoLogica.RegiX.Core;

namespace TechnoLogica.RegiX.LegacyCore.TransportObject
{
    [Serializable]
    [XmlType(Namespace="http://egov.bg/RegiX")]
    public class ServiceResultData<T> : IErrorInfo
        where T : class
    {
        private string _error;

        [XmlElement]
        public bool IsReady { get; set; }

        [XmlElement]
        public T Result { get; set; }

        [XmlElement]
        public bool HasError { get; set; }

        [XmlElement]
        public string Error
        {
            get
            {
                return _error;
            }
            set
            {
                _error = value;
                HasError = !string.IsNullOrEmpty(_error);
            }
        }

        public ServiceResultData ToServiceResultData()
        {
            ServiceResultData srd = 
                new ServiceResultData()
                {
                    IsReady = IsReady,
                    HasError = HasError,
                    Error = Error
                };

            if (IsReady)
            {
                srd.Result = Result.XmlSerialize().ToXmlElement();
            }

            return srd;
        }
        
        public void FromAdapterResult(AdapterResult<T> adapterResult)
        {
            IsReady = true;
            Result = (adapterResult.HasError) ? null as T : adapterResult.Result;
            Error = (adapterResult.HasError) ? adapterResult.Error : null as string;
            HasError = adapterResult.HasError;
        }

        internal void FromAdapterResult<R>(AdapterResult<CommonSignedResponse<R, T>> adapterResult)
        {
            IsReady = true;
            Result = (adapterResult.HasError) ? null as T : adapterResult.Result.Data.Response;
            Error = (adapterResult.HasError) ? adapterResult.Error : null as string;
            HasError = adapterResult.HasError;
        }
    }
    
    [Serializable]
    public class ServiceResultData : IErrorInfo
    {
        private string _error;

        [XmlElement]
        public bool IsReady { get; set; }

        [XmlElement]
        public XmlElement Result { get; set; }

        [XmlElement]
        public bool HasError { get; set; }

        [XmlElement]
        public string Error
        {
            get
            {
                return _error;
            }
            set
            {
                _error = value;
                HasError = !string.IsNullOrEmpty(_error);
            }
        }
    }
}
