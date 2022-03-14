using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.CRCPostalServicesAdapter.AdapterService;

namespace TechnoLogica.RegiX.CRCPostalServicesAdapter.APIService
{
	[Export(typeof(IAPIService))]
	[ExportFullName(typeof(ICRCPostalServicesAPI), typeof(IAPIService))]
	public class CRCPostalServicesAPI : BaseAPIService<ICRCPostalServicesAPI>, ICRCPostalServicesAPI
	{
		public ServiceResultDataSigned<GetUniversalOperatorsInfoRequest, GetUniversalOperatorsInfoResponseType> GetUniversalOperatorsInfo(ServiceRequestData<GetUniversalOperatorsInfoRequest> argument)
		{
			return AdapterClient.Execute<ICRCPostalServicesAdapter, GetUniversalOperatorsInfoRequest, GetUniversalOperatorsInfoResponseType>(
				(i, r, a, o) => i.GetUniversalOperatorsInfo(r, a, o),
				 argument);
		}
	}
}