using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.CRCTransferredRightsAdapter.AdapterService;

namespace TechnoLogica.RegiX.CRCTransferredRightsAdapter.APIService
{
	[Export(typeof(IAPIService))]
	[ExportFullName(typeof(ICRCTransferredRightsAPI), typeof(IAPIService))]
	public class CRCTransferredRightsAPI : BaseAPIService<ICRCTransferredRightsAPI>, ICRCTransferredRightsAPI
	{
		public ServiceResultDataSigned<GetRentedIOORInfoRequest, GetRentedIOORInfoResponseType> GetRentedIOORInfo(ServiceRequestData<GetRentedIOORInfoRequest> argument)
		{
			return AdapterClient.Execute<ICRCTransferredRightsAdapter, GetRentedIOORInfoRequest, GetRentedIOORInfoResponseType>(
				(i, r, a, o) => i.GetRentedIOORInfo(r, a, o),
				 argument);
		}

		public ServiceResultDataSigned<GetTransferredRightsRequest, GetTransferredRightsInfoResponseType> GetTransferredRightsInfo(ServiceRequestData<GetTransferredRightsRequest> argument)
		{
			return AdapterClient.Execute<ICRCTransferredRightsAdapter, GetTransferredRightsRequest, GetTransferredRightsInfoResponseType>(
				(i, r, a, o) => i.GetTransferredRightsInfo(r, a, o),
				 argument);
		}
	}
}