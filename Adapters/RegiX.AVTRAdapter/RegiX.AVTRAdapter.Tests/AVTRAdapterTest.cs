using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnoLogica.RegiX.AVTRAdapter.AdapterService;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.AVTRAdapter.ActualStateV2;
using TechnoLogica.RegiX.AVTRAdapter.ActualStateV3;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.Utils;

namespace TechnoLogica.RegiX.AVTRAdapter.Tests
{
    [TestClass]
    public class AVTRAdapterTest : AdapterTest<TRAdapter, ITRAdapter>
    {
        //[TestMethod]
        //public void AVTRAdapterTest_CheckHealthCheckAndParamtersTest()
        //{
        //    TRAdapter adapter = new TRAdapter();
        //    //test GetParameters , and ConnectionString
        //    var connectionString = adapter.GetParameters().ParameterList.Where(p => p.Key == TechnoLogica.RegiX.Common.Constants.ConnectionStringParameterKeyName).FirstOrDefault();
        //    //test SetParameter
        //    adapter.SetParameter(TechnoLogica.RegiX.Common.Constants.ConnectionStringParameterKeyName, connectionString.CurrentValue);
        //    //test HCfunctions
        //    var hcFunctions = adapter.GetHealthCheckFunctions();
        //    hcFunctions.HealthInfosList.ForEach(f => adapter.CheckHealthFunction(f.Key));
        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void AVTRAdapterTest_CheckRegisterConnection()
        //{
        //    TRAdapter adapter = new TRAdapter();
        //    string result = adapter.CheckRegisterConnection();
        //    Assert.IsTrue(result == Common.Constants.ConnectionOk || result == Common.Constants.ConnectionStringNotSet);
        //}

        //[TestMethod]
        //public void AVTRAdapterTestSearchParticipation_Ogi()
        //{
        //    TRAdapter adapter = new TRAdapter();
        //    var result =
        //        adapter.PersonInCompaniesSearch(
        //            new SearchParticipationInCompaniesRequestType() { EGN = "6408036387" },
        //            AccessMatrix.CreateForType(typeof(SearchParticipationInCompaniesResponseType)),
        //            new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
        //            {
        //                CallContext = new CallContext() { Remark = "RegiXTestTest" },
        //                ClientIPAddress = "172.12.33.56",
        //                EmployeeEGN = "1212124563",
        //                OrganizationUnit = "ТехноЛогика"
        //            }
        //        );
        //    using (StreamWriter outfile = new StreamWriter("SearchParticipationInCompanies_Ogi.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_SearchParticipationInCompaniesRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_SearchParticipationInCompaniesResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void AVTRAdapterTestSearchParticipation_NotFound()
        //{
        //    TRAdapter adapter = new TRAdapter();
        //    var result =
        //        adapter.PersonInCompaniesSearch(
        //            new SearchParticipationInCompaniesRequestType() { EGN = "X" },
        //            AccessMatrix.CreateForType(typeof(SearchParticipationInCompaniesResponseType)),
        //            new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
        //            {
        //                CallContext = new CallContext() { Remark = "RegiXTest" },
        //                ClientIPAddress = "172.12.33.56",
        //                EmployeeEGN = "1212124563",
        //                OrganizationUnit = "ТехноЛогика"
        //            }
        //        );
        //    using (StreamWriter outfile = new StreamWriter("SearchParticipationInCompanies_NotFound.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_SearchParticipationInCompaniesRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_SearchParticipationInCompaniesResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void AVTRAdapterTestSearchParticipation_Jon()
        //{
        //    TRAdapter adapter = new TRAdapter();
        //    var result =
        //        adapter.PersonInCompaniesSearch(
        //            new SearchParticipationInCompaniesRequestType() { EGN = "7108206925" },
        //            AccessMatrix.CreateForType(typeof(SearchParticipationInCompaniesResponseType)),
        //            new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
        //            {
        //                CallContext = new CallContext() { Remark = "RegiXTest" },
        //                ClientIPAddress = "172.12.33.56",
        //                EmployeeEGN = "1212124563",
        //                OrganizationUnit = "ТехноЛогика"
        //            }
        //        );
        //    using (StreamWriter outfile = new StreamWriter("SearchParticipationInCompanies_Jon.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_SearchParticipationInCompaniesRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_SearchParticipationInCompaniesResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}


