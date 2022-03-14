using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.CRCNumbersAdapter.AdapterService
{
	[ServiceContract]
	[Description("Адаптер „Предоставени номерационни ресурси“")]
	public interface ICRCNumbersAdapter : IAdapterServiceWCF
	{
		[OperationContract]
		[Description("Справка за номера")]
		CommonSignedResponse<GetNumbersInfoRequest, GetNumbersInfoResponseType> GetNumbersInfo(GetNumbersInfoRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters);
	}
}