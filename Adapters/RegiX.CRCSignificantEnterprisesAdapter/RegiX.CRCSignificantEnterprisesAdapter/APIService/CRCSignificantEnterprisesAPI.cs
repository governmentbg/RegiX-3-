using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.CRCSignificantEnterprisesAdapter.AdapterService;

namespace TechnoLogica.RegiX.CRCSignificantEnterprisesAdapter.APIService
{
	[Export(typeof(IAPIService))]
	[ExportFullName(typeof(ICRCSignificantEnterprisesAPI), typeof(IAPIService))]
	public class CRCSignificantEnterprisesAPI : BaseAPIService<ICRCSignificantEnterprisesAPI>, ICRCSignificantEnterprisesAPI
	{
		public ServiceResultDataSigned<GetCompanyInfoRequest, GetCompanyInfoResponseType> GetCompanyInfo(ServiceRequestData<GetCompanyInfoRequest> argument)
		{
			return AdapterClient.Execute<ICRCSignificantEnterprisesAdapter, GetCompanyInfoRequest, GetCompanyInfoResponseType>(
				(i, r, a, o) => i.GetCompanyInfo(r, a, o),
				 argument);
		}
	}
}