        //[TestMethod]
        //public void AVTRAdapterTestValidUIC_TL()
        //{
        //    TRAdapter adapter = new TRAdapter();
        //    var result =
        //        adapter.GetValidUICInfo(
        //            new ValidUICRequestType() { UIC = "201593301" },
        //            AccessMatrix.CreateForType(typeof(ValidUICResponseType)),
        //            new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
        //            {
        //                CallContext = new CallContext() { Remark = "RegiXTestTest" },
        //                ClientIPAddress = "172.12.33.56",
        //                EmployeeEGN = "1212124563",
        //                OrganizationUnit = "ТехноЛогика"
        //            }
        //        );
        //    using (StreamWriter outfile = new StreamWriter("ValidUIC_TL.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ValidUICRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ValidUICResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void AVTRAdapterTestValidUIC_ET()
        //{
        //    TRAdapter adapter = new TRAdapter();
        //    var result =
        //        adapter.GetValidUICInfo(
        //            new ValidUICRequestType() { UIC = "201593302" },
        //            AccessMatrix.CreateForType(typeof(ValidUICResponseType)),
        //            new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
        //            {
        //                CallContext = new CallContext() { Remark = "RegiXTestTest" },
        //                ClientIPAddress = "172.12.33.56",
        //                EmployeeEGN = "1212124563",
        //                OrganizationUnit = "ТехноЛогика"
        //            }
        //        );
        //    using (StreamWriter outfile = new StreamWriter("ValidUIC_ET.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ValidUICRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ValidUICResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void AVTRAdapterTestValidUIC_SD()
        //{
        //    TRAdapter adapter = new TRAdapter();
        //    var result =
        //        adapter.GetValidUICInfo(
        //            new ValidUICRequestType() { UIC = "201593303" },
        //            AccessMatrix.CreateForType(typeof(ValidUICResponseType)),
        //            new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
        //            {
        //                CallContext = new CallContext() { Remark = "RegiXTestTest" },
        //                ClientIPAddress = "172.12.33.56",
        //                EmployeeEGN = "1212124563",
        //                OrganizationUnit = "ТехноЛогика"
        //            }
        //        );
        //    using (StreamWriter outfile = new StreamWriter("ValidUIC_SD.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ValidUICRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ValidUICResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}
        //[TestMethod]
        //public void AVTRAdapterTestValidUIC_KD()
        //{
        //    TRAdapter adapter = new TRAdapter();
        //    var result =
        //        adapter.GetValidUICInfo(
        //            new ValidUICRequestType() { UIC = "201593304" },
        //            AccessMatrix.CreateForType(typeof(ValidUICResponseType)),
        //            new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
        //            {
        //                CallContext = new CallContext() { Remark = "RegiXTestTest" },
        //                ClientIPAddress = "172.12.33.56",
        //                EmployeeEGN = "1212124563",
        //                OrganizationUnit = "ТехноЛогика"
        //            }
        //        );
        //    using (StreamWriter outfile = new StreamWriter("ValidUIC_KD.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ValidUICRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ValidUICResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void AVTRAdapterTestValidUIC_AD()
        //{
        //    TRAdapter adapter = new TRAdapter();
        //    var result =
        //        adapter.GetValidUICInfo(
        //            new ValidUICRequestType() { UIC = "201593306" },
        //            AccessMatrix.CreateForType(typeof(ValidUICResponseType)),
        //            new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
        //            {
        //                CallContext = new CallContext() { Remark = "RegiXTestTest" },
        //                ClientIPAddress = "172.12.33.56",
        //                EmployeeEGN = "1212124563",
        //                OrganizationUnit = "ТехноЛогика"
        //            }
        //        );
        //    using (StreamWriter outfile = new StreamWriter("ValidUIC_AD.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ValidUICRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ValidUICResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void AVTRAdapterTestValidUIC_NotFound()
        //{
        //    TRAdapter adapter = new TRAdapter();
        //    var result =
        //        adapter.GetValidUICInfo(
        //            new ValidUICRequestType() { UIC = "X" },
        //            AccessMatrix.CreateForType(typeof(ValidUICResponseType)),
        //            new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
        //            {
        //                CallContext = new CallContext() { Remark = "RegiXTestTest" },
        //                ClientIPAddress = "172.12.33.56",
        //                EmployeeEGN = "1212124563",
        //                OrganizationUnit = "ТехноЛогика"
        //            }
        //        );
        //    using (StreamWriter outfile = new StreamWriter("ValidUIC_NotFound.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ValidUICRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ValidUICResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void AVTRAdapterTestActualStateV2TL()
        //{
        //    //System.Reflection.PropertyInfo[] p = typeof(SubDeedType).GetProperties();
        //    //string res = string.Empty;
        //    //foreach(var prop in p)
        //    //{
        //    //    string descr = prop.CustomAttributes.Where(t => t.AttributeType.Name == "DescriptionAttribute").FirstOrDefault().ConstructorArguments.FirstOrDefault().Value.ToString();
        //    //    descr = descr.Substring(descr.IndexOf(':') + 1);
        //    //    if (descr.IndexOf('-') > 0)
        //    //    {
        //    //        descr = descr.Substring(0, descr.IndexOf('-')-1);
        //    //    }

        //    //    res += "{\"" + descr + "\",\"" +  prop.Name + "\"},\n";


        //    //}
        //    ///////////////////////////
        //    TRAdapter adapter = new TRAdapter();
        //    var result =
        //        adapter.GetActualStateV2(
        //            new ActualStateRequestV2() { UIC = "201593302", FieldList = "00010, 00020,00030  , ,     00040  ,00050,00060 ,00051 " },
        //            AccessMatrix.CreateForType(typeof(ActualStateResponseV2_AM)),
        //            new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
        //            {
        //                CallContext = new CallContext() { Remark = "RegiXTestTest" },
        //                ClientIPAddress = "172.12.33.56",
        //                EmployeeEGN = "1212124563",
        //                OrganizationUnit = "ТехноЛогика"
        //            }
        //        );
        //    using (StreamWriter outfile = new StreamWriter("ActualStateV2TL.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ActualStateRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ActualStateResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void AVTRAdapterTestActualStateV2TL_2()
        //{
        //    TRAdapter adapter = new TRAdapter();
        //    var result =
        //        adapter.GetActualStateV2(
        //            new ActualStateRequestV2() { UIC = "201593302", FieldList = "" },
        //            AccessMatrix.CreateForType(typeof(ActualStateResponseV2_AM)),
        //            new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
        //            {
        //                CallContext = new CallContext() { Remark = "RegiXTestTest" },
        //                ClientIPAddress = "172.12.33.56",
        //                EmployeeEGN = "1212124563",
        //                OrganizationUnit = "ТехноЛогика"
        //            }
        //        );
        //    using (StreamWriter outfile = new StreamWriter("ActualStateV2TL_2.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void AVTRAdapterTestActualStateV2TL_3()
        //{
        //    TRAdapter adapter = new TRAdapter();
        //    var result =
        //        adapter.GetActualStateV2(
        //            new ActualStateRequestV2() { UIC = "201593303", FieldList = "" },
        //            AccessMatrix.CreateForType(typeof(ActualStateResponseV2_AM)),
        //            new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
        //            {
        //                CallContext = new CallContext() { Remark = "RegiXTestTest" },
        //                ClientIPAddress = "172.12.33.56",
        //                EmployeeEGN = "1212124563",
        //                OrganizationUnit = "ТехноЛогика"
        //            }
        //        );
        //    using (StreamWriter outfile = new StreamWriter("ActualStateV2TL_3.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    Assert.IsTrue(true);
        //}


