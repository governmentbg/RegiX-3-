using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.CRCIOORGeoPositionAdapter.AdapterService
{
	[ServiceContract]
	[Description("Адаптер „Позиция на геостационарна орбита“")]
	public interface ICRCIOORGeoPositionAdapter : IAdapterServiceWCF
	{
		[OperationContract]
		[Description("Справка за предприятие")]
		CommonSignedResponse<GetCompanyInfoRequest, GetCompanyInfoResponseType> GetCompanyInfo(GetCompanyInfoRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters);
	}
}