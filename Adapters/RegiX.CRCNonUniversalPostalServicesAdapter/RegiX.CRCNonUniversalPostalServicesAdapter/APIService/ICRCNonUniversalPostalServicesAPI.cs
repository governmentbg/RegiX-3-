using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Adapters.Common.Attributes;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.CRCNonUniversalPostalServicesAdapter.APIService
{
	[ServiceContract]
	[XmlSerializerFormat]
	[Description("API на Адаптер „Неуниверсални пощенски услуги“")]
	public interface ICRCNonUniversalPostalServicesAPI : IAPIService
	{
		[OperationContract]
		[Description("Справка за неуниверсални оператори")]
		[Info(
			requestXSD: "GetNonUniversalOperatorsInfoRequest.xsd",
			responseXSD: "GetNonUniversalOperatorsInfoResponse.xsd",
			requestXSLT: "CRCNoXslt.xslt",
			responseXSLT: "CRCNoXslt.xslt")]
		ServiceResultDataSigned<GetNonUniversalOperatorsInfoRequest, GetNonUniversalOperatorsInfoResponseType> GetNonUniversalOperatorsInfo(ServiceRequestData<GetNonUniversalOperatorsInfoRequest> argument);
	}
}