using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.IAMAVesselsAdapter.AdapterService;


namespace TechnoLogica.RegiX.IAMAVesselsAdapter.APIService
{
    [ExportFullName(typeof(IVesselsAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class VesselsAPI : BaseAPIService<IVesselsAPI>, IVesselsAPI
    {      
        #region RegistrationSearchByOwner
        public ServiceResultDataSigned<Ships.ShipsByOwnerRequest, Ships.ShipsResponse> RegistrationSearchByOwner(ServiceRequestData<Ships.ShipsByOwnerRequest> argument)
        {
            return  AdapterClient.Execute<IVesselsAdapter, Ships.ShipsByOwnerRequest, Ships.ShipsResponse>(
                        (i, r, a, o) => i.RegistrationSearchByOwner(r, a, o),
                        argument);
        }

        #endregion

        #region RegistrationByCharacteristicsSearch
        public ServiceResultDataSigned<Ships.ShipsByCharacteristicsRequest, Ships.ShipsResponse> RegistrationByCharacteristicsSearch(ServiceRequestData<Ships.ShipsByCharacteristicsRequest> argument)
        {
            return AdapterClient.Execute<IVesselsAdapter, Ships.ShipsByCharacteristicsRequest, Ships.ShipsResponse>(
                        (i, r, a, o) => i.RegistrationByCharacteristicsSearch(r, a, o),
                        argument);
        }
        #endregion

        public ServiceResultDataSigned<Ships.NomenclaturesRequest, Ships.NomenclatureResponse> GetNomenclatures(ServiceRequestData<Ships.NomenclaturesRequest> argument)
        {
            return  AdapterClient.Execute<IVesselsAdapter, Ships.NomenclaturesRequest, Ships.NomenclatureResponse>(
                       (i, r, a, o) => i.GetNomenclatures(r, a, o),
                       argument);
        }
    }
}
