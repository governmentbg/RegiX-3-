//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using NUnit.Framework;
//using TechnoLogica.RegiX.Common.ObjectMapping;
//using TechnoLogica.RegiX.MZHPastureAdapter;
//using TechnoLogica.RegiX.MZHPastureAdapter.AdapterService;
//using TechnoLogica.RegiX.Common.Utils;
//using System.IO;
//using TechnoLogica.RegiX.Common.DataContracts;
//using TechnoLogica.RegiX.Common.AdapterCore;
//using System.Linq;
//using TechnoLogica.RegiX.Common;


//namespace RegiX.MZHPastureAdapterTests
//{
//     [TestClass]
//    public class MZHPastureAdapterTests
//    {
//        [TestMethod]
//        public void MZHPastureAdapterServiceTest_CheckHealthCheckAndParamtersTest()
//        {
//            MZHPastureAdapterService adapter = new MZHPastureAdapterService();
//            //test GetParameters , and ConnectionString
//            var connectionString = adapter.GetParameters().ParameterList.Where(p => p.Key == TechnoLogica.RegiX.Common.Constants.ConnectionStringParameterKeyName).FirstOrDefault();
//            //test SetParameter
//            adapter.SetParameter(TechnoLogica.RegiX.Common.Constants.ConnectionStringParameterKeyName, connectionString.CurrentValue);
//            //test HCfunctions
//            var hcFunctions = adapter.GetHealthCheckFunctions();
//            hcFunctions.HealthInfosList.ForEach(f => adapter.CheckHealthFunction(f.Key));
//            NUnit.Framework.Assert.IsTrue(true);
//        }

//        [TestMethod]
//        public void Test_PastureMeadowLandResult()
//        {
//            TechnoLogica.RegiX.MZHPastureAdapter.PastureMeadowLandRequestType argument = new TechnoLogica.RegiX.MZHPastureAdapter.PastureMeadowLandRequestType
//            {
//                BeneficiaryIdentifier = "831642181"
//            };
//            IMZHPastureAdapterService adapter = new MZHPastureAdapterService();

//            AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
//            additionalParameters.CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext();// "\"LawReason\":\"Тестване на RegiX\",\"ServiceURI\":\"123456789\",\”ServiceType\”:\”За проверовъчна дейност\”\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"Министерство на земеделието и храните\",\” UserAdministrationID\”:\”10.20.503.4\”,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
//            additionalParameters.CitizenEGN = "8888888888";
//            additionalParameters.ClientIPAddress = "111.111.111.111";
//            additionalParameters.ConsumerCertificateThumbprint = "###";
//            additionalParameters.EIDToken = "token123";
//            additionalParameters.EmployeeEGN = "11111111111111";
//            additionalParameters.OrganizationEIK = "12121212121";
//            additionalParameters.OrganizationUnit = "qqqqqq";
//            additionalParameters.SignResult = true;

//            var result = adapter.GetPastureMeadowLand(argument, AccessMatrix.CreateForType(typeof(PastureMeadowLandResponse)), additionalParameters);

//            using (StreamWriter outfile = new StreamWriter("MZHPastureAdapter.xml", false, System.Text.Encoding.UTF8))
//            {
//                outfile.Write(result.XmlSerialize());
//            }
//            XsltUtils.RunXsltAndWriteHtml("MZHPastureAdapter", "PastureMeadowLandRequest", result.Data.Request.XmlSerialize());
//            XsltUtils.RunXsltAndWriteHtml("MZHPastureAdapter", "PastureMeadowLandResponse", result.Data.Response.XmlSerialize());
//            NUnit.Framework.Assert.IsNotNull(result.Data.Response);
//            NUnit.Framework.Assert.Greater(result.Data.Response.PastureLands.PastureLand.Count, 0);
//        }

//        [TestMethod]
//        public void Test_PastureMeadowLandNONResult()
//        {
//            TechnoLogica.RegiX.MZHPastureAdapter.PastureMeadowLandRequestType argument = new TechnoLogica.RegiX.MZHPastureAdapter.PastureMeadowLandRequestType
//            {
//                BeneficiaryIdentifier = "4326537461"
//            };
//            IMZHPastureAdapterService adapter = new MZHPastureAdapterService();

