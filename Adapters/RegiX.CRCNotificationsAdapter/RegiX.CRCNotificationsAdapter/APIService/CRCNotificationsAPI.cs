using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.CRCNotificationsAdapter.AdapterService;

namespace TechnoLogica.RegiX.CRCNotificationsAdapter.APIService
{
	[Export(typeof(IAPIService))]
	[ExportFullName(typeof(ICRCNotificationsAPI), typeof(IAPIService))]
	public class CRCNotificationsAPI : BaseAPIService<ICRCNotificationsAPI>, ICRCNotificationsAPI
	{
		public ServiceResultDataSigned<GetCompanyInfoRequest, GetCompanyInfoResponseType> GetCompanyInfo(ServiceRequestData<GetCompanyInfoRequest> argument)
		{
			return AdapterClient.Execute<ICRCNotificationsAdapter, GetCompanyInfoRequest, GetCompanyInfoResponseType>(
				(i, r, a, o) => i.GetCompanyInfo(r, a, o),
				 argument);
		}

		public ServiceResultDataSigned<GetNetworksAndServicesInfoRequest, GetNetworksAndServicesInfoResponseType> GetNetworksAndServicesInfo(ServiceRequestData<GetNetworksAndServicesInfoRequest> argument)
		{
			return AdapterClient.Execute<ICRCNotificationsAdapter, GetNetworksAndServicesInfoRequest, GetNetworksAndServicesInfoResponseType>(
				(i, r, a, o) => i.GetNetworksAndServicesInfo(r, a, o),
				 argument);
		}
	}
}