        //[TestMethod]
        //public void AVTRAdapterTestActualStateV2TL_4()
        //{
        //    TRAdapter adapter = new TRAdapter();
        //    var result =
        //        adapter.GetActualStateV2(
        //            new ActualStateRequestV2() { UIC = "201593304", FieldList = "" },
        //            AccessMatrix.CreateForType(typeof(ActualStateResponseV2_AM)),
        //            new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
        //            {
        //                CallContext = new CallContext() { Remark = "RegiXTestTest" },
        //                ClientIPAddress = "172.12.33.56",
        //                EmployeeEGN = "1212124563",
        //                OrganizationUnit = "ТехноЛогика"
        //            }
        //        );
        //    using (StreamWriter outfile = new StreamWriter("ActualStateV2TL_4.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void AVTRAdapterTestActualStateV2TL_5()
        //{
        //    TRAdapter adapter = new TRAdapter();
        //    var result =
        //        adapter.GetActualStateV2(
        //            new ActualStateRequestV2() { UIC = "201593305", FieldList = "" },
        //            AccessMatrix.CreateForType(typeof(ActualStateResponseV2_AM)),
        //            new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
        //            {
        //                CallContext = new CallContext() { Remark = "RegiXTestTest" },
        //                ClientIPAddress = "172.12.33.56",
        //                EmployeeEGN = "1212124563",
        //                OrganizationUnit = "ТехноЛогика"
        //            }
        //        );
        //    using (StreamWriter outfile = new StreamWriter("ActualStateV2TL_5.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void AVTRAdapterTestActualStateV2TL_6()
        //{
        //    TRAdapter adapter = new TRAdapter();
        //    var result =
        //        adapter.GetActualStateV2(
        //            new ActualStateRequestV2() { UIC = "201593306", FieldList = "" },
        //            AccessMatrix.CreateForType(typeof(ActualStateResponseV2_AM)),
        //            new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
        //            {
        //                CallContext = new CallContext() { Remark = "RegiXTestTest" },
        //                ClientIPAddress = "172.12.33.56",
        //                EmployeeEGN = "1212124563",
        //                OrganizationUnit = "ТехноЛогика"
        //            }
        //        );
        //    using (StreamWriter outfile = new StreamWriter("ActualStateV2TL_6.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void AVTRAdapterTestActualStateV2TL_NotFound()
        //{
        //    TRAdapter adapter = new TRAdapter();
        //    var result =
        //        adapter.GetActualStateV2(
        //            new ActualStateRequestV2() { UIC = "X", FieldList = "" },
        //            AccessMatrix.CreateForType(typeof(ActualStateResponseV2_AM)),
        //            new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
        //            {
        //                CallContext = new CallContext() { Remark = "RegiXTestTest" },
        //                ClientIPAddress = "172.12.33.56",
        //                EmployeeEGN = "1212124563",
        //                OrganizationUnit = "ТехноЛогика"
        //            }
        //        );
        //    using (StreamWriter outfile = new StreamWriter("ActualStateV2TL_NotFound.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    Assert.IsTrue(true);
        //}
        //[TestMethod]
        //public void AVTRAdapterTestActualStateTL()
        //{
        //    TRAdapter adapter = new TRAdapter();
        //    var result =
        //        adapter.GetActualState(
        //            new ActualStateRequestType() { UIC = "201593301" },
        //            AccessMatrix.CreateForType(typeof(ActualStateResponseType)),
        //            new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
        //            {
        //                CallContext = new CallContext() { Remark = "RegiXTestTest" },
        //                ClientIPAddress = "172.12.33.56",
        //                EmployeeEGN = "1212124563",
        //                OrganizationUnit = "ТехноЛогика"
        //            }
        //        );
        //    using (StreamWriter outfile = new StreamWriter("ActualStateTL.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ActualStateRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ActualStateResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}
        //[TestMethod]
        //public void AVTRAdapterTestActualStateET()
        //{
        //    TRAdapter adapter = new TRAdapter();
        //    var result =
        //        adapter.GetActualState(
        //            new ActualStateRequestType() { UIC = "201593302" },
        //            AccessMatrix.CreateForType(typeof(ActualStateResponseType)),
        //            new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
        //            {
        //                CallContext = new CallContext() { Remark = "RegiXTestTest" },
        //                ClientIPAddress = "172.12.33.56",
        //                EmployeeEGN = "1212124563",
        //                OrganizationUnit = "ТехноЛогика"
        //            }
        //        );
        //    using (StreamWriter outfile = new StreamWriter("ActualStateET.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ActualStateRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ActualStateResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void AVTRAdapterTestActualStateSD()
        //{
        //    TRAdapter adapter = new TRAdapter();
        //    var result =
        //        adapter.GetActualState(
        //            new ActualStateRequestType() { UIC = "201593303" },
        //            AccessMatrix.CreateForType(typeof(ActualStateResponseType)),
        //            new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
        //            {
        //                CallContext = new CallContext() { Remark = "RegiXTestTest" },
        //                ClientIPAddress = "172.12.33.56",
        //                EmployeeEGN = "1212124563",
        //                OrganizationUnit = "ТехноЛогика"
        //            }
        //        );
        //    using (StreamWriter outfile = new StreamWriter("ActualStateSD.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ActualStateRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ActualStateResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void AVTRAdapterTestActualStateKD()
        //{
        //    TRAdapter adapter = new TRAdapter();
        //    var result =
        //        adapter.GetActualState(
        //            new ActualStateRequestType() { UIC = "201593304" },
        //            AccessMatrix.CreateForType(typeof(ActualStateResponseType)),
        //            new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
        //            {
        //                CallContext = new CallContext() { Remark = "RegiXTestTest" },
        //                ClientIPAddress = "172.12.33.56",
        //                EmployeeEGN = "1212124563",
        //                OrganizationUnit = "ТехноЛогика"
        //            }
        //        );
        //    using (StreamWriter outfile = new StreamWriter("ActualStateKD.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ActualStateRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ActualStateResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void AVTRAdapterTestActualStateOOD()
        //{
        //    TRAdapter adapter = new TRAdapter();
        //    var result =
        //        adapter.GetActualState(
        //            new ActualStateRequestType() { UIC = "201593305" },
        //            AccessMatrix.CreateForType(typeof(ActualStateResponseType)),
        //            new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
        //            {
        //                CallContext = new CallContext() { Remark = "RegiXTestTest" },
        //                ClientIPAddress = "172.12.33.56",
        //                EmployeeEGN = "1212124563",
        //                OrganizationUnit = "ТехноЛогика"
        //            }
        //        );
        //    using (StreamWriter outfile = new StreamWriter("ActualStateOOD.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ActualStateRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ActualStateResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void AVTRAdapterTestActualStateAD()
        //{
        //    TRAdapter adapter = new TRAdapter();
        //    var result =
        //        adapter.GetActualState(
        //            new ActualStateRequestType() { UIC = "201593306" },
        //            AccessMatrix.CreateForType(typeof(ActualStateResponseType)),
        //            new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
        //            {
        //                CallContext = new CallContext() { Remark = "RegiXTestTest" },
        //                ClientIPAddress = "172.12.33.56",
        //                EmployeeEGN = "1212124563",
        //                OrganizationUnit = "ТехноЛогика"
        //            }
        //        );
        //    using (StreamWriter outfile = new StreamWriter("ActualStateAd.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ActualStateRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ActualStateResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void AVTRAdapterTestActualStateNORecords()
        //{
        //    TRAdapter adapter = new TRAdapter();
        //    var result =
        //        adapter.GetActualState(
        //            new ActualStateRequestType() { UIC = "201593307" },
        //            AccessMatrix.CreateForType(typeof(ActualStateResponseType)),
        //            new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
        //            {
        //                CallContext = new CallContext() { Remark = "RegiXTestTest" },
        //                ClientIPAddress = "172.12.33.56",
        //                EmployeeEGN = "1212124563",
        //                OrganizationUnit = "ТехноЛогика"
        //            }
        //        );
        //    using (StreamWriter outfile = new StreamWriter("ActualStateNoRecords.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ActualStateRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ActualStateResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}


