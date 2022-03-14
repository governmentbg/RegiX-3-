using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.XmlDiffPatch;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.AVBulstat2Adapter.AdapterService;
using TechnoLogica.RegiX.AVBulstat2Adapter.AVBulstat2ServiceReference;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.Utils;

namespace TechnoLogica.RegiX.AVBulstat2Adapter.Tests
{
    [TestClass]
    public class AVBulstat2AdapterTests : AdapterTest<AdapterService.AVBulstat2Adapter, IAVBulstat2Adapter>
    {
        ////[TestMethod]
        ////public void AVBulstat2Adapter_CheckHealthCheckAndParamtersTest()
        ////{
        ////    AVBulstat2Adapter adapter = new AVBulstat2Adapter();
        ////    //test GetParameters , and ConnectionString
        ////    var connectionString = adapter.GetParameters().ParameterList.Where(p => p.Key == TechnoLogica.RegiX.Common.Constants.WebServiceUrlParameterKeyName).FirstOrDefault();
        ////    //test SetParameter
        ////    adapter.SetParameter(TechnoLogica.RegiX.Common.Constants.WebServiceUrlParameterKeyName, connectionString.CurrentValue);
        ////    //test HCfunctions
        ////    var hcFunctions = adapter.GetHealthCheckFunctions();
        ////    string checkHealthFunctionResult = string.Empty;
        ////    hcFunctions.HealthInfosList.ForEach(f =>
        ////    {
        ////        checkHealthFunctionResult = checkHealthFunctionResult + f.Key + ":" + adapter.CheckHealthFunction(f.Key) + ";\r\n";
        ////    });
        ////    using (StreamWriter outfile = new StreamWriter("CheckHealthFunctions.xml", false, System.Text.Encoding.UTF8))
        ////    {
        ////        outfile.Write(checkHealthFunctionResult);
        ////    }
        ////    Assert.IsTrue(true);
        ////}

        ////[TestMethod]
        ////public void AVBulstat2Adapter_CheckRegisterConnection()
        ////{
        ////    AVBulstat2Adapter adapter = new AVBulstat2Adapter();
        ////    string result = adapter.CheckRegisterConnection();
        ////    Assert.IsTrue(result == TechnoLogica.RegiX.Common.Constants.ConnectionOk || result == TechnoLogica.RegiX.Common.Constants.ConnectionStringNotSet);
        ////}

        ///// <summary>
        ///// Проверява дали адаптера връща грешка.
        ///// При успех - записва получения response в bin папката
        ///// </summary>
        //[TestMethod]
        //public void AVBulstat2Adapter_GetStateOfPlayHasError()
        //{
        //    AdapterService.AVBulstat2Adapter adapter = new AdapterService.AVBulstat2Adapter();

        //    var request = new GetStateOfPlayRequest();
        //    //request.GetStateOfPlayRequest = new GetStateOfPlayRequest();
        //    request.UIC = "1212120908";

        //    var result =
        //        adapter.GetStateOfPlay(request,
        //            AccessMatrix.CreateForType(typeof(StateOfPlay)),
        //            new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
        //            {
        //                CallContext = new CallContext() { Remark = "RegiXTest" },
        //                ClientIPAddress = "172.12.33.56",
        //                EmployeeEGN = "1212124563",
        //                OrganizationUnit = "ТехноЛогика"
        //            }
        //        );

        //    using (StreamWriter outfile = new StreamWriter("StateOfPlay.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    //XsltUtils.RunXsltAndWriteHtml("AVBulstatAdapter", "ValidBulstatRequest", result.Data.Request.XmlSerialize());
        //    //XsltUtils.RunXsltAndWriteHtml("AVBulstatAdapter", "ValidBulstatResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void AVBulstat2Adapter_StateOfPlay_1212120908()
        //{
        //    AVBulstat2Adapter_GetStateOfPlayCheckResult("1212120908");
        //}

        //[TestMethod]
        //public void AVBulstat2Adapter_StateOfPlay_nulls()
        //{
        //    AVBulstat2Adapter_GetStateOfPlayCheckResult("test_nulls");
        //}

