using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Adapters.Common.Attributes;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.CRCPostalServicesAdapter.APIService
{
	[ServiceContract]
	[XmlSerializerFormat]
	[Description("API на Адаптер „Универсални пощенски услуги“")]
	public interface ICRCPostalServicesAPI : IAPIService
	{
		[OperationContract]
		[Description("Справка за универсални оператори")]
		[Info(
			requestXSD: "GetUniversalOperatorsInfoRequest.xsd",
			responseXSD: "GetUniversalOperatorsInfoResponse.xsd",
			requestXSLT: "CRCNoXslt.xslt",
			responseXSLT: "CRCNoXslt.xslt")]
		ServiceResultDataSigned<GetUniversalOperatorsInfoRequest, GetUniversalOperatorsInfoResponseType> GetUniversalOperatorsInfo(ServiceRequestData<GetUniversalOperatorsInfoRequest> argument);
	}
}