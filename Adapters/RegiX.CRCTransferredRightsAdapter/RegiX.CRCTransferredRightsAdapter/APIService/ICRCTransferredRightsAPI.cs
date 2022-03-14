using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Adapters.Common.Attributes;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.CRCTransferredRightsAdapter.APIService
{
	[ServiceContract]
	[XmlSerializerFormat]
	[Description("API на Адаптер за прехвърлени права")]
	public interface ICRCTransferredRightsAPI : IAPIService
	{
		[OperationContract]
		[Description("Справка за отдаден под наем ИООР")]
		[Info(
			requestXSD: "GetRentedIOORInfoRequest.xsd",
			responseXSD: "GetRentedIOORInfoResponse.xsd", 
			requestXSLT: "CRCNoXslt.xslt",
			responseXSLT: "CRCNoXslt.xslt",
			commonXSD: "TransferredRightsCommon.xsd")]
		ServiceResultDataSigned<GetRentedIOORInfoRequest, GetRentedIOORInfoResponseType> GetRentedIOORInfo(ServiceRequestData<GetRentedIOORInfoRequest> argument);

		[OperationContract]
		[Description("Справка за прехвърлени права")]
		[Info(
			requestXSD: "GetTransferredRightsInfoRequest.xsd",
			responseXSD: "GetTransferredRightsInfoResponse.xsd",
			requestXSLT: "CRCNoXslt.xslt",
			responseXSLT: "CRCNoXslt.xslt",
			commonXSD: "TransferredRightsCommon.xsd")]
		ServiceResultDataSigned<GetTransferredRightsRequest, GetTransferredRightsInfoResponseType> GetTransferredRightsInfo(ServiceRequestData<GetTransferredRightsRequest> argument);
	}
}