        //[TestMethod]
        //public void AVBulstat2Adapter_StateOfPlay_121858220()
        //{
        //    AVBulstat2Adapter_GetStateOfPlayCheckResult("121858220");
        //}


        //[TestMethod]
        //public void AVBulstat2Adapter_StateOfPlay_5103120893()
        //{
        //    AVBulstat2Adapter_GetStateOfPlayCheckResult("5103120893");
        //}
        //[TestMethod]
        //public void AVBulstat2Adapter_StateOfPlay_1212120909()
        //{
        //    AVBulstat2Adapter_GetStateOfPlayCheckResult("1212120909");
        //}
        //[TestMethod]
        //public void AVBulstat2Adapter_StateOfPlay_default()
        //{
        //    AVBulstat2Adapter_GetStateOfPlayCheckResult("default");
        //}
        //[TestMethod]
        //public void AVBulstat2Adapter_StateOfPlay_1234567890()
        //{
        //    AVBulstat2Adapter_GetStateOfPlayCheckResult("1234567890");
        //}

        //[TestMethod]
        //public void AVBulstat2Adapter_StateOfPlay_empty()
        //{
        //    AVBulstat2Adapter_GetStateOfPlayCheckResult("empty", checkForEmpty: true);
        //}

        //[TestMethod]
        //public void AVBulstat2Adapter_StateOfPlay_aaaaaaaaaa()
        //{
        //    AVBulstat2Adapter_GetStateOfPlayCheckResult("aaaaaaaaaa");
        //}

        //[TestMethod]
        //public void AVBulstat2Adapter_StateOfPlay_5555555555()
        //{
        //    AVBulstat2Adapter_GetStateOfPlayCheckResult("5555555555");
        //}

        ///// <summary>
        ///// Проверка дали получения Response съвпада с xml-a, който mock услугата връща. 
        ///// За да мине теста трябва в папката XmlTemplates да е сложен същия xml, както xml-a, който mock услугата прочита и подава на адаптера
        ///// При успех - записва получения response в bin папката
        ///// </summary>
        //public void AVBulstat2Adapter_GetStateOfPlayCheckResult(string testUIC, bool checkForEmpty = false)
        //{
        //    AdapterService.AVBulstat2Adapter adapter = new AdapterService.AVBulstat2Adapter();

        //    var request = new GetStateOfPlayRequest();
        //    request.UIC = testUIC;
        //    request.Case = new GetStateOfPlayRequestCase();
        //    request.Case.Court = new NomenclatureEntry();
        //    request.Case.Court.Code = "6";
        //    request.Case.Number = "1";
        //    request.Case.Year = 1;

        //    var result =
        //        adapter.GetStateOfPlay(request,
        //            AccessMatrix.CreateForType(typeof(StateOfPlay)),
        //            new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
        //            {
        //                CallContext = new CallContext() { Remark = "RegiXTest" },
        //                ClientIPAddress = "172.12.33.56",
        //                EmployeeEGN = "1212124563",
        //                OrganizationUnit = "ТехноЛогика"
        //            }
        //        );

        //    using (StreamWriter outfile = new StreamWriter("StateOfPlay_" + testUIC + ".xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.Data.Request.XmlSerialize());
        //    }



        //    //  XsltUtils.RunXsltAndWriteHtml("AVBulstat2Adapter", "GetStateOfPlayRequest", result.Data.Request.XmlSerialize());
        //    //  XsltUtils.RunXsltAndWriteHtml("AVBulstat2Adapter", "GetStateOfPlayResponse", result.Data.Response.XmlSerialize());

        //    if (checkForEmpty)
        //    {
        //        string adapterResponseXmlString = result.Data.Response.XmlSerialize();

        //        using (StreamWriter outfile = new StreamWriter("StateOfPlayResponse_" + testUIC + ".xml", false, System.Text.Encoding.UTF8))
        //        {
        //            outfile.Write(adapterResponseXmlString);
        //        }
        //        XmlDocument xmlDoc = new XmlDocument();
        //        xmlDoc.LoadXml(adapterResponseXmlString);
        //        Assert.IsFalse(xmlDoc.FirstChild.HasChildNodes);
        //    }
        //    else
        //    {
        //        string adapterResponseXmlString = result.Data.Response.XmlSerialize();

