using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ServiceModel;
using System.Text;
using TechnoLogica.RegiX.Adapters.Common.Attributes;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.NOIHospotalSheetsAdapter;

namespace TechnoLogica.RegiX.NOIHospitalSheetsAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на адаптер за комуникация с Електронен регистър на болничните листове")]
    public interface INOIHospitalSheetsAPI : IAPIService
    {
        [OperationContract]
        [Description("Справка за постъпили данни от издадени/ анулирани болнични листове по ЕГН/ ЛНЧ")]
        [Info(requestXSD: "GetHospitalSheetsDataRequest.xsd",
           responseXSD: "GetHospitalSheetsDataResponse.xsd",
           requestXSLT: "GetHospitalSheetsDataRequest.xslt",
           responseXSLT: "GetHospitalSheetsDataResponse.xslt")]
        ServiceResultDataSigned<GetHospitalSheetsDataRequestType, GetHospitalSheetsDataResponseType> GetHospitalSheetsData(ServiceRequestData<GetHospitalSheetsDataRequestType> argument);

    }
}
