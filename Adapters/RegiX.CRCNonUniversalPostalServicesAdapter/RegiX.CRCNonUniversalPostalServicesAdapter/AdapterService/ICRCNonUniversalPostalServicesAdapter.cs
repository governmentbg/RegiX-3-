using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.CRCNonUniversalPostalServicesAdapter.AdapterService
{
	[ServiceContract]
	[Description("Адаптер „Неуниверсални пощенски услуги“")]
	public interface ICRCNonUniversalPostalServicesAdapter : IAdapterServiceWCF
	{
		[OperationContract]
		[Description("Справка за неуниверсални оператори")]
		CommonSignedResponse<GetNonUniversalOperatorsInfoRequest, GetNonUniversalOperatorsInfoResponseType> GetNonUniversalOperatorsInfo(GetNonUniversalOperatorsInfoRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters);
	}
}