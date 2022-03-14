using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Adapters.Common.Attributes;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.CRCNotificationsAdapter.APIService
{
	[ServiceContract]
	[XmlSerializerFormat]
	[Description("API на Адаптер за уведомления")]
	public interface ICRCNotificationsAPI : IAPIService
	{
		[OperationContract]
		[Description("Справка за предприятие")]
		[Info(
			requestXSD: "GetCompanyInfoRequest.xsd",
			responseXSD: "GetCompanyInfoResponse.xsd",
			requestXSLT: "CRCNoXslt.xslt",
			responseXSLT: "CRCNoXslt.xslt",
			commonXSD: "CRCNotificationsCommon.xsd")]
		ServiceResultDataSigned<GetCompanyInfoRequest, GetCompanyInfoResponseType> GetCompanyInfo(ServiceRequestData<GetCompanyInfoRequest> argument);

		[OperationContract]
		[Description("Справка по мрежа/услуга")]
		[Info(
			requestXSD: "GetNetworksAndServicesInfoRequest.xsd",
			responseXSD: "GetNetworksAndServicesInfoResponse.xsd",
			requestXSLT: "CRCNoXslt.xslt",
			responseXSLT: "CRCNoXslt.xslt",
			commonXSD: "CRCNotificationsCommon.xsd")]
		ServiceResultDataSigned<GetNetworksAndServicesInfoRequest, GetNetworksAndServicesInfoResponseType> GetNetworksAndServicesInfo(ServiceRequestData<GetNetworksAndServicesInfoRequest> argument);
	}
}