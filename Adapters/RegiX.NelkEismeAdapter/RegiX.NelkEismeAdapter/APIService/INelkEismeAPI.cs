using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Adapters.Common.Attributes;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.NelkEismeAdapter.XMLSchemas;

namespace TechnoLogica.RegiX.NelkEismeAdapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("Единна информационна система на медицинската експертиза (ЕИСМЕ)")]
    public interface INelkEismeAPI : IAPIService
    {
        //Справка за всички експертни решения на лице
        [OperationContract]
        [Description("Справка за всички експертни решения на лице")]
        [Info(
            requestXSD: "NELKCommon.xsd",
            responseXSD: "NELKCommon.xsd",
            requestXSLT: "GetAllExpertDecisionsByIdentifierRequest.xslt",
            responseXSLT: "GetAllExpertDecisionsByIdentifierResponse.xslt")]
        ServiceResultDataSigned<GetAllExpertDecisionsByIdentifierRequest, ExpertDecisionsResponse> GetAllExpertDecisionsByIdentifier(ServiceRequestData<GetAllExpertDecisionsByIdentifierRequest> argument);

        //Справка за последното експертно решение на лице
        [OperationContract]
        [Description("Справка за последното експертно решение на лице")]
        [Info(
            requestXSD: "NELKCommon.xsd",
            responseXSD: "NELKCommon.xsd",
            requestXSLT: "GetLastExpertDecisionByIdentifierRequest.xslt",
            responseXSLT: "GetLastExpertDecisionByIdentifierResponse.xslt")]
        ServiceResultDataSigned<GetLastExpertDecisionByIdentifierRequest, ExpertDecisionsResponse> GetLastExpertDecisionByIdentifier(ServiceRequestData<GetLastExpertDecisionByIdentifierRequest> argument);

        //Справка за всички експертни решения, издадени за период
        [OperationContract]
        [Description("Справка за всички експертни решения, издадени за период")]
        [Info(
            requestXSD: "NELKCommon.xsd",
            responseXSD: "NELKCommon.xsd",
            requestXSLT: "GetAllExpertDecisionsByPeriodRequest.xslt",
            responseXSLT: "GetAllExpertDecisionsByPeriodResponse.xslt")]
        ServiceResultDataSigned<GetAllExpertDecisionsByPeriodRequest, ExpertDesisionShortInfoForPeriodList> GetAllExpertDecisionsByPeriod(ServiceRequestData<GetAllExpertDecisionsByPeriodRequest> argument);
    }
}
