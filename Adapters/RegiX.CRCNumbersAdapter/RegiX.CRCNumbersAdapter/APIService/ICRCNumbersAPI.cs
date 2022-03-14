using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Adapters.Common.Attributes;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.CRCNumbersAdapter.APIService
{
	[ServiceContract]
	[XmlSerializerFormat]
	[Description("API на Адаптер „Предоставени номерационни ресурси“")]
	public interface ICRCNumbersAPI : IAPIService
	{
		[OperationContract]
		[Description("Справка за номера")]
		[Info(
			requestXSD: "GetNumbersInfoRequest.xsd",
			responseXSD: "GetNumbersInfoResponse.xsd",
			requestXSLT: "CRCNoXslt.xslt",
			responseXSLT: "CRCNoXslt.xslt")]
		ServiceResultDataSigned<GetNumbersInfoRequest, GetNumbersInfoResponseType> GetNumbersInfo(ServiceRequestData<GetNumbersInfoRequest> argument);
	}
}