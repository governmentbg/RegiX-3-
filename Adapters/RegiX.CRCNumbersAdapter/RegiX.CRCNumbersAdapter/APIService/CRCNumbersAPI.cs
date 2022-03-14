using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.CRCNumbersAdapter.AdapterService;

namespace TechnoLogica.RegiX.CRCNumbersAdapter.APIService
{
	[Export(typeof(IAPIService))]
	[ExportFullName(typeof(ICRCNumbersAPI), typeof(IAPIService))]
	public class CRCNumbersAPI : BaseAPIService<ICRCNumbersAPI>, ICRCNumbersAPI
	{
		public ServiceResultDataSigned<GetNumbersInfoRequest, GetNumbersInfoResponseType> GetNumbersInfo(ServiceRequestData<GetNumbersInfoRequest> argument)
		{
			return AdapterClient.Execute<ICRCNumbersAdapter, GetNumbersInfoRequest, GetNumbersInfoResponseType>(
				(i, r, a, o) => i.GetNumbersInfo(r, a, o),
				 argument);
		}
	}
}