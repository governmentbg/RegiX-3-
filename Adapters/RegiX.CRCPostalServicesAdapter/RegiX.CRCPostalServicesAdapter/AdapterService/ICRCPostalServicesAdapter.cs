using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.CRCPostalServicesAdapter.AdapterService
{
	[ServiceContract]
	[Description("Адаптер „Универсални пощенски услуги“")]
	public interface ICRCPostalServicesAdapter : IAdapterServiceWCF
	{
		[OperationContract]
		[Description("Справка за универсални оператори")]
		CommonSignedResponse<GetUniversalOperatorsInfoRequest, GetUniversalOperatorsInfoResponseType> GetUniversalOperatorsInfo(GetUniversalOperatorsInfoRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters);
	}
}