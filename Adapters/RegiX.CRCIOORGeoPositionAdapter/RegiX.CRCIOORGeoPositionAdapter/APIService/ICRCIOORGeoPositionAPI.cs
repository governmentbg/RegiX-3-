using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Adapters.Common.Attributes;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.CRCIOORGeoPositionAdapter.APIService
{
	[ServiceContract]
	[XmlSerializerFormat]
	[Description("API на Адаптер „Позиция на геостационарна орбита“")]
	public interface ICRCIOORGeoPositionAPI : IAPIService
	{
		[OperationContract]
		[Description("Справка за предприятие")]
		[Info(
			requestXSD: "GetCompanyInfoRequest.xsd",
			responseXSD: "GetCompanyInfoResponse.xsd",
			requestXSLT: "CRCNoXslt.xslt",
			responseXSLT: "CRCNoXslt.xslt"
			)]
		ServiceResultDataSigned<GetCompanyInfoRequest, GetCompanyInfoResponseType> GetCompanyInfo(ServiceRequestData<GetCompanyInfoRequest> argument);
	}
}