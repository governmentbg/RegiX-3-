using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.CRCSubscribersAdapter.AdapterService;

namespace TechnoLogica.RegiX.CRCSubscribersAdapter.APIService
{
	[Export(typeof(IAPIService))]
	[ExportFullName(typeof(ICRCSubscribersAPI), typeof(IAPIService))]
	public class CRCSubscribersAPI : BaseAPIService<ICRCSubscribersAPI>, ICRCSubscribersAPI
	{
		public ServiceResultDataSigned<GetCompanyInfoRequest, GetCompanyInfoResponseType> GetCompanyInfo(ServiceRequestData<GetCompanyInfoRequest> argument)
		{
			return AdapterClient.Execute<ICRCSubscribersAdapter, GetCompanyInfoRequest, GetCompanyInfoResponseType>(
				(i, r, a, o) => i.GetCompanyInfo(r, a, o),
				 argument);
		}
	}
}