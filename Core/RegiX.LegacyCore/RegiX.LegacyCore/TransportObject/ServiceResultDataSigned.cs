using System;
using System.Xml;
using System.Xml.Serialization;
using TechnoLogica.RegiX.Common.Utils;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Core;

namespace TechnoLogica.RegiX.LegacyCore.TransportObject
{

    [Serializable]
    [XmlType(Namespace = "http://egov.bg/RegiX")]
    public class ServiceResultDataSigned<R, T> : IErrorInfo
        where T : class
        where R : class
    {
        private string _error;

        [XmlElement]
        public bool IsReady { get; set; }

        [XmlElement]
        public T Result { get; set; }

        [XmlElement]
        public R Request { get; set; }

        [XmlElement]
        public DataAccessMatrix Matrix { get; set; }

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

        public Signed.ServiceResultData ToServiceResultDataSigned()
        {
            Signed.ServiceResultData srd =
                new Signed.ServiceResultData()
                {
                    IsReady = IsReady,
                    HasError = HasError,
                    Error = Error
                };

            if (IsReady &&  Result != null &&! HasError)
            {
                var data = SigningUtils.GetDataContainer(Request.XmlSerialize().ToXmlElement(), Result.XmlSerialize().ToXmlElement(), Matrix);
                srd.Data = 
                    new DataContainer()
                    {
                        Matrix = data?.Matrix,
                        Request = data?.Request,
                        Response = data?.Response
                    };
                //SigningUtils.GetCommonSignedResponseWithSignature(Request.XmlSerialize().ToXmlElement(), Result.XmlSerialize().ToXmlElement(), Matrix);
                srd.Signature = Signature;
               // bool result = SigningUtils.ValidateXmlDocumentWithX509Certificate(srd.XmlSerialize().ToXmlElement());
            }

            return srd;
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

        [XmlAnyElement]
        public XmlElement Signature{ get; set; }
        
        public void FromAdapterResult(AdapterResult<CommonSignedResponse<R, T>> adapterResult)
        {
            IsReady = true;
            Result = (adapterResult.HasError) ? null as T : adapterResult.Result.Data.Response;
            Request = (adapterResult.HasError) ? null as R : adapterResult.Result.Data.Request;
            Matrix = (adapterResult.HasError) ? null as DataAccessMatrix : adapterResult.Result.Data.Matrix;
            Signature = (adapterResult.HasError) ? null : adapterResult.Result.Signature;
            Error = (adapterResult.HasError) ? adapterResult.Error : null as string;
            HasError = adapterResult.HasError;
        }

        public void FromAdapterResult(AdapterResult<T> adapterResult, R request)
        {
            IsReady = true;
            Result = (adapterResult.HasError) ? null as T : adapterResult.Result;
            Request = (adapterResult.HasError) ? null as R : request;
            //Matrix = ?;
            //Signature = SIGN;
            Error = (adapterResult.HasError) ? adapterResult.Error : null as string;
            HasError = adapterResult.HasError;
        }
    }

   
}
