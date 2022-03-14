using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.CRCNotificationsAdapter.AdapterService
{
	[ServiceContract]
	[Description("Адаптер за уведомления")]
	public interface ICRCNotificationsAdapter : IAdapterServiceWCF
	{
		[OperationContract]
		[Description("Справка за предприятие")]
		CommonSignedResponse<GetCompanyInfoRequest, GetCompanyInfoResponseType> GetCompanyInfo(GetCompanyInfoRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters);

		[OperationContract]
		[Description("Справка по мрежа/услуга")]
		CommonSignedResponse<GetNetworksAndServicesInfoRequest, GetNetworksAndServicesInfoResponseType> GetNetworksAndServicesInfo(GetNetworksAndServicesInfoRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters);
	}
}