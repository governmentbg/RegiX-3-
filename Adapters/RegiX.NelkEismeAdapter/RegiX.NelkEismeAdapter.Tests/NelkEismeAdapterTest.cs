using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnoLogica.RegiX.NelkEismeAdapter.AdapterService;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.Common.ObjectMapping;
using System;

namespace TechnoLogica.RegiX.NelkEismeAdapter.Tests
{
    [TestClass]
    public class NelkEismeAdapterTest : AdapterTest<AdapterService.NelkEismeAdapter, INelkEismeAdapter>
    {
        //private string _mockupAddressGetErAll = "http://regix2-adapters.regix.tlogica.com:8078/RegiX.NELKServiceMockupGetErAll/CheckServiceImplementation.svc";
        //private string _mockupAddressGetEr = "http://regix2-adapters.regix.tlogica.com:8078/RegiX.NELKServiceMockupGetEr/CheckServiceImplementation.svc";
        //private string _mockupAddressListErPeriod = "http://regix2-adapters.regix.tlogica.com:8078/RegiX.NELKServiceMockupListErPeriod/CheckServiceImplementation.svc";

        ////private string _mockupAddressGetErAll = "http://194.12.245.241/NelkServices/CheckService";
        ////private string _mockupAddressGetEr = "http://194.12.245.241/NelkServices/CheckService";
        ////private string _mockupAddressListErPeriod = "http://194.12.245.241/NelkServices/CheckService";


        //public TechnoLogica.RegiX.Common.TransportObject.CallContext GetCallContext()
        //{
        //    return new TechnoLogica.RegiX.Common.TransportObject.CallContext()
        //    {
        //        AdministrationOId = "1.0.0.0.0.22.2.2",
        //        LawReason = "�������� �� RegiX",
        //        ServiceURI = "1222-200030-12.12.2022",
        //        Remark = "���������",
        //        EmployeeAditionalIdentifier = "����� ����� 3",
        //        EmployeeIdentifier = "test@tesactivedirectory.com",
        //        EmployeeNames = "������ ���������� ����������",
        //        AdministrationName = "��������� ������� �� ��������",
        //        EmployeePosition = "������ ������� ����� \"�������� �� ������������\"",
        //        ResponsiblePersonIdentifier = "392309324",
        //        ServiceType = "�� ������������ �������"
        //    };
        //}

        //public AdapterAdditionalParameters GetAdditionalParams()
        //{
        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext() { Remark = "RegiXTest" };// "\"LawReason\":\"�������� �� RegiX\",\"ServiceURI\":\"123456789\",�ServiceType�:��� ������������ �������\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"������������ �� ����������� � �������\",� UserAdministrationID�:�10.20.503.4�,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";
        //    additionalParameters.SignResult = true;
        //    additionalParameters.ReturnAccessMatrix = true;
        //    return additionalParameters;
        //}
        //[TestMethod]
        //public void NelkEismeAdapterTest_GetAllExpertDecisionsByIdentifier_1_Test()
        //{

        //    TechnoLogica.RegiX.Common.TransportObject.CallContext context = GetCallContext();
        //    AdapterAdditionalParameters additionalParameters = GetAdditionalParams();

        //    NelkEismeAdapter adapter = new NelkEismeAdapter();
        //    adapter.SetParameter("WebServiceUrl", _mockupAddressGetErAll);
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(ExpertDecisionsResponse));
        //    GetAllExpertDecisionsByIdentifierRequest searchCriteria = new GetAllExpertDecisionsByIdentifierRequest()
        //    {
        //        Identifier = "6211106327"
        //    };

        //    var result = adapter.GetAllExpertDecisionsByIdentifier(searchCriteria, accessMatrix, additionalParameters);
        //    string xml = result.XmlSerialize(); 
        //    using (StreamWriter outfile = new StreamWriter("GetAllExpertDecisionsByIdentifier_1_Test.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(xml);
        //    }
        //}

        //[TestMethod]
        //public void NelkEismeAdapterTest_GetAllExpertDecisionsByIdentifier_2_Test()
        //{

