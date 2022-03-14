using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.CRCNonUniversalPostalServicesAdapter.AdapterService;

namespace TechnoLogica.RegiX.CRCNonUniversalPostalServicesAdapter.APIService
{
	[Export(typeof(IAPIService))]
	[ExportFullName(typeof(ICRCNonUniversalPostalServicesAPI), typeof(IAPIService))]
	public class CRCNonUniversalPostalServicesAPI : BaseAPIService<ICRCNonUniversalPostalServicesAPI>, ICRCNonUniversalPostalServicesAPI
	{
		public ServiceResultDataSigned<GetNonUniversalOperatorsInfoRequest, GetNonUniversalOperatorsInfoResponseType> GetNonUniversalOperatorsInfo(ServiceRequestData<GetNonUniversalOperatorsInfoRequest> argument)
		{
			return AdapterClient.Execute<ICRCNonUniversalPostalServicesAdapter, GetNonUniversalOperatorsInfoRequest, GetNonUniversalOperatorsInfoResponseType>(
				(i, r, a, o) => i.GetNonUniversalOperatorsInfo(r, a, o),
				 argument);
		}
	}
}