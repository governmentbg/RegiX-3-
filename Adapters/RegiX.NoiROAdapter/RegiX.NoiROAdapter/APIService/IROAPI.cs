using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Adapters.Common.Attributes;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.NoiROAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на адаптер за комуникация с Регистър на обезщетенията по болест, майчинство и безработица")]
    public interface IROAPI : IAPIService
    {
        //SearchDisabilityCompensationByCompensationPeriod
        [OperationContract]
        [Description("Справка за изплатено парично обезщетение при временна неработоспособност, трудоустрояване и майчинство и/или помощ по период на обезщетението")]
        [Info(
            requestXSD: "POVNPOBRequest.xsd",
            responseXSD: "POVNPOBResponse.xsd",
            commonXSD: "ROCommon.xsd",
            requestXSLT: "POVNPOBRequest.xslt",
            responseXSLT: "POVNPOBResponse.xslt"
            )]
        ServiceResultDataSigned<POVNPOBRequestType, POVNPOBResponseType> SearchDisabilityCompensationByCompensationPeriod(ServiceRequestData<POVNPOBRequestType> argument);

        //SearchDisabilityCompensationByPaymentPeriod
        [OperationContract]
        [Description("Справка за изплатено парично обезщетение при временна неработоспособност, трудоустрояване и майчинство и/или помощ по период на дата на ведомост /дата на плащане")]
        [Info(
            requestXSD: "POVNVEDRequest.xsd",
            responseXSD: "POVNVEDResponse.xsd",
            commonXSD: "ROCommon.xsd",
            requestXSLT: "POVNVEDRequest.xslt",
            responseXSLT: "POVNVEDResponse.xslt"
            )]
        ServiceResultDataSigned<POVNVEDRequestType, POVNVEDResponseType> SearchDisabilityCompensationByPaymentPeriod(ServiceRequestData<POVNVEDRequestType> argument);

        //SearchUnemploymentCompensationByCompensationPeriod
        [OperationContract]
        [Description("Справка за изплатено парично обезщетение за безработица по период на обезщетението")]
        [Info(
            requestXSD: "POBPOBRequest.xsd",
            responseXSD: "POBPOBResponse.xsd",
            commonXSD: "ROCommon.xsd",
            requestXSLT: "POBPOBRequest.xslt",
            responseXSLT: "POBPOBResponse.xslt"
            )]
        ServiceResultDataSigned<POBPOBRequestType, POBPOBResponseType> SearchUnemploymentCompensationByCompensationPeriod(ServiceRequestData<POBPOBRequestType> argument);

        //SearchUnemploymentCompensationByPaymentPeriod
        [OperationContract]
        [Description("Справка за изплатено парично обезщетение за безработица по период на дата на ведомост /дата на плащане")]
        [Info(
            requestXSD: "POBVEDRequest.xsd",
            responseXSD: "POBVEDResponse.xsd",
            commonXSD: "ROCommon.xsd",
            requestXSLT: "POBVEDRequest.xslt",
            responseXSLT: "POBVEDResponse.xslt"
            )]
        ServiceResultDataSigned<POBVEDRequestType, POBVEDResponseType> SearchUnemploymentCompensationByPaymentPeriod(ServiceRequestData<POBVEDRequestType> argument);
    }
}
