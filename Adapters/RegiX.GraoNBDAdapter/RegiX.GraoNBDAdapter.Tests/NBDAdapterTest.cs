using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegiX.Adapters.FileParameterStore;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.Utils;
using TechnoLogica.RegiX.GraoNBDAdapter;
using TechnoLogica.RegiX.GraoNBDAdapter.AdapterService;

namespace TechnoLogica.RegiX.GraoNBDAdapter.Tests
{
    [TestClass]
    public class NBDAdapterTest : AdapterTest<NBDAdapter, INBDAdapter>
    {
        //[TestMethod]
        //public void GraoNBDValidPersonTest()
        //{
        //    NBDAdapter gr = new NBDAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(ValidPersonResponseType));
        //    ValidPersonRequestType searchParams = new ValidPersonRequestType { EGN = "8506258485" };

        //    var result = gr.ValidPersonSearch(searchParams, accessMatrix, GetCallContext());

        //    //using (StreamWriter outfile = new StreamWriter("ValidPerson.xml", false, System.Text.Encoding.UTF8))
        //    //{
        //    //    outfile.Write(result.XmlSerialize());
        //    //}
        //    ////XmlWrite(res, "MaritalStatus.xml", "XMLSchemas/MaritalStatusResponse.xsd", "http://egov.bg/RegiX/GRAO/BR/MaritalStatusResponse");

        //    //XsltUtils.RunXsltAndWriteHtml("GraoNBDAdapter", "ValidPersonRequest", result.Data.Request.XmlSerialize());
        //    //XsltUtils.RunXsltAndWriteHtml("GraoNBDAdapter", "ValidPersonResponse", result.Data.Response.XmlSerialize());
        //    //Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void GraoNBDPersonDataTest()
        //{
        //    NBDAdapter gr = new NBDAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(PersonDataResponseType));
        //    PersonDataRequestType searchParams = new PersonDataRequestType { EGN = "8506258485" };

        //    var result = gr.PersonDataSearch(searchParams, accessMatrix, new AdapterAdditionalParameters());

        //    using (StreamWriter outfile = new StreamWriter("PersonData.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }
        //    //XmlWrite(res, "MaritalStatus.xml", "XMLSchemas/MaritalStatusResponse.xsd", "http://egov.bg/RegiX/GRAO/BR/MaritalStatusResponse");

        //    XsltUtils.RunXsltAndWriteHtml("GraoNBDAdapter", "PersonDataRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("GraoNBDAdapter", "PersonDataResponse", result.Data.Response.XmlSerialize());
        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void GraoNBDRelationsTest()
        //{
        //    NBDAdapter gr = new NBDAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(RelationsResponseType));
        //    RelationsRequestType searchParams = new RelationsRequestType { EGN = "8506258485" };
        //    var result = gr.RelationsSearch(searchParams, accessMatrix, new AdapterAdditionalParameters());
        //    using (StreamWriter outfile = new StreamWriter("Relations.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }
        //    //XmlWrite(res, "MaritalStatus.xml", "XMLSchemas/MaritalStatusResponse.xsd", "http://egov.bg/RegiX/GRAO/BR/MaritalStatusResponse");
        //    XsltUtils.RunXsltAndWriteHtml("GraoNBDAdapter", "RelationsRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("GraoNBDAdapter", "RelationsResponse", result.Data.Response.XmlSerialize());
        //    Assert.IsTrue(true);
        //}


        private AdapterAdditionalParameters GetCallContext()
        {
           CallContext context = new CallContext()
            {
                AdministrationOId = "https://trust-party-openid.com",
                LawReason = "�������� �� RegiX",
                ServiceURI = "1222-200030-12.12.2022",
                Remark = "���������",
                EmployeeAditionalIdentifier = "����� ����� 3",
                EmployeeIdentifier = "test@tesactivedirectory.com",
                EmployeeNames = "������ ���������� ����������",
                AdministrationName = "��������� ������� �� ��������",
                EmployeePosition = "������ ������� ����� \"�������� �� ������������\"",
                ResponsiblePersonIdentifier = "392309324",
                ServiceType = "�� ������������ �������"
            };
            string oldcontext = context.ToString();

            AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
            string remark = "������: \"����������� �� ������ �� ������������ � �������� � �����\"; ���: \"101-26828-14.09.2016\"; ������: \"������ �� ������� �� ���� \"�������� �� ��������������� �� ���������� �� �������� (�����������)\"\"; ��������� ���������: ��������� �������� �������� ���: 6810291752";

            additionalParameters.CallContext = new CallContext() { Remark = remark };
            additionalParameters.CitizenEGN = "8888888888";
            additionalParameters.ClientIPAddress = "111.111.111.111";
            additionalParameters.ConsumerCertificateThumbprint = "###";
            additionalParameters.EIDToken = "token123";
            additionalParameters.EmployeeEGN = "11111111111111";
            additionalParameters.OrganizationEIK = "2.16.100.1.1.17.1.1";
            additionalParameters.OrganizationUnit = "qqqqqq";
            additionalParameters.SignResult = true;
            additionalParameters.ReturnAccessMatrix = false;

            return additionalParameters;
        }
    }
}
