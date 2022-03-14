using System.ServiceModel;
using System.ComponentModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Adapters.Common.Attributes;

namespace TechnoLogica.RegiX.IaaaVehicleInspectionsAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("Регистър на издадените разрешения по чл. 2, на председателите на комисиите, извършващи прегледите, и на техническите специалисти")]
    public interface IIaaaVehicleInspectionsAPI : IAPIService
    {
        //Справка за статус на регистрацията по ЕИК
        [OperationContract]
        [Description("Справка за статус на регистрацията по ЕИК")]
        [Info(
            requestXSD: "Report1_permitRequest.xsd",
            responseXSD: "Report1_permitResponse.xsd",
            commonXSD: "RIR2Common.xsd",
            requestXSLT: "Report1_permitRequest.xslt",
            responseXSLT: "Report1_permitResponse.xslt")]
        ServiceResultDataSigned<PermitRequestType, PermitResponse> GetReport1Permit(ServiceRequestData<PermitRequestType> argument);


        //Справка за статус на регистрацията по ЕИК
        [OperationContract]
        [Description("Справка по лице за вписвания като председател на комисия/технически специалист в регистрирани пунктове за технически прегледи")]
        [Info(
            requestXSD: "Report2_permitInspectorsRequest.xsd",
            responseXSD: "Report2_permitInspectorsResponse.xsd",
            commonXSD: "RIR2Common.xsd",
            requestXSLT: "Report2_permitInspectorsRequest.xslt",
            responseXSLT: "Report2_permitInspectorsResponse.xslt")]
        ServiceResultDataSigned<PermitInspectorsRequestType, PermitInspectorsResponse> GetReport2PermitInspectors(ServiceRequestData<PermitInspectorsRequestType> argument);


        //Справка по ЕИК за обслужени автомобили за период
        [OperationContract]
        [Description("Справка по ЕИК за обслужени автомобили за период")]
        [Info(
            requestXSD: "Report3_permitsInspectionCountRequest.xsd",
            responseXSD: "Report3_permitsInspectionCountResponse.xsd",
            commonXSD: "RIR2Common.xsd",
            requestXSLT: "Report3_permitsInspectionCountRequest.xslt",
            responseXSLT: "Report3_permitsInspectionCountResponse.xslt")]
        ServiceResultDataSigned<PermitsInspectionCountRequestType, PermitsInspectionCountResponse> GetReport3PermitsInspectionCount(ServiceRequestData<PermitsInspectionCountRequestType> argument);


        //Справка за извършен технически преглед по регистрационен номер на автомобил
        [OperationContract]
        [Description("Справка за извършен технически преглед по регистрационен номер на автомобил")]
        [Info(
            requestXSD: "Report4_vehicleInspectionRequest.xsd",
            responseXSD: "Report4_vehicleInspectionResponse.xsd",
            commonXSD: "RIR2Common.xsd",
            requestXSLT: "Report4_vehicleInspectionRequest.xslt",
            responseXSLT: "Report4_vehicleInspectionResponse.xslt")]
        ServiceResultDataSigned<VehicleInspectionRequestType, VehicleInspectionResponse> GetReport4VehicleInspection(ServiceRequestData<VehicleInspectionRequestType> argument);


        //Справка за проверка на автентичност на стикер за технически преглед
        [OperationContract]
        [Description("Справка за проверка на автентичност на стикер за технически преглед")]
        [Info(
            requestXSD: "Report5_vehicleInspectionStickerRequest.xsd",
            responseXSD: "Report4_vehicleInspectionResponse.xsd",
            commonXSD: "RIR2Common.xsd",
            requestXSLT: "Report5_vehicleInspectionStickerRequest.xslt",
            responseXSLT: "Report4_vehicleInspectionResponse.xslt")]
        ServiceResultDataSigned<VehicleInspectionStickerRequestType, VehicleInspectionResponse> GetReport5VehicleInspectionSticker(ServiceRequestData<VehicleInspectionStickerRequestType> argument);
    }
}