        //[TestMethod]
        //public void AVTRAdapterTestActualState1()
        //{
        //    TRAdapter adapter = new TRAdapter();
        //    var result =
        //        adapter.GetActualState(
        //            new ActualStateRequestType() { UIC = "201593302" },
        //            AccessMatrix.CreateForType(typeof(ActualStateResponseType)),
        //            new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
        //            {
        //                CallContext = new CallContext() { Remark = "RegiXTestTest" },
        //                ClientIPAddress = "172.12.33.56",
        //                EmployeeEGN = "1212124563",
        //                OrganizationUnit = "ТехноЛогика"
        //            }
        //        );
        //    using (StreamWriter outfile = new StreamWriter("ActualState1.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ActualStateRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ActualStateResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}
        //[TestMethod]
        //public void AVTRAdapterTestActualState2()
        //{
        //    TRAdapter adapter = new TRAdapter();
        //    var result =
        //        adapter.GetActualState(
        //            new ActualStateRequestType() { UIC = "201704265" },
        //            AccessMatrix.CreateForType(typeof(ActualStateResponseType)),
        //            new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
        //            {
        //                CallContext = new CallContext() { Remark = "RegiXTestTest" },
        //                ClientIPAddress = "172.12.33.56",
        //                EmployeeEGN = "1212124563",
        //                OrganizationUnit = "ТехноЛогика"
        //            }
        //        );
        //    using (StreamWriter outfile = new StreamWriter("ActualState2.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ActualStateRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ActualStateResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}
        //[TestMethod]
        //public void AVTRAdapterTestActualState3()
        //{
        //    TRAdapter adapter = new TRAdapter();
        //    var result =
        //        adapter.GetActualState(
        //            new ActualStateRequestType() { UIC = "201704322" },
        //            AccessMatrix.CreateForType(typeof(ActualStateResponseType)),
        //            new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
        //            {
        //                CallContext = new CallContext() { Remark = "RegiXTestTest" },
        //                ClientIPAddress = "172.12.33.56",
        //                EmployeeEGN = "1212124563",
        //                OrganizationUnit = "ТехноЛогика"
        //            }
        //        );
        //    using (StreamWriter outfile = new StreamWriter("ActualState3.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ActualStateRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ActualStateResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}
        //[TestMethod]
        //public void AVTRAdapterTestActualState4()
        //{
        //    TRAdapter adapter = new TRAdapter();
        //    var result =
        //        adapter.GetActualState(
        //            new ActualStateRequestType() { UIC = "201704357" },
        //            AccessMatrix.CreateForType(typeof(ActualStateResponseType)),
        //            new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
        //            {
        //                CallContext = new CallContext() { Remark = "RegiXTestTest" },
        //                ClientIPAddress = "172.12.33.56",
        //                EmployeeEGN = "1212124563",
        //                OrganizationUnit = "ТехноЛогика"
        //            }
        //        );
        //    using (StreamWriter outfile = new StreamWriter("ActualState4.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ActualStateRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ActualStateResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}
        //[TestMethod]
        //public void AVTRAdapterTestActualState5()
        //{
        //    TRAdapter adapter = new TRAdapter();
        //    var result =
        //        adapter.GetActualState(
        //            new ActualStateRequestType() { UIC = "201704358" },
        //            AccessMatrix.CreateForType(typeof(ActualStateResponseType)),
        //            new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
        //            {
        //                CallContext = new CallContext() { Remark = "RegiXTestTest" },
        //                ClientIPAddress = "172.12.33.56",
        //                EmployeeEGN = "1212124563",
        //                OrganizationUnit = "ТехноЛогика"
        //            }
        //        );
        //    using (StreamWriter outfile = new StreamWriter("ActualState5.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ActualStateRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ActualStateResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}
        //[TestMethod]
        //public void AVTRAdapterTestActualState6()
        //{
        //    TRAdapter adapter = new TRAdapter();
        //    var result =
        //        adapter.GetActualState(
        //            new ActualStateRequestType() { UIC = "201704371" },
        //            AccessMatrix.CreateForType(typeof(ActualStateResponseType)),
        //            new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
        //            {
        //                CallContext = new CallContext() { Remark = "RegiXTestTest" },
        //                ClientIPAddress = "172.12.33.56",
        //                EmployeeEGN = "1212124563",
        //                OrganizationUnit = "ТехноЛогика"
        //            }
        //        );
        //    using (StreamWriter outfile = new StreamWriter("ActualState6.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ActualStateRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ActualStateResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}
        //[TestMethod]
        //public void AVTRAdapterTestActualState7()
        //{
        //    TRAdapter adapter = new TRAdapter();
        //    var result =
        //        adapter.GetActualState(
        //            new ActualStateRequestType() { UIC = "201704373" },
        //            AccessMatrix.CreateForType(typeof(ActualStateResponseType)),
        //            new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
        //            {
        //                CallContext = new CallContext() { Remark = "RegiXTestTest" },
        //                ClientIPAddress = "172.12.33.56",
        //                EmployeeEGN = "1212124563",
        //                OrganizationUnit = "ТехноЛогика"
        //            }
        //        );
        //    using (StreamWriter outfile = new StreamWriter("ActualState7.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ActualStateRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ActualStateResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}
        //[TestMethod]
        //public void AVTRAdapterTestActualState8()
        //{
        //    TRAdapter adapter = new TRAdapter();
        //    var result =
        //        adapter.GetActualState(
        //            new ActualStateRequestType() { UIC = "201704374" },
        //            AccessMatrix.CreateForType(typeof(ActualStateResponseType)),
        //            new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
        //            {
        //                CallContext = new CallContext() { Remark = "RegiXTestTest" },
        //                ClientIPAddress = "172.12.33.56",
        //                EmployeeEGN = "1212124563",
        //                OrganizationUnit = "ТехноЛогика"
        //            }
        //        );
        //    using (StreamWriter outfile = new StreamWriter("ActualState8.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ActualStateRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ActualStateResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}
        //[TestMethod]
        //public void AVTRAdapterTestActualState9()
        //{
        //    TRAdapter adapter = new TRAdapter();
        //    var result =
        //        adapter.GetActualState(
        //            new ActualStateRequestType() { UIC = "201704375" },
        //            AccessMatrix.CreateForType(typeof(ActualStateResponseType)),
        //            new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
        //            {
        //                CallContext = new CallContext() { Remark = "RegiXTestTest" },
        //                ClientIPAddress = "172.12.33.56",
        //                EmployeeEGN = "1212124563",
        //                OrganizationUnit = "ТехноЛогика"
        //            }
        //        );
        //    using (StreamWriter outfile = new StreamWriter("ActualState9.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ActualStateRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ActualStateResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}
        //[TestMethod]
        //public void AVTRAdapterTestActualState10()
        //{
        //    TRAdapter adapter = new TRAdapter();
        //    var result =
        //        adapter.GetActualState(
        //            new ActualStateRequestType() { UIC = "201704376" },
        //            AccessMatrix.CreateForType(typeof(ActualStateResponseType)),
        //            new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
        //            {
        //                CallContext = new CallContext() { Remark = "RegiXTestTest" },
        //                ClientIPAddress = "172.12.33.56",
        //                EmployeeEGN = "1212124563",
        //                OrganizationUnit = "ТехноЛогика"
        //            }
        //        );
        //    using (StreamWriter outfile = new StreamWriter("ActualState10.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ActualStateRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ActualStateResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}
        //[TestMethod]
        //public void AVTRAdapterTestActualState11()
        //{
        //    TRAdapter adapter = new TRAdapter();
        //    var result =
        //        adapter.GetActualState(
        //            new ActualStateRequestType() { UIC = "201704379" },
        //            AccessMatrix.CreateForType(typeof(ActualStateResponseType)),
        //            new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
        //            {
        //                CallContext = new CallContext() { Remark = "RegiXTestTest" },
        //                ClientIPAddress = "172.12.33.56",
        //                EmployeeEGN = "1212124563",
        //                OrganizationUnit = "ТехноЛогика"
        //            }
        //        );
        //    using (StreamWriter outfile = new StreamWriter("ActualState11.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ActualStateRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ActualStateResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}
        //[TestMethod]
        //public void AVTRAdapterTestActualState12()
        //{
        //    TRAdapter adapter = new TRAdapter();
        //    var result =
        //        adapter.GetActualState(
        //            new ActualStateRequestType() { UIC = "201704380" },
        //            AccessMatrix.CreateForType(typeof(ActualStateResponseType)),
        //            new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
        //            {
        //                CallContext = new CallContext() { Remark = "RegiXTestTest" },
        //                ClientIPAddress = "172.12.33.56",
        //                EmployeeEGN = "1212124563",
        //                OrganizationUnit = "ТехноЛогика"
        //            }
        //        );
        //    using (StreamWriter outfile = new StreamWriter("ActualState12.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ActualStateRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ActualStateResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}
        //[TestMethod]
        //public void AVTRAdapterTestActualState13()
        //{
        //    TRAdapter adapter = new TRAdapter();
        //    var result =
        //        adapter.GetActualState(
        //            new ActualStateRequestType() { UIC = "201704381" },
        //            AccessMatrix.CreateForType(typeof(ActualStateResponseType)),
        //            new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
        //            {
        //                CallContext = new CallContext() { Remark = "RegiXTestTest" },
        //                ClientIPAddress = "172.12.33.56",
        //                EmployeeEGN = "1212124563",
        //                OrganizationUnit = "ТехноЛогика"
        //            }
        //        );
        //    using (StreamWriter outfile = new StreamWriter("ActualState13.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ActualStateRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ActualStateResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}
        //[TestMethod]
        //public void AVTRAdapterTestActualState14()
        //{
        //    TRAdapter adapter = new TRAdapter();
        //    var result =
        //        adapter.GetActualState(
        //            new ActualStateRequestType() { UIC = "201704382" },
        //            AccessMatrix.CreateForType(typeof(ActualStateResponseType)),
        //            new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
        //            {
        //                CallContext = new CallContext() { Remark = "RegiXTestTest" },
        //                ClientIPAddress = "172.12.33.56",
        //                EmployeeEGN = "1212124563",
        //                OrganizationUnit = "ТехноЛогика"
        //            }
        //        );
        //    using (StreamWriter outfile = new StreamWriter("ActualState14.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ActualStateRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ActualStateResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}
        //[TestMethod]
        //public void AVTRAdapterTestActualState15()
        //{
        //    TRAdapter adapter = new TRAdapter();
        //    var result =
        //        adapter.GetActualState(
        //            new ActualStateRequestType() { UIC = "201704384" },
        //            AccessMatrix.CreateForType(typeof(ActualStateResponseType)),
        //            new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
        //            {
        //                CallContext = new CallContext() { Remark = "RegiXTestTest" },
        //                ClientIPAddress = "172.12.33.56",
        //                EmployeeEGN = "1212124563",
        //                OrganizationUnit = "ТехноЛогика"
        //            }
        //        );
        //    using (StreamWriter outfile = new StreamWriter("ActualState15.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ActualStateRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ActualStateResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}
        //[TestMethod]
        //public void AVTRAdapterTestActualState16()
        //{
        //    TRAdapter adapter = new TRAdapter();
        //    var result =
        //        adapter.GetActualState(
        //            new ActualStateRequestType() { UIC = "201704385" },
        //            AccessMatrix.CreateForType(typeof(ActualStateResponseType)),
        //            new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
        //            {
        //                CallContext = new CallContext() { Remark = "RegiXTestTest" },
        //                ClientIPAddress = "172.12.33.56",
        //                EmployeeEGN = "1212124563",
        //                OrganizationUnit = "ТехноЛогика"
        //            }
        //        );
        //    using (StreamWriter outfile = new StreamWriter("ActualState16.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ActualStateRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ActualStateResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}
        //[TestMethod]
        //public void AVTRAdapterTestActualState17()
        //{
        //    TRAdapter adapter = new TRAdapter();
        //    var result =
        //        adapter.GetActualState(
        //            new ActualStateRequestType() { UIC = "201704403" },
        //            AccessMatrix.CreateForType(typeof(ActualStateResponseType)),
        //            new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
        //            {
        //                CallContext = new CallContext() { Remark = "RegiXTestTest" },
        //                ClientIPAddress = "172.12.33.56",
        //                EmployeeEGN = "1212124563",
        //                OrganizationUnit = "ТехноЛогика"
        //            }
        //        );
        //    using (StreamWriter outfile = new StreamWriter("ActualState17.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ActualStateRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ActualStateResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}
        //[TestMethod]
        //public void AVTRAdapterTestActualState18()
        //{
        //    TRAdapter adapter = new TRAdapter();
        //    var result =
        //        adapter.GetActualState(
        //            new ActualStateRequestType() { UIC = "201704404" },
        //            AccessMatrix.CreateForType(typeof(ActualStateResponseType)),
        //            new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
        //            {
        //                CallContext = new CallContext() { Remark = "RegiXTestTest" },
        //                ClientIPAddress = "172.12.33.56",
        //                EmployeeEGN = "1212124563",
        //                OrganizationUnit = "ТехноЛогика"
        //            }
        //        );
        //    using (StreamWriter outfile = new StreamWriter("ActualState18.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ActualStateRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ActualStateResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}
        //[TestMethod]
        //public void AVTRAdapterTestActualState19()
        //{
        //    TRAdapter adapter = new TRAdapter();
        //    var result =
        //        adapter.GetActualState(
        //            new ActualStateRequestType() { UIC = "201704405" },
        //            AccessMatrix.CreateForType(typeof(ActualStateResponseType)),
        //            new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
        //            {
        //                CallContext = new CallContext() { Remark = "RegiXTestTest" },
        //                ClientIPAddress = "172.12.33.56",
        //                EmployeeEGN = "1212124563",
        //                OrganizationUnit = "ТехноЛогика"
        //            }
        //        );
        //    using (StreamWriter outfile = new StreamWriter("ActualState19.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ActualStateRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ActualStateResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}
        //[TestMethod]
        //public void AVTRAdapterTestActualState20()
        //{
        //    TRAdapter adapter = new TRAdapter();
        //    var result =
        //        adapter.GetActualState(
        //            new ActualStateRequestType() { UIC = "201704406" },
        //            AccessMatrix.CreateForType(typeof(ActualStateResponseType)),
        //            new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
        //            {
        //                CallContext = new CallContext() { Remark = "RegiXTestTest" },
        //                ClientIPAddress = "172.12.33.56",
        //                EmployeeEGN = "1212124563",
        //                OrganizationUnit = "ТехноЛогика"
        //            }
        //        );
        //    using (StreamWriter outfile = new StreamWriter("ActualState20.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ActualStateRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("AVTRAdapter", "TR_ActualStateResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void AVTRAdapterTestActualStateV3()
        //{
        //    TRAdapter adapter = new TRAdapter();

