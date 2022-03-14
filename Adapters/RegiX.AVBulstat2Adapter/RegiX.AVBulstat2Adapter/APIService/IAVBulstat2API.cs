using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Adapters.Common.Attributes;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using AdapterServiceReference = TechnoLogica.RegiX.AVBulstat2Adapter.AVBulstat2ServiceReference;

namespace TechnoLogica.RegiX.AVBulstat2Adapter.APIService
{
    [ServiceContract]
    [XmlSerializerFormat]
    [Description("API на Адаптер за комуникация с Агенция по вписванията - Национален Регистър БУЛСТАТ")]
    public interface IAVBulstat2API : IAPIService
    {
        //Справка по код на БУЛСТАТ или по фирмено дело за актуално състояние на субект на БУЛСТАТ

        [OperationContract]
        [Description("Справка по код на БУЛСТАТ или по фирмено дело за актуално състояние на субект на БУЛСТАТ")]
        [Info(
            requestXSD: "GetStateOfPlayRequest.xsd",
            responseXSD: "StateOfPlay.xsd",
            commonXSD: "NomenclatureEntry.xsd;LegalEntity.xsd;NaturalPerson.xsd;Event.xsd;Subject.xsd;SubjectPropLifeTime.xsd;SubjectPropState.xsd;SubjectPropScopeOfActivity.xsd;SubjectPropActivityKID2008.xsd;SubjectPropActivityKID2003.xsd;SubjectPropInstallments.xsd;SubjectPropRepresentationType.xsd;SubjectPropFundingSource.xsd;SubjectPropOwnershipForm.xsd;SubjectPropAccountingRecordForm.xsd;SubjectPropActivityDate.xsd;SubjectPropProfession.xsd;SubjectRelPartner.xsd;SubjectRelManager.xsd;SubjectRelBelonging.xsd;SubjectRelAssignee.xsd;SubjectPropCollectiveBody.xsd;Entry.xsd;IdentificationDoc.xsd;Document.xsd;Case.xsd;UIC.xsd;Communication.xsd;Address.xsd;SubscriptionElement.xsd;SubjectRelCollectiveBodyMember.xsd;MetaDefinition.xsd",
            sampleRequest: "StateOfPlayRequest.xml",
            sampleResponse: "StateOfPlayResponse.xml",
            metaDataXML: "GetStateOfPlayRequest.xml",
            requestXSLT: "GetStateOfPlayRequest.xslt",
            responseXSLT: "GetStateOfPlayResponse.xslt")]
        ServiceResultDataSigned<AdapterServiceReference.GetStateOfPlayRequest, AdapterServiceReference.StateOfPlay> GetStateOfPlay(ServiceRequestData<AdapterServiceReference.GetStateOfPlayRequest> argument);

        //Извличане на актуалното състояние на номенклатурите, с които Регистърът оперира

        [OperationContract]
        [Description("Справка за номенклатурите на регистър БУЛСТАТ")]
        [Info(
            requestXSD: "NomenclaturesRequest.xsd",
            responseXSD: "Nomenclatures.xsd",
            commonXSD: "NomenclatureEntry.xsd;LegalEntity.xsd;NaturalPerson.xsd;Event.xsd;Subject.xsd;SubjectPropLifeTime.xsd;SubjectPropState.xsd;SubjectPropScopeOfActivity.xsd;SubjectPropActivityKID2008.xsd;SubjectPropActivityKID2003.xsd;SubjectPropInstallments.xsd;SubjectPropRepresentationType.xsd;SubjectPropFundingSource.xsd;SubjectPropOwnershipForm.xsd;SubjectPropAccountingRecordForm.xsd;SubjectPropActivityDate.xsd;SubjectPropProfession.xsd;SubjectRelPartner.xsd;SubjectRelManager.xsd;SubjectRelBelonging.xsd;SubjectRelAssignee.xsd;SubjectPropCollectiveBody.xsd;Entry.xsd;IdentificationDoc.xsd;Document.xsd;Case.xsd;UIC.xsd;Communication.xsd;Address.xsd;SubscriptionElement.xsd;SubjectRelCollectiveBodyMember.xsd;MetaDefinition.xsd;StateOfPlay.xsd;GetStateOfPlayRequest.xsd",
            sampleRequest: "FetchNomenclaturesRequest.xml",
            sampleResponse: "FetchNomenclaturesResponse.xml",
            metaDataXML: "FetchNomenclatures.xml",
            requestXSLT: "FetchNomenclaturesRequest.xslt",
            responseXSLT: "FetchNomenclaturesResponse.xslt")]
        ServiceResultDataSigned<XMLSchemas.FetchNomenclatures, AdapterServiceReference.Nomenclatures> FetchNomenclatures(ServiceRequestData<XMLSchemas.FetchNomenclatures> argument);

        [OperationContract]
        [Description("Справка за извличане на актуален УИК")]
        [Info(
          requestXSD: "GetActualUICInfoRequest.xsd",
          responseXSD: "GetActualUICInfoResponse.xsd",
          requestXSLT: "GetActualUICInfoRequest.xslt",
          responseXSLT: "GetActualUICInfoResponse.xslt")]
        ServiceResultDataSigned<XMLSchemas.GetActualUICInfoRequestType, XMLSchemas.GetActualUICInfoResponseType> GetActualUICInfo(ServiceRequestData<XMLSchemas.GetActualUICInfoRequestType> argument);

    }
}