        //        using (StreamWriter outfile = new StreamWriter("StateOfPlayResponse_" + testUIC + ".xml", false, System.Text.Encoding.UTF8))
        //        {
        //            outfile.Write(adapterResponseXmlString);
        //        }

        //        bool identical = GetStateOfPlay_CheckResult(adapterResponseXmlString, testUIC + ".xml");
        //        //bool identical = CompareXmlFiles("<a><b>Vesi</b><c><d /></c></a>", "<a><b>Vesi</b></a>");

        //        if (identical)
        //            Assert.IsTrue(true);
        //        else
        //            Assert.IsTrue(false);
        //    }
        //}


        ///// <summary>
        ///// Проверява дали адаптера връща грешка.
        ///// При успех - записва получения response в bin папката
        ///// </summary>
        //[TestMethod]
        //public void AVBulstat2Adapter_FetchNomenclaturesHasError()
        //{
        //    AdapterService.AVBulstat2Adapter adapter = new AdapterService.AVBulstat2Adapter();

        //    var request = new TechnoLogica.RegiX.AVBulstat2Adapter.XMLSchemas.FetchNomenclatures();

        //    var result =
        //        adapter.FetchNomenclatures(request,
        //            AccessMatrix.CreateForType(typeof(Nomenclatures)),
        //            new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
        //            {
        //                CallContext = new CallContext() { Remark = "RegiXTest" },
        //                ClientIPAddress = "172.12.33.56",
        //                EmployeeEGN = "1212124563",
        //                OrganizationUnit = "ТехноЛогика"
        //            }
        //        );

        //    using (StreamWriter outfile = new StreamWriter("FetchNomenclaturesHasError.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    //XsltUtils.RunXsltAndWriteHtml("AVBulstatAdapter", "ValidBulstatRequest", result.Data.Request.XmlSerialize());
        //    //XsltUtils.RunXsltAndWriteHtml("AVBulstatAdapter", "ValidBulstatResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}


        ///// <summary>
        ///// Проверка дали получения Response съвпада с xml-a, който mock услугата връща. 
        ///// За да мине теста трябва в папката XmlTemplates да е сложен същия xml, както xml-a, който mock услугата прочита и подава на адаптера
        ///// При успех - записва получения response в bin папката
        ///// </summary>
        //[TestMethod]
        //public void AVBulstat2Adapter_FetchNomenclaturesCheckResult()
        //{
        //    AdapterService.AVBulstat2Adapter adapter = new AdapterService.AVBulstat2Adapter();
        //    //adapter.SetParameter("WebServiceUrl", "http://localhost:57219/AVBulstat2ServiceImplServiceInterface.svc");
        //    var request = new XMLSchemas.FetchNomenclatures();

        //    var result =
        //        adapter.FetchNomenclatures(request,
        //            AccessMatrix.CreateForType(typeof(Nomenclatures)),
        //            new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
        //            {
        //                CallContext = new CallContext() { Remark = "RegiXTest" },
        //                ClientIPAddress = "172.12.33.56",
        //                EmployeeEGN = "1212124563",
        //                OrganizationUnit = "ТехноЛогика"
        //            }
        //        );


        //    string adapterResponseXmlString = result.Data.Response.XmlSerialize();
        //    using (StreamWriter outfile = new StreamWriter("FetchNomenclaturesResponse.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(adapterResponseXmlString);
        //    }

        //    string adapterRequestXmlString = result.Data.Request.XmlSerialize();
        //    using (StreamWriter outfile = new StreamWriter("FetchNomenclaturesRequest.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(adapterRequestXmlString);
        //    }

        //    bool identical = FetchNomenclatures_CheckResult(adapterResponseXmlString, "FetchNomenclatures.xml");

        //    if (identical)
        //        Assert.IsTrue(true);
        //    else
        //        Assert.IsTrue(false);

        //    Assert.IsTrue(true);
        //}

