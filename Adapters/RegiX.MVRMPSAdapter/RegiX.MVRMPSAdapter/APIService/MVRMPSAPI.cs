using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.MVRMPSAdapter.AdapterService;

namespace TechnoLogica.RegiX.MVRMPSAdapter.APIService
{
    [ExportFullName(typeof(IMVRMPSAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class MVRMPSAPI : BaseAPIService<IMVRMPSAPI>, IMVRMPSAPI
    {
        public ServiceResultDataSigned<MotorVehicleRegistrationRequestType, MotorVehicleRegistrationResponseType> GetMotorVehicleRegistrationInfo(ServiceRequestData<MotorVehicleRegistrationRequestType> argument)
        {
            return  AdapterClient.Execute<IMVRMPSAdapter, MotorVehicleRegistrationRequestType, MotorVehicleRegistrationResponseType>(
                        (i, r, a, o) => i.GetMotorVehicleRegistrationInfo(r, a, o),
                        argument);
        }

        public ServiceResultDataSigned<MotorVehicleRegistrationRequestTypeV2, GetMotorVehicleRegistrationInfoV2ResponseType> GetMotorVehicleRegistrationInfoV2(ServiceRequestData<MotorVehicleRegistrationRequestTypeV2> argument)
        {
            return  AdapterClient.Execute<IMVRMPSAdapter, MotorVehicleRegistrationRequestTypeV2, GetMotorVehicleRegistrationInfoV2ResponseType>(
                        (i, r, a, o) => i.GetMotorVehicleRegistrationInfoV2(r, a, o),
                        argument);
        }

        public ServiceResultDataSigned<MotorVehicleRegistrationRequestTypeV3, GetMotorVehicleRegistrationInfoV3ResponseType> GetMotorVehicleRegistrationInfoV3(ServiceRequestData<MotorVehicleRegistrationRequestTypeV3> argument)
        {
            return AdapterClient.Execute<IMVRMPSAdapter, MotorVehicleRegistrationRequestTypeV3, GetMotorVehicleRegistrationInfoV3ResponseType>(
                        (i, r, a, o) => i.GetMotorVehicleRegistrationInfoV3(r, a, o),
                        argument);
        }
    }
}
