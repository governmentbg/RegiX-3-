using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.CRCIOORNumbersAdapter.AdapterService;

namespace TechnoLogica.RegiX.CRCIOORNumbersAdapter.APIService
{
	[Export(typeof(IAPIService))]
	[ExportFullName(typeof(ICRCIOORNumbersAPI), typeof(IAPIService))]
	public class CRCIOORNumbersAPI : BaseAPIService<ICRCIOORNumbersAPI>, ICRCIOORNumbersAPI
	{
		public ServiceResultDataSigned<GetCompanyInfoRequest, GetCompanyInfoResponseType> GetCompanyInfo(ServiceRequestData<GetCompanyInfoRequest> argument)
		{
			return AdapterClient.Execute<ICRCIOORNumbersAdapter, GetCompanyInfoRequest, GetCompanyInfoResponseType>(
				(i, r, a, o) => i.GetCompanyInfo(r, a, o),
				 argument);
		}
	}
}