        //    TechnoLogica.RegiX.Common.TransportObject.CallContext context = GetCallContext();
        //    AdapterAdditionalParameters additionalParameters = GetAdditionalParams();

        //    NelkEismeAdapter adapter = new NelkEismeAdapter();
        //    adapter.SetParameter("WebServiceUrl", _mockupAddressGetErAll);

        //    var accessMatrix = AccessMatrix.CreateForType(typeof(ExpertDecisionsResponse));
        //    GetAllExpertDecisionsByIdentifierRequest searchCriteria = new GetAllExpertDecisionsByIdentifierRequest()
        //    {
        //        Identifier = "1234567890"
        //    };

        //    var result = adapter.GetAllExpertDecisionsByIdentifier(searchCriteria, accessMatrix, additionalParameters);
        //    string xml = result.XmlSerialize(); 
        //    using (StreamWriter outfile = new StreamWriter("GetAllExpertDecisionsByIdentifier_2_Test.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(xml);
        //    }
        //}

        //[TestMethod]
        //public void NelkEismeAdapterTest_GetLastExpertDecisionsByIdentifier_1_Test()
        //{

        //    TechnoLogica.RegiX.Common.TransportObject.CallContext context = GetCallContext();
        //    AdapterAdditionalParameters additionalParameters = GetAdditionalParams();

        //    NelkEismeAdapter adapter = new NelkEismeAdapter();
        //    adapter.SetParameter("WebServiceUrl", _mockupAddressGetEr);

        //    var accessMatrix = AccessMatrix.CreateForType(typeof(ExpertDecisionsResponse));
        //    GetLastExpertDecisionByIdentifierRequest searchCriteria = new GetLastExpertDecisionByIdentifierRequest()
        //    {
        //        Identifier = "6211106327"
        //    };

        //    var result = adapter.GetLastExpertDecisionByIdentifier(searchCriteria, accessMatrix, additionalParameters);
        //    string xml = result.XmlSerialize(); 
        //    using (StreamWriter outfile = new StreamWriter("GetLastExpertDecisionByIdentifier_1_Test.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(xml);
        //    }
        //}

        //[TestMethod]
        //public void NelkEismeAdapterTest_GetLastExpertDecisionsByIdentifier_2_Test()
        //{

        //    TechnoLogica.RegiX.Common.TransportObject.CallContext context = GetCallContext();
        //    AdapterAdditionalParameters additionalParameters = GetAdditionalParams();

        //    NelkEismeAdapter adapter = new NelkEismeAdapter();
        //    adapter.SetParameter("WebServiceUrl", _mockupAddressGetEr);

        //    var accessMatrix = AccessMatrix.CreateForType(typeof(ExpertDecisionsResponse));
        //    GetLastExpertDecisionByIdentifierRequest searchCriteria = new GetLastExpertDecisionByIdentifierRequest()
        //    {
        //        Identifier = "1234567890"
        //    };

        //    var result = adapter.GetLastExpertDecisionByIdentifier(searchCriteria, accessMatrix, additionalParameters);
        //    string xml = result.XmlSerialize(); 
        //    using (StreamWriter outfile = new StreamWriter("GetLastExpertDecisionByIdentifier_2_Test.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(xml);
        //    }
        //}

        //[TestMethod]
        //public void NelkEismeAdapterTest_GetAllExpertDecisionsByPeriod_1_Test()
        //{

        //    TechnoLogica.RegiX.Common.TransportObject.CallContext context = GetCallContext();
        //    AdapterAdditionalParameters additionalParameters = GetAdditionalParams();

        //    NelkEismeAdapter adapter = new NelkEismeAdapter();
        //    adapter.SetParameter("WebServiceUrl", _mockupAddressListErPeriod );

        //    var accessMatrix = AccessMatrix.CreateForType(typeof(ExpertDesisionShortInfoForPeriodList));
        //    GetAllExpertDecisionsByPeriodRequest searchCriteria = new GetAllExpertDecisionsByPeriodRequest()
        //    {
        //        DateFrom = DateTime.Now.AddDays(-28),
        //        DateTo = DateTime.Now
        //    };