        //    var accessMatrix = AccessMatrix.CreateForType(typeof(ActualStateResponseV3_AM));
        //    //accessMatrix.AMEntry.AccessMatrix.

        //    var result =
        //        adapter.GetActualStateV3(
        //            new ActualStateRequestV3() { UIC = "201593301", FieldList = "" },
        //            accessMatrix,
        //            new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
        //            {
        //                CallContext = new CallContext() { Remark = "RegiXTestTest" },
        //                ClientIPAddress = "172.12.33.56",
        //                EmployeeEGN = "1212124563",
        //                OrganizationUnit = "ТехноЛогика"
        //            }
        //        );
        //    using (StreamWriter outfile = new StreamWriter("ActualStateV3_TL.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void AVTRAdapterTestActualStateV3_InvalidSubdeedType()
        //{
        //    TRAdapter adapter = new TRAdapter();

        //    var accessMatrix = AccessMatrix.CreateForType(typeof(ActualStateResponseV3_AM));

        //    try
        //    {
        //        var result =
        //                adapter.GetActualStateV3(
        //                    new ActualStateRequestV3() { UIC = "201593305", FieldList = "" },
        //                    accessMatrix,
        //                    new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
        //                    {
        //                        CallContext = new CallContext() { Remark = "RegiXTestTest" },
        //                        ClientIPAddress = "172.12.33.56",
        //                        EmployeeEGN = "1212124563",
        //                        OrganizationUnit = "ТехноЛогика"
        //                    }
        //                );

