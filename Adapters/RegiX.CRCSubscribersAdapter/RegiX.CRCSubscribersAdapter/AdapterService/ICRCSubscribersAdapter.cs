using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.CRCSubscribersAdapter.AdapterService
{
	[ServiceContract]
	[Description("Адаптер за брой крайни ползватели")]
	public interface ICRCSubscribersAdapter : IAdapterServiceWCF
	{
		[OperationContract]
		[Description("Справка за предприятие")]
		CommonSignedResponse<GetCompanyInfoRequest, GetCompanyInfoResponseType> GetCompanyInfo(GetCompanyInfoRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters);
	}
}