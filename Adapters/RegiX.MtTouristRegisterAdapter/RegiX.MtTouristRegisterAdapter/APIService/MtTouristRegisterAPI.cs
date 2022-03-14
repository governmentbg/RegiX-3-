using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.MtTouristRegisterAdapter.AdapterService;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.MtTouristRegisterAdapter.APIService
{
    [ExportFullName(typeof(IMtTouristRegisterAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class MtTouristRegisterAPI : BaseAPIService<IMtTouristRegisterAPI>, IMtTouristRegisterAPI
    {
        public ServiceResultDataSigned<BarRestaurantCategoryByEIKRequestType, TouristEntertainmentObjectArray> GetTotaRegBarRestaurantCategoryByEIK(ServiceRequestData<BarRestaurantCategoryByEIKRequestType> argument)
        {
            return  AdapterClient.Execute<IMtTouristRegisterAdapter, BarRestaurantCategoryByEIKRequestType, TouristEntertainmentObjectArray>(
                (i, r, a, o) => i.GetTotaRegBarRestaurantCategoryByEIK(r, a, o),
                 argument);
        }

        public ServiceResultDataSigned<ObjectCategoryByEIKRequestType, TouristObjectArray> GetTotaRegCategoryByEIK(ServiceRequestData<ObjectCategoryByEIKRequestType> argument)
        {
            return  AdapterClient.Execute<IMtTouristRegisterAdapter, ObjectCategoryByEIKRequestType, TouristObjectArray>(
                (i, r, a, o) => i.GetTotaRegCategoryByEIK(r, a, o),
                 argument);
        }

        public ServiceResultDataSigned<TOInsuranceByEIKRequestType, InsuranceArray> GetTotaRegToInsuranceByEIK(ServiceRequestData<TOInsuranceByEIKRequestType> argument)
        {
            return AdapterClient.Execute<IMtTouristRegisterAdapter, TOInsuranceByEIKRequestType, InsuranceArray>(
                (i, r, a, o) => i.GetTotaRegToInsuranceByEIK(r, a, o),
                 argument);
        }

        public ServiceResultDataSigned<TOTAByEIKRequestType, Tota> GetTotaRegTotaByEIK(ServiceRequestData<TOTAByEIKRequestType> argument)
        {
            return AdapterClient.Execute<IMtTouristRegisterAdapter, TOTAByEIKRequestType, Tota>(
                (i, r, a, o) => i.GetTotaRegTotaByEIK(r, a, o),
                 argument);
        }
    }
}