//            AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
//            additionalParameters.CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext() { Remark = "RegiXTest" };// "\"LawReason\":\"Тестване на RegiX\",\"ServiceURI\":\"123456789\",\”ServiceType\”:\”За проверовъчна дейност\”\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"Министерство на земеделието и храните\",\” UserAdministrationID\”:\”10.20.503.4\”,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
//            additionalParameters.CitizenEGN = "8888888888";
//            additionalParameters.ClientIPAddress = "111.111.111.111";
//            additionalParameters.ConsumerCertificateThumbprint = "###";
//            additionalParameters.EIDToken = "token123";
//            additionalParameters.EmployeeEGN = "11111111111111";
//            additionalParameters.OrganizationEIK = "12121212121";
//            additionalParameters.OrganizationUnit = "qqqqqq";

//            var result = adapter.GetPastureMeadowLand(argument, AccessMatrix.CreateForType(typeof(PastureMeadowLandResponse)), additionalParameters);
//            XsltUtils.RunXsltAndWriteHtml("MZHPastureAdapter", "PastureMeadowLandRequest", result.Data.Request.XmlSerialize());
//            if(result.Data.Response != null)
//            {
//                XsltUtils.RunXsltAndWriteHtml("MZHPastureAdapter", "PastureMeadowLandResponse", result.Data.Response.XmlSerialize());
//            }
            
//            NUnit.Framework.Assert.IsNull(result.Data.Response.PastureLands);
//        }

//        [TestMethod]
//        public void CheckConnectionTest()
//        {
//            IMZHPastureAdapterService adapter = new MZHPastureAdapterService();
//            string status = adapter.CheckRegisterConnection();
//            if (status == Constants.ConnectionOk)
//            {
//                NUnit.Framework.Assert.IsTrue(true);
//            }
//            else
//            {
//                NUnit.Framework.Assert.IsTrue(false);
//            }
//        }

//        [TestMethod]
//        public void Test_PastureMeadowLandDetailResult()
//        {
//            TechnoLogica.RegiX.MZHPastureAdapter.PastureMeadowLandDetailRequestType argument = new TechnoLogica.RegiX.MZHPastureAdapter.PastureMeadowLandDetailRequestType 
//            { BeneficiaryIdentifier = "831642181" };
//            IMZHPastureAdapterService adapter = new MZHPastureAdapterService();

//            AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
//            additionalParameters.CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext();// "\"LawReason\":\"Тестване на RegiX\",\"ServiceURI\":\"123456789\",\”ServiceType\”:\”За проверовъчна дейност\”\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"Министерство на земеделието и храните\",\” UserAdministrationID\”:\”10.20.503.4\”,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
//            additionalParameters.CitizenEGN = "8888888888";
//            additionalParameters.ClientIPAddress = "111.111.111.111";
//            additionalParameters.ConsumerCertificateThumbprint = "###";
//            additionalParameters.EIDToken = "token123";
//            additionalParameters.EmployeeEGN = "11111111111111";
//            additionalParameters.OrganizationEIK = "12121212121";
//            additionalParameters.OrganizationUnit = "qqqqqq";
//            additionalParameters.SignResult = true;

//            var result = adapter.GetPastureMeadowLandDetail(argument, AccessMatrix.CreateForType(typeof(PastureMeadowLandDetailResponse)), additionalParameters);

//            using (StreamWriter outfile = new StreamWriter("MZHPastureDetailAdapter.xml", false, System.Text.Encoding.UTF8))
//            {
//                outfile.Write(result.XmlSerialize());
//            }
//            //XsltUtils.RunXsltAndWriteHtml("MZHPastureAdapter", "PastureMeadowLandRequest", result.Data.Request.XmlSerialize());
//            //XsltUtils.RunXsltAndWriteHtml("MZHPastureAdapter", "PastureMeadowLandResponse", result.Data.Response.XmlSerialize());
//            NUnit.Framework.Assert.IsNotNull(result.Data.Response);
//            NUnit.Framework.Assert.Greater(result.Data.Response.PastureLands.PastureLand.Count, 0);
//        }
//    }
//}