        //private bool GetStateOfPlay_CheckResult(string adapterResponseXmlString, string templateXmlFileName)
        //{
        //    string templateXmlFileLocation = "XmlTemplates\\GetStateOfPlay\\" + templateXmlFileName;
        //    string sourceXml = XsltUtils.ReadFileContent(templateXmlFileLocation);

        //    bool identical = CompareXmlFiles(sourceXml, adapterResponseXmlString);

        //    return identical;
        //}

        //private bool FetchNomenclatures_CheckResult(string adapterResponseXmlString, string templateXmlFileName)
        //{
        //    string templateXmlFileLocation = "XmlTemplates\\FetchNomenclatures\\" + templateXmlFileName;
        //    string sourceXml = XsltUtils.ReadFileContent(templateXmlFileLocation);

        //    bool identical = CompareXmlFiles(sourceXml, adapterResponseXmlString);

        //    return identical;
        //}

        ///// <summary>
        ///// Сравнява два xml-a за идентичност на съдържанието. За сравнението се използва библиотеката XmlDiff.
        ///// </summary>
        ///// <param name="sourceXml"></param>
        ///// <param name="adapterResponseXml"></param>
        ///// <returns></returns>
        //private bool CompareXmlFiles(string sourceXml, string adapterResponseXml)
        //{
        //    XmlDocument xmlDocFirst = new XmlDocument();
        //    XmlDocument xmlDocSecond = new XmlDocument();
        //    xmlDocFirst.LoadXml(RemoveAllNamespaces(sourceXml));
        //    xmlDocSecond.LoadXml(RemoveAllNamespaces(PrepareAdapterResponseXmlForComparison(adapterResponseXml)));
        //    xmlDocSecond.LoadXml(RemoveAllNamespaces(adapterResponseXml));

        //    XmlDiff xmldiff = new XmlDiff(
        //                            //XmlDiffOptions.IgnoreChildOrder |
        //                            XmlDiffOptions.IgnoreNamespaces |
        //                            XmlDiffOptions.IgnorePrefixes |
        //                            XmlDiffOptions.IgnoreComments |
        //                            XmlDiffOptions.IgnoreXmlDecl |
        //                            //XmlDiffOptions.IgnorePI |
        //                            XmlDiffOptions.IgnoreWhitespace);

        //    XmlTextWriter writer = new XmlTextWriter("diff.xml", Encoding.UTF8);

        //    bool areIdentical = xmldiff.Compare(xmlDocFirst, xmlDocSecond, writer);
        //    writer.Close();

        //    return areIdentical;
        //}

        //public static string RemoveAllNamespaces(string xmlDocument)
        //{
        //    XElement xmlDocumentWithoutNs = stripNS(XElement.Parse(xmlDocument));

        //    return xmlDocumentWithoutNs.ToString();
        //}

        //static XElement stripNS(XElement root)
        //{
        //    return new XElement(
        //        root.Name.LocalName,
        //        root.HasElements ?
        //            root.Elements().Select(el => stripNS(el)) :
        //            (object)root.Value
        //    );
        //}

        ///// <summary>
        ///// Обработваме получения xml, така че да премахнем празните елементи, включително parent nodes, които съдържат само празни nodes.
        ///// Това се налага заради специфичното поведение на ObjectMapper-a, който на null property от source-a съпоставя празен обект от destination-a.
        ///// </summary>
        ///// <param name="adapterResponseXml"></param>
        ///// <returns></returns>
        //private string PrepareAdapterResponseXmlForComparison(string adapterResponseXml)
        //{
        //    XDocument firstDoc = XDocument.Parse(adapterResponseXml);

        //    //Обхождаме всички Nodes, от най-вътрешните към най-външните (see Reverse) и ако текущия node е празен го изтриваме
        //    foreach (var child in firstDoc.Descendants().Reverse())
        //    {
        //        if (!child.HasElements && string.IsNullOrEmpty(child.Value))
        //            child.Remove();
        //    }

        //    string preparedXmlString = firstDoc.Declaration + firstDoc.ToString();

        //    return preparedXmlString;
        //}
    }
}
