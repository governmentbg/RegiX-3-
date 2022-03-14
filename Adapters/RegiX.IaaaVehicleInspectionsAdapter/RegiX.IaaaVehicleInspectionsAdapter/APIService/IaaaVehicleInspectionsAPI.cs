using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.IaaaVehicleInspectionsAdapter.AdapterService;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.IaaaVehicleInspectionsAdapter.APIService
{
    [ExportFullName(typeof(IIaaaVehicleInspectionsAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class IaaaVehicleInspectionsAPI : BaseAPIService<IIaaaVehicleInspectionsAPI>, IIaaaVehicleInspectionsAPI
    {
        public ServiceResultDataSigned<PermitRequestType, PermitResponse> GetReport1Permit(ServiceRequestData<PermitRequestType> argument)
        {
            return  AdapterClient.Execute<IIaaaVehicleInspectionsAdapter, PermitRequestType, PermitResponse>(
                (i, r, a, o) => i.GetReport1Permit(r, a, o),
                 argument);
        }

        public ServiceResultDataSigned<PermitInspectorsRequestType, PermitInspectorsResponse> GetReport2PermitInspectors(ServiceRequestData<PermitInspectorsRequestType> argument)
        {
            return AdapterClient.Execute<IIaaaVehicleInspectionsAdapter, PermitInspectorsRequestType, PermitInspectorsResponse>(
                (i, r, a, o) => i.GetReport2PermitInspectors(r, a, o),
                 argument);
        }

        public ServiceResultDataSigned<PermitsInspectionCountRequestType, PermitsInspectionCountResponse> GetReport3PermitsInspectionCount(ServiceRequestData<PermitsInspectionCountRequestType> argument)
        {
            return AdapterClient.Execute<IIaaaVehicleInspectionsAdapter, PermitsInspectionCountRequestType, PermitsInspectionCountResponse>(
                (i, r, a, o) => i.GetReport3PermitsInspectionCount(r, a, o),
                 argument);
        }

        public ServiceResultDataSigned<VehicleInspectionRequestType, VehicleInspectionResponse> GetReport4VehicleInspection(ServiceRequestData<VehicleInspectionRequestType> argument)
        {
            return AdapterClient.Execute<IIaaaVehicleInspectionsAdapter, VehicleInspectionRequestType, VehicleInspectionResponse>(
                (i, r, a, o) => i.GetReport4VehicleInspection(r, a, o),
                 argument);
        }

        public ServiceResultDataSigned<VehicleInspectionStickerRequestType, VehicleInspectionResponse> GetReport5VehicleInspectionSticker(ServiceRequestData<VehicleInspectionStickerRequestType> argument)
        {
            return  AdapterClient.Execute<IIaaaVehicleInspectionsAdapter, VehicleInspectionStickerRequestType, VehicleInspectionResponse>(
                (i, r, a, o) => i.GetReport5VehicleInspectionSticker(r, a, o),
                 argument);
        }
    }
}

