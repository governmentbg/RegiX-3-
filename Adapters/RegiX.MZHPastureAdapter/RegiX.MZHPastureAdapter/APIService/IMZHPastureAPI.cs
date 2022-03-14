using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Adapters.Common.Attributes;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.MZHPastureAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на адаптер за комуникация с регистър MZH Pasture meadow land")]
    public interface IMZHPastureAPI : IAPIService
    {
        [OperationContract]
        [Description("Справка за ползване на пасища, мери и ливади")]
        [Info(
            requestXSD: "PastureMeadowLandRequest.xsd",
            responseXSD: "PastureMeadowLandResponse.xsd",
            requestXSLT: "PastureMeadowLandRequest.xslt",
            responseXSLT: "GetPastureMeadowLandResponse.xslt")]
        ServiceResultDataSigned<PastureMeadowLandRequestType, PastureMeadowLandResponse> GetPastureMeadowLand(ServiceRequestData<PastureMeadowLandRequestType> argument);

        [OperationContract]
        [Description("Справка с детайли за ползване на пасища, мери и ливади")]
        [Info(
            requestXSD: "PastureMeadowLandDetailRequest.xsd",
            responseXSD: "PastureMeadowLandDetailResponse.xsd",
            requestXSLT: "GetPastureMeadowLandDetailRequest.xslt",
            responseXSLT: "GetPastureMeadowLandDetailResponse.xslt")]
        ServiceResultDataSigned<PastureMeadowLandDetailRequestType, PastureMeadowLandDetailResponse> GetPastureMeadowLandDetail(ServiceRequestData<PastureMeadowLandDetailRequestType> argument);
    }
}
