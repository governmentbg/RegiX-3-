using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Adapters.Common.Attributes;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.MVRMPSAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на адаптер за комуникация с регистър МПС на МВР")]
    public interface IMVRMPSAPI : IAPIService
    {
        [OperationContract]
        [Description("Справка за МПС по регистрационен номер")]
        [Info(requestXSD: "MotorVehicleRegistrationRequest.xsd",
            responseXSD: "MotorVehicleRegistrationResponse.xsd",
            requestXSLT: "MotorVehicleRegistrationRequest.xslt",
            responseXSLT: "MotorVehicleRegistrationResponse.xslt")]
        ServiceResultDataSigned<MotorVehicleRegistrationRequestType, MotorVehicleRegistrationResponseType> GetMotorVehicleRegistrationInfo(ServiceRequestData<MotorVehicleRegistrationRequestType> argument);

        [OperationContract]
        [Description("Разширена справка за МПС по регистрационен номер")]
        [Info(requestXSD: "GetMotorVehicleRegistrationInfoV2Request.xsd",
            responseXSD: "GetMotorVehicleRegistrationInfoV2Response.xsd",
            requestXSLT: "MotorVehicleRegistrationRequestV2.xslt",
            responseXSLT: "MotorVehicleRegistrationResponseV2.xslt")]
        ServiceResultDataSigned<MotorVehicleRegistrationRequestTypeV2, GetMotorVehicleRegistrationInfoV2ResponseType> GetMotorVehicleRegistrationInfoV2(ServiceRequestData<MotorVehicleRegistrationRequestTypeV2> argument);

        [OperationContract]
        [Description("Разширена справка за МПС по регистрационен номер - V3")]
        [Info(requestXSD: "GetMotorVehicleRegistrationInfoV3Request.xsd",
            responseXSD: "GetMotorVehicleRegistrationInfoV3Response.xsd",
            requestXSLT: "MotorVehicleRegistrationRequestV3.xslt",
            responseXSLT: "MotorVehicleRegistrationResponseV3.xslt")]
        ServiceResultDataSigned<MotorVehicleRegistrationRequestTypeV3, GetMotorVehicleRegistrationInfoV3ResponseType> GetMotorVehicleRegistrationInfoV3(ServiceRequestData<MotorVehicleRegistrationRequestTypeV3> argument);

    }
}