        //    var result = adapter.GetAllExpertDecisionsByPeriod(searchCriteria, accessMatrix, additionalParameters);
        //    string xml = result.XmlSerialize();
        //    using (StreamWriter outfile = new StreamWriter("GetAllExpertDecisionsByPeriod_1_Test.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(xml);
        //    }
        //}



        // �������� �� ������� � ������ ����� �� ��������� �������� ���� �� mapper.AddObjectMap
        //[TestMethod]
        public void MapperTest()
        {
            var am = AccessMatrix.LoadFromDictionary(new System.Collections.Generic.Dictionary<string, bool>() {
                {"ExpertDecisionDocument", true},
                {"ExpertDecisionDocument.AdditionalData", true},
                {"ExpertDecisionDocument.AdditionalData.EmployeeType", false},
                {"ExpertDecisionDocument.AdditionalData.ReasonForTermination", false},
                {"ExpertDecisionDocument.AdditionalData.Status", false},
                {"ExpertDecisionDocument.Appeal", true},
                {"ExpertDecisionDocument.Appeal.Condition", false},
                {"ExpertDecisionDocument.Appeal.Decision", false},
                {"ExpertDecisionDocument.Appeal.DecisionCode", false},
                {"ExpertDecisionDocument.Appeal.Institution", false},
                {"ExpertDecisionDocument.Appeal.InstitutionCode", false},
                {"ExpertDecisionDocument.Appeal.RegistrationDate", false},
                {"ExpertDecisionDocument.Appeal.RegistrationNumber", false},
                {"ExpertDecisionDocument.Appeal.Stakeholders", false},
                {"ExpertDecisionDocument.Appeal.StakeholdersCode", false},
                {"ExpertDecisionDocument.AppealedHospitalSheets", false},
                {"ExpertDecisionDocument.ArgumentsAndObservations", false},
                {"ExpertDecisionDocument.CommisionMember", false},
                {"ExpertDecisionDocument.CommisionMember.Name", false},
                {"ExpertDecisionDocument.CommisionMember.Position", false},
                {"ExpertDecisionDocument.CommissionCode", false},
                {"ExpertDecisionDocument.CommissionDescr", false},
                {"ExpertDecisionDocument.ConditionCode", false},
                {"ExpertDecisionDocument.ConditionText", false},
                {"ExpertDecisionDocument.ContradictionWorkingConditions", false},
                {"ExpertDecisionDocument.Diagnosis", false},
                {"ExpertDecisionDocument.DiagnosisCode", false},
                {"ExpertDecisionDocument.DisabilityReason", true},
                {"ExpertDecisionDocument.DisabilityReason.Date", false},
                {"ExpertDecisionDocument.DisabilityReason.Percent", true},
                {"ExpertDecisionDocument.DisabilityReason.Type", false},
                {"ExpertDecisionDocument.DurationDisability", true},
                {"ExpertDecisionDocument.DurationDisabilityCode", false},
                {"ExpertDecisionDocument.DurationDisabilityDate", true},
                {"ExpertDecisionDocument.DurationForeignAid", true},
                {"ExpertDecisionDocument.EmployabilityAssessment", false},
                {"ExpertDecisionDocument.EmployabilityAssessmentCode", false},
                {"ExpertDecisionDocument.Employment", false},
                {"ExpertDecisionDocument.EmploymentCode", false},
                {"ExpertDecisionDocument.ExpertiseDecisionMaking", false},
                {"ExpertDecisionDocument.ExpertiseDecisionMakingCode", false},
                {"ExpertDecisionDocument.ExpertisePlace", false},
                {"ExpertDecisionDocument.ExpertisePlaceCode", false},
                {"ExpertDecisionDocument.ExpertiseType", false},
                {"ExpertDecisionDocument.ExpertiseTypeCode", false},
                {"ExpertDecisionDocument.GeneralIllness", false},
                {"ExpertDecisionDocument.GeneralIllnessCode", false},
                {"ExpertDecisionDocument.IdentityDocument", true},
                {"ExpertDecisionDocument.IdentityDocument.DocumentNumber", false},
                {"ExpertDecisionDocument.IdentityDocument.IssueDate", false},
                {"ExpertDecisionDocument.IdentityDocument.IssuePlace", false},
                {"ExpertDecisionDocument.IdentityDocument.ValidDate", false},
                {"ExpertDecisionDocument.InitiateDocument", true},
                {"ExpertDecisionDocument.InitiateDocument.Annotation", false},
                {"ExpertDecisionDocument.InitiateDocument.DocumentType", false},
                {"ExpertDecisionDocument.InitiateDocument.RegistrationDate", false},
                {"ExpertDecisionDocument.InitiateDocument.RegistrationNumber", false},
                {"ExpertDecisionDocument.MeetingNumber", false},
                {"ExpertDecisionDocument.MilitaryDisability", false},
                {"ExpertDecisionDocument.MilitaryDisabilityCode", false},
                {"ExpertDecisionDocument.Parent", true},
                {"ExpertDecisionDocument.Parent.EGN", false},
                {"ExpertDecisionDocument.Parent.IdentityDocument", true},
                {"ExpertDecisionDocument.Parent.IdentityDocument.DocumentNumber", false},
                {"ExpertDecisionDocument.Parent.IdentityDocument.IssueDate", false},
                {"ExpertDecisionDocument.Parent.IdentityDocument.IssuePlace", false},
                {"ExpertDecisionDocument.Parent.IdentityDocument.ValidDate", false},
                {"ExpertDecisionDocument.Parent.LNCh", false},
                {"ExpertDecisionDocument.Parent.PermanentAddress", false},
                {"ExpertDecisionDocument.Parent.PersonNames", false},
                {"ExpertDecisionDocument.Parent.TemporaryAddress", false},
                {"ExpertDecisionDocument.PermanentAddress", true},
                {"ExpertDecisionDocument.PermanentAddress.AddressDescription", false},
                {"ExpertDecisionDocument.PermanentAddress.DistrictEKATTE", false},
                {"ExpertDecisionDocument.PermanentAddress.MunicipalityEKATTE", false},
                {"ExpertDecisionDocument.PermanentAddress.SettlementEKATTE", false},
                {"ExpertDecisionDocument.PersonIdentifier", true},
                {"ExpertDecisionDocument.PersonNames", true},
                {"ExpertDecisionDocument.Profession", false},
                {"ExpertDecisionDocument.ReceiptDate", false},
                {"ExpertDecisionDocument.RecommendationsForChild", false},
                {"ExpertDecisionDocument.RegistrationDate", true},
                {"ExpertDecisionDocument.RegistrationNumber", true},
                {"ExpertDecisionDocument.TemporaryAddress", true},
                {"ExpertDecisionDocument.TemporaryAddress.AddressDescription", false},
                {"ExpertDecisionDocument.TemporaryAddress.DistrictEKATTE", false},
                {"ExpertDecisionDocument.TemporaryAddress.MunicipalityEKATTE", false},
                {"ExpertDecisionDocument.TemporaryAddress.SettlementEKATTE", false},
                {"ExpertDecisionDocument.WorkAccident", false},
                {"ExpertDecisionDocument.WorkAccidentCode", false},
                {"ExpertDecisionDocument.WorkDisease", false},
                {"ExpertDecisionDocument.WorkDiseaseCode", false},
            });

            var mapper = TechnoLogica.RegiX.NelkEismeAdapter.AdapterService.NelkEismeAdapter.CreateExpertDecisionsResponseMapper(am);
        }



