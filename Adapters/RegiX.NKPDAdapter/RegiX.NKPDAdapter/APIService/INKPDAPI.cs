using System.ServiceModel;
using System.ComponentModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Adapters.Common.Attributes;

namespace TechnoLogica.RegiX.NKPDAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на адаптер за комуникация с класификатора НКПД")]
    public interface INKPDAPI : IAPIService
    {
        // Справка за търсене на целия класификатор НКПД
        [OperationContract]
        [Description("Справка за търсене на целия класификатор НКПД")]
        [Info(
            requestXSD: "AllNKPDDataRequest.xsd",
            responseXSD: "AllNKPDDataResponse.xsd",
            commonXSD: "NKPDCommon.xsd",
            requestXSLT: "AllNKPDDataRequest.xslt",
            responseXSLT: "NKPD_allData.xslt")]
        ServiceResultDataSigned<AllNKPDDataSearchType, AllNKPDDataType> GetNKPDAllData(ServiceRequestData<AllNKPDDataSearchType> argument);

        // Справка за търсене на данни от класификатор НКПД по зададени критерии
        [OperationContract]
        [Description("Справка за търсене на данни от класификатор НКПД по зададени критерии")]
        [Info(
            requestXSD: "NKPDDataRequest.xsd",
            responseXSD: "NKPDDataResponse.xsd",
            commonXSD: "NKPDCommon.xsd",
            requestXSLT: "NKPDDataRequest.xslt",
            responseXSLT: "NKPD_responseData.xslt")]
        ServiceResultDataSigned<NKPDDataSearchType, NKPDDataType> GetNKPDData(ServiceRequestData<NKPDDataSearchType> argument);
    }
}
