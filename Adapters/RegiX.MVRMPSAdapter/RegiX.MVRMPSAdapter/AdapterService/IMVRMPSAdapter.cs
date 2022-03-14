using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.MVRMPSAdapter.AdapterService
{
    [ServiceContract]
    [Description("Aдаптер за връзка с регистър МПС на МВР")]
    public interface IMVRMPSAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Справка за МПС по регистрационен номер")]
        CommonSignedResponse<MotorVehicleRegistrationRequestType, MotorVehicleRegistrationResponseType> GetMotorVehicleRegistrationInfo(MotorVehicleRegistrationRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters);

        [OperationContract]
        [Description("Разширена справка за МПС по регистрационен номер")]
        CommonSignedResponse<MotorVehicleRegistrationRequestTypeV2, GetMotorVehicleRegistrationInfoV2ResponseType> GetMotorVehicleRegistrationInfoV2(MotorVehicleRegistrationRequestTypeV2 argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters);

        [OperationContract]
        [Description("Разширена справка за МПС по регистрационен номер - V3")]
        CommonSignedResponse<MotorVehicleRegistrationRequestTypeV3, GetMotorVehicleRegistrationInfoV3ResponseType> GetMotorVehicleRegistrationInfoV3(MotorVehicleRegistrationRequestTypeV3 argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters);

    }
}