        /*
         *
        SELECT TOP 1000 [ID]
      ,[CONSUMER_CERTIFICATE_ID]
	  ,REGISTER_OBJECTS.name
	  ,REGISTER_OBJECTS.REGISTER_OBJECT_ID
      ,REGISTER_OBJECT_ELEMENTS.NAME
      ,REGISTER_OBJECT_ELEMENTS.PATH_TO_ROOT
      ,[HAS_ACCESS]
        FROM REGISTER_OBJECTS
  join REGISTER_OBJECT_ELEMENTS on REGISTER_OBJECT_ELEMENTS.REGISTER_OBJECT_ID = REGISTER_OBJECTS.REGISTER_OBJECT_ID
 left join[regix2].[dbo].[CERTIFICATE_ELEMENT_ACCESS] on[CERTIFICATE_ELEMENT_ACCESS].REGISTER_OBJECT_ELEMENT_ID = REGISTER_OBJECT_ELEMENTS.REGISTER_OBJECT_ELEMENT_ID
  where CONSUMER_CERTIFICATE_ID = 40272
    and REGISTER_OBJECTS.REGISTER_OBJECT_ID = 736
order by REGISTER_OBJECT_ELEMENTS.PATH_TO_ROOT
      */
        // �� �������� �� ������ - �� �������� �� ������� ������ mapper.AddObjectMap �� ��� ������
        // �� ������ ��������.
        //[TestMethod]
        //[ExpectedException(typeof(NullReferenceException))]
        public void MapperTestIssue()
        {
            var am = AccessMatrix.LoadFromDictionary(new System.Collections.Generic.Dictionary<string, bool>() {

        {"ExpertDecisionDocument", true},
        {"ExpertDecisionDocument.AdditionalData", false},
        { "ExpertDecisionDocument.AdditionalData.EmployeeType", false},
        { "ExpertDecisionDocument.AdditionalData.ReasonForTermination", false},
        { "ExpertDecisionDocument.AdditionalData.Status", false},
        { "ExpertDecisionDocument.Appeal", false},
        { "ExpertDecisionDocument.Appeal.Condition", false},
        { "ExpertDecisionDocument.Appeal.Decision", false},
        { "ExpertDecisionDocument.Appeal.DecisionCode", false},
        { "ExpertDecisionDocument.Appeal.Institution", false},
        { "ExpertDecisionDocument.Appeal.InstitutionCode", false},
        { "ExpertDecisionDocument.Appeal.RegistrationDate", false},
        { "ExpertDecisionDocument.Appeal.RegistrationNumber", false},
        { "ExpertDecisionDocument.Appeal.Stakeholders", false},
        { "ExpertDecisionDocument.Appeal.StakeholdersCode", false},
        { "ExpertDecisionDocument.AppealedHospitalSheets", false},
        { "ExpertDecisionDocument.ArgumentsAndObservations", false},
        { "ExpertDecisionDocument.CommisionMember", false},
        { "ExpertDecisionDocument.CommisionMember.Name", false},
        { "ExpertDecisionDocument.CommisionMember.Position", false},
        { "ExpertDecisionDocument.CommissionCode", false},
        { "ExpertDecisionDocument.CommissionDescr", false},
        { "ExpertDecisionDocument.ConditionCode", false},
        { "ExpertDecisionDocument.ConditionText", false},
        { "ExpertDecisionDocument.ContradictionWorkingConditions", false},
        { "ExpertDecisionDocument.Diagnosis", false},
        { "ExpertDecisionDocument.DiagnosisCode", false},
        { "ExpertDecisionDocument.DisabilityReason", true},
        { "ExpertDecisionDocument.DisabilityReason.Date", false},
        { "ExpertDecisionDocument.DisabilityReason.Percent", true},
        { "ExpertDecisionDocument.DisabilityReason.Type", false},
        { "ExpertDecisionDocument.DurationDisability", true},
        { "ExpertDecisionDocument.DurationDisabilityCode", false},
        { "ExpertDecisionDocument.DurationDisabilityDate", true},
        { "ExpertDecisionDocument.DurationForeignAid", true},
        { "ExpertDecisionDocument.EmployabilityAssessment", false},
        { "ExpertDecisionDocument.EmployabilityAssessmentCode", false},
        { "ExpertDecisionDocument.Employment", false},
        { "ExpertDecisionDocument.EmploymentCode", false},
        { "ExpertDecisionDocument.ExpertiseDecisionMaking", false},
        { "ExpertDecisionDocument.ExpertiseDecisionMakingCode", false},
        { "ExpertDecisionDocument.ExpertisePlace", false},
        { "ExpertDecisionDocument.ExpertisePlaceCode", false},
        { "ExpertDecisionDocument.ExpertiseType", false},
        { "ExpertDecisionDocument.ExpertiseTypeCode", false},
        { "ExpertDecisionDocument.GeneralIllness", false},
        { "ExpertDecisionDocument.GeneralIllnessCode", false},
        { "ExpertDecisionDocument.IdentityDocument", true},
        { "ExpertDecisionDocument.IdentityDocument.DocumentNumber", false},
        { "ExpertDecisionDocument.IdentityDocument.IssueDate", false},
        { "ExpertDecisionDocument.IdentityDocument.IssuePlace", false},
        { "ExpertDecisionDocument.IdentityDocument.ValidDate", false},
        { "ExpertDecisionDocument.InitiateDocument", false},
        { "ExpertDecisionDocument.InitiateDocument.Annotation", false},
        { "ExpertDecisionDocument.InitiateDocument.DocumentType", false},
        { "ExpertDecisionDocument.InitiateDocument.RegistrationDate", false},
        { "ExpertDecisionDocument.InitiateDocument.RegistrationNumber", false},
        { "ExpertDecisionDocument.MeetingNumber", false},
        { "ExpertDecisionDocument.MilitaryDisability", false},
        { "ExpertDecisionDocument.MilitaryDisabilityCode", false},
        { "ExpertDecisionDocument.Parent", false},
        { "ExpertDecisionDocument.Parent.EGN", false},
        { "ExpertDecisionDocument.Parent.IdentityDocument", false},
        { "ExpertDecisionDocument.Parent.IdentityDocument.DocumentNumber", false},
        { "ExpertDecisionDocument.Parent.IdentityDocument.IssueDate", false},
        { "ExpertDecisionDocument.Parent.IdentityDocument.IssuePlace", false},
        { "ExpertDecisionDocument.Parent.IdentityDocument.ValidDate", false},
        { "ExpertDecisionDocument.Parent.LNCh", false},
        { "ExpertDecisionDocument.Parent.PermanentAddress", false},
        { "ExpertDecisionDocument.Parent.PersonNames", false},
        { "ExpertDecisionDocument.Parent.TemporaryAddress", false},
        { "ExpertDecisionDocument.PermanentAddress", false},
        { "ExpertDecisionDocument.PermanentAddress.AddressDescription", false},
        { "ExpertDecisionDocument.PermanentAddress.DistrictEKATTE", false},
        { "ExpertDecisionDocument.PermanentAddress.MunicipalityEKATTE", false},
        { "ExpertDecisionDocument.PermanentAddress.SettlementEKATTE", false},
        { "ExpertDecisionDocument.PersonIdentifier", true},
        { "ExpertDecisionDocument.PersonNames", true},
        { "ExpertDecisionDocument.Profession", false},
        { "ExpertDecisionDocument.ReceiptDate", false},
        { "ExpertDecisionDocument.RecommendationsForChild", false},
        { "ExpertDecisionDocument.RegistrationDate", true},
        { "ExpertDecisionDocument.RegistrationNumber", true},
        { "ExpertDecisionDocument.TemporaryAddress", false},
        { "ExpertDecisionDocument.TemporaryAddress.AddressDescription", false},
        { "ExpertDecisionDocument.TemporaryAddress.DistrictEKATTE", false},
        { "ExpertDecisionDocument.TemporaryAddress.MunicipalityEKATTE", false},
        { "ExpertDecisionDocument.TemporaryAddress.SettlementEKATTE", false},
        { "ExpertDecisionDocument.WorkAccident", false},
        { "ExpertDecisionDocument.WorkAccidentCode", false},
        { "ExpertDecisionDocument.WorkDisease", false},
        { "ExpertDecisionDocument.WorkDiseaseCode", false},
            });

            var mapper = TechnoLogica.RegiX.NelkEismeAdapter.AdapterService.NelkEismeAdapter.CreateExpertDecisionsResponseMapper(am);
        }

    }
}


