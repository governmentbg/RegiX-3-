using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.IaaaVehicleInspectionsAdapter.AdapterService
{
    [ServiceContract]
    [Description("Регистър на издадените разрешения по чл. 2, на председателите на комисиите, извършващи прегледите, и на техническите специалисти")]
    public interface IIaaaVehicleInspectionsAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Справка за статус на регистрацията по ЕИК.")]
        CommonSignedResponse<PermitRequestType, PermitResponse> GetReport1Permit(PermitRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка по лице за вписвания като председател на комисия/технически специалист в регистрирани пунктове за технически прегледи.")]
        CommonSignedResponse<PermitInspectorsRequestType, PermitInspectorsResponse> GetReport2PermitInspectors(PermitInspectorsRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка по ЕИК за обслужени автомобили за период.")]
        CommonSignedResponse<PermitsInspectionCountRequestType, PermitsInspectionCountResponse> GetReport3PermitsInspectionCount(PermitsInspectionCountRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка за извършен технически преглед по регистрационен номер на автомобил.")]
        CommonSignedResponse<VehicleInspectionRequestType, VehicleInspectionResponse> GetReport4VehicleInspection(VehicleInspectionRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка за проверка на автентичност на стикер за технически преглед.")]
        CommonSignedResponse<VehicleInspectionStickerRequestType, VehicleInspectionResponse> GetReport5VehicleInspectionSticker(VehicleInspectionStickerRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);
    }
}

