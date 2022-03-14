using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.BABHZhSAdapter.AdapterService;
using TechnoLogica.RegiX.BABHZhSAdapter.RegisteredAnimalsInOEZByCategory;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.BABHZhSAdapter.APIService
{
    [ExportFullName(typeof(IBABHZhSAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class BABHZhSAPI : BaseAPIService<IBABHZhSAPI>, IBABHZhSAPI
    {
        public ServiceResultDataSigned<AnimalIdentificationRequestType, AnimalIdentificationResponseType> GetAnimalIdentification(ServiceRequestData<AnimalIdentificationRequestType> argument)
        {
            return AdapterClient.Execute<IBABHZhSAdapter, AnimalIdentificationRequestType, AnimalIdentificationResponseType>(
                        (i, r, a, o) => i.GetAnimalIdentification(r, a, o),
                        argument);
        }

        public ServiceResultDataSigned<MotorVehicleLicenceRequestType, MotorVehicleLicenceResponseType> GetMotorVehicleLicence(ServiceRequestData<MotorVehicleLicenceRequestType> argument)
        {
            return AdapterClient.Execute<IBABHZhSAdapter, MotorVehicleLicenceRequestType, MotorVehicleLicenceResponseType>(
                        (i, r, a, o) => i.GetMotorVehicleLicence(r, a, o),
                        argument);
        }

        public ServiceResultDataSigned<RegisteredAnimalsByCategoryRequestType, RegisteredAnimalsByCategoryResponseType> GetRegisteredAnimalsByCategory(ServiceRequestData<RegisteredAnimalsByCategoryRequestType> argument)
        {
            return AdapterClient.Execute<IBABHZhSAdapter, RegisteredAnimalsByCategoryRequestType, RegisteredAnimalsByCategoryResponseType>(
                        (i, r, a, o) => i.GetRegisteredAnimalsByCategory(r, a, o),
                        argument);
        }

        public ServiceResultDataSigned<RegisteredAnimalsInOEZCategoryRequestType, RegisteredAnimalsInOEZByCategoryResponseType> GetRegisteredAnimalsInOEZByCategory(ServiceRequestData<RegisteredAnimalsInOEZCategoryRequestType> argument)
        {
            return AdapterClient.Execute<IBABHZhSAdapter, RegisteredAnimalsInOEZCategoryRequestType, RegisteredAnimalsInOEZByCategoryResponseType>(
                        (i, r, a, o) => i.GetRegisteredAnimalsInOEZByCategory(r, a, o),
                        argument);
        }
    }
}
