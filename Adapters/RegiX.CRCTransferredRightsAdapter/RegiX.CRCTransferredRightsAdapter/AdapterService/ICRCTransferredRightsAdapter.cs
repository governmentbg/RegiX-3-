using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.CRCTransferredRightsAdapter.AdapterService
{
	[ServiceContract]
	[Description("Адаптер „Прехвърлени права“")]
	public interface ICRCTransferredRightsAdapter : IAdapterServiceWCF
	{
		[OperationContract]
		[Description("Справка за отдаден под наем ИООР")]
		CommonSignedResponse<GetRentedIOORInfoRequest, GetRentedIOORInfoResponseType> GetRentedIOORInfo(GetRentedIOORInfoRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters);

		[OperationContract]
		[Description("Справка за прехвърлени права")]
		CommonSignedResponse<GetTransferredRightsRequest, GetTransferredRightsInfoResponseType> GetTransferredRightsInfo(GetTransferredRightsRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters);
	}
}