        //        Assert.IsTrue(false);
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex.Message.Contains("Заявката връща тип раздел"))
        //        {
        //            Assert.IsTrue(true);
        //        }
        //        else
        //        {
        //            Assert.IsTrue(false);
        //        }
        //    }


        //}


        //[TestMethod]
        //public void AVTRAdapterTestActualStateV3_FieldIdents()
        //{
        //    TRAdapter adapter = new TRAdapter();

        //    var accessMatrix = AccessMatrix.CreateForType(typeof(ActualStateResponseV3_AM));
        //    //accessMatrix.AMEntry.AccessMatrix.

        //    var result =
        //        adapter.GetActualStateV3(
        //            new ActualStateRequestV3() { UIC = "131413749", FieldList = "000,00310,00510,00511,0054" },
        //            accessMatrix,
        //            new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
        //            {
        //                CallContext = new CallContext() { Remark = "RegiXTestTest" },
        //                ClientIPAddress = "172.12.33.56",
        //                EmployeeEGN = "1212124563",
        //                OrganizationUnit = "ТехноЛогика"
        //            }
        //        );
        //    using (StreamWriter outfile = new StreamWriter("ActualStateV3_FieldIdents.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void AVTRAdapterTestActualStateV3_WithBranches()
        //{
        //    TRAdapter adapter = new TRAdapter();

        //    var accessMatrix = AccessMatrix.CreateForType(typeof(ActualStateResponseV3_AM));
        //    //accessMatrix.AMEntry.AccessMatrix.

        //    var result =
        //        adapter.GetActualStateV3(
        //            new ActualStateRequestV3() { UIC = "131413749", FieldList = "" },
        //            accessMatrix,
        //            new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
        //            {
        //                CallContext = new CallContext() { Remark = "RegiXTestTest" },
        //                ClientIPAddress = "172.12.33.56",
        //                EmployeeEGN = "1212124563",
        //                OrganizationUnit = "ТехноЛогика"
        //            }
        //        );
        //    using (StreamWriter outfile = new StreamWriter("ActualStateV3_dsk_leasing.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void AVTRAdapterTestActualStateV3_NotFound()
        //{
        //    TRAdapter adapter = new TRAdapter();

        //    var accessMatrix = AccessMatrix.CreateForType(typeof(ActualStateResponseV3_AM));
        //    //accessMatrix.AMEntry.AccessMatrix.

        //    var result =
        //        adapter.GetActualStateV3(
        //            new ActualStateRequestV3() { UIC = "ttttt", FieldList = "" },
        //            accessMatrix,
        //            new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
        //            {
        //                CallContext = new CallContext() { Remark = "RegiXTestTest" },
        //                ClientIPAddress = "172.12.33.56",
        //                EmployeeEGN = "1212124563",
        //                OrganizationUnit = "ТехноЛогика"
        //            }
        //        );
        //    using (StreamWriter outfile = new StreamWriter("ActualStateV3_notfound.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    Assert.IsTrue(result.Data.Response.DataFound == false && result.Data.Response.DataFoundSpecified);
        //}

        //[TestMethod]
        //public void AVTRAdapterGetBranchOffice_BranchNotFound()
        //{
        //    TRAdapter adapter = new TRAdapter();

        //    var accessMatrix = AccessMatrix.CreateForType(typeof(GetBranchOfficeResponse_AM));
        //    //accessMatrix.AMEntry.AccessMatrix.

        //    var result =
        //        adapter.GetBranchOffice(
        //            new GetBranchOfficeRequest() { UIC = "2015933010001" },
        //            accessMatrix,
        //            new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
        //            {
        //                CallContext = new CallContext() { Remark = "RegiXTestTest" },
        //                ClientIPAddress = "172.12.33.56",
        //                EmployeeEGN = "1212124563",
        //                OrganizationUnit = "ТехноЛогика"
        //            }
        //        );
        //    using (StreamWriter outfile = new StreamWriter("GetBranchOffice_BranchNotFound.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    Assert.IsTrue(result.Data.Response.DataFound == false && result.Data.Response.DataFoundSpecified);
        //}

        //[TestMethod]
        //public void AVTRAdapterGetBranchOffice()
        //{
        //    TRAdapter adapter = new TRAdapter();

        //    var accessMatrix = AccessMatrix.CreateForType(typeof(ActualStateResponseV3_AM));
        //    //accessMatrix.AMEntry.AccessMatrix.

        //    var result =
        //        adapter.GetBranchOffice(
        //            new GetBranchOfficeRequest() { UIC = "1314137490026" },
        //            accessMatrix,
        //            new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
        //            {
        //                CallContext = new CallContext() { Remark = "RegiXTestTest" },
        //                ClientIPAddress = "172.12.33.56",
        //                EmployeeEGN = "1212124563",
        //                OrganizationUnit = "ТехноЛогика"
        //            }
        //        );
        //    using (StreamWriter outfile = new StreamWriter("GetBranchOffice_dsk_leasing_varna.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void AVTRAdapterGetBranchOffice_validUIC_invalidBranch()
        //{
        //    TRAdapter adapter = new TRAdapter();

        //    var accessMatrix = AccessMatrix.CreateForType(typeof(ActualStateResponseV3_AM));
        //    //accessMatrix.AMEntry.AccessMatrix.

        //    var result =
        //        adapter.GetBranchOffice(
        //            new GetBranchOfficeRequest() { UIC = "1314137490999" },
        //            accessMatrix,
        //            new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
        //            {
        //                CallContext = new CallContext() { Remark = "RegiXTestTest" },
        //                ClientIPAddress = "172.12.33.56",
        //                EmployeeEGN = "1212124563",
        //                OrganizationUnit = "ТехноЛогика"
        //            }
        //        );
        //    using (StreamWriter outfile = new StreamWriter("GetBranchOffice_validUIC_invalidBranch.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    Assert.IsTrue(true);
        //}


        //[TestMethod]
        //[ExpectedException(typeof(ArgumentException))]
        //public void AVTRAdapterGetBranchOfficesInvalidUIC()
        //{
        //    TRAdapter adapter = new TRAdapter();

        //    var accessMatrix = AccessMatrix.CreateForType(typeof(GetBranchOfficeResponse_AM));

        //    var result =
        //        adapter.GetBranchOffice(
        //            new GetBranchOfficeRequest() { UIC = "201593301" },
        //            accessMatrix,
        //            new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
        //            {
        //                CallContext = new CallContext() { Remark = "RegiXTestTest" },
        //                ClientIPAddress = "172.12.33.56",
        //                EmployeeEGN = "1212124563",
        //                OrganizationUnit = "ТехноЛогика"
        //            }
        //        );
        //}
    }
}
