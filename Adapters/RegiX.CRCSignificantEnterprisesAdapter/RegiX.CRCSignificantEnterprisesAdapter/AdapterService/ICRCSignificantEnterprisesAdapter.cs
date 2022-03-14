using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.CRCSignificantEnterprisesAdapter.AdapterService
{
	[ServiceContract]
	[Description("Адаптер „Предприятия  със  значително въздействие“")]
	public interface ICRCSignificantEnterprisesAdapter : IAdapterServiceWCF
	{
		[OperationContract]
		[Description("Справка за предприятие")]
		CommonSignedResponse<GetCompanyInfoRequest, GetCompanyInfoResponseType> GetCompanyInfo(GetCompanyInfoRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters);
	}
}