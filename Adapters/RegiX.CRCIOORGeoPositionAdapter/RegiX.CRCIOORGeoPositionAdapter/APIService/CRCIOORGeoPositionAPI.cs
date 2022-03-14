using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.CRCIOORGeoPositionAdapter.AdapterService;

namespace TechnoLogica.RegiX.CRCIOORGeoPositionAdapter.APIService
{
	[Export(typeof(IAPIService))]
	[ExportFullName(typeof(ICRCIOORGeoPositionAPI), typeof(IAPIService))]
	public class CRCIOORGeoPositionAPI : BaseAPIService<ICRCIOORGeoPositionAPI>, ICRCIOORGeoPositionAPI
	{
		public ServiceResultDataSigned<GetCompanyInfoRequest, GetCompanyInfoResponseType> GetCompanyInfo(ServiceRequestData<GetCompanyInfoRequest> argument)
		{
			return AdapterClient.Execute<ICRCIOORGeoPositionAdapter, GetCompanyInfoRequest, GetCompanyInfoResponseType>(
				(i, r, a, o) => i.GetCompanyInfo(r, a, o),
				 argument);
		}
	}
}