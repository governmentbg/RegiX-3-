//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Xml;
//using System.Xml.Serialization;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using TechnoLogica.RegiX.Common.DataContracts;
//using TechnoLogica.RegiX.Common.ObjectMapping;
//using TechnoLogica.RegiX.Common.Utils;
//using TechnoLogica.RegiX.MtEstiAdapter;
//using TechnoLogica.RegiX.MVRTouristRegisterAdapter;
//using TechnoLogica.RegiX.MVRTouristRegisterAdapter.AdapterService;

//namespace RegiX.MVRTouristRegisterAdapterTests
//{
//    [TestClass]
//    public class MVRTouristRegisterAdapterTests
//    {
//        [TestMethod]
//        public void MVRTouristRegisterAdapter_CheckHealthCheckAndParamеtersTest()
//        {
//            MVRTouristRegisterAdapter adapter = new MVRTouristRegisterAdapter();
//            //test GetParameters , and ConnectionString
//            var connectionString = adapter.GetParameters().ParameterList.Where(p => p.Key == TechnoLogica.RegiX.Common.Constants.ConnectionStringParameterKeyName).FirstOrDefault();
//            //test SetParameter
//            adapter.SetParameter(TechnoLogica.RegiX.Common.Constants.ConnectionStringParameterKeyName, connectionString.CurrentValue);
//            //test HCfunctions
//            var hcFunctions = adapter.GetHealthCheckFunctions();
//            hcFunctions.HealthInfosList.ForEach(f => adapter.CheckHealthFunction(f.Key));
//            Assert.IsTrue(true);
//        }

//        [TestMethod]
//        public void MVRTouristRegisterAdapter_CheckRegisterConnection()
//        {
//            MVRTouristRegisterAdapter adapter = new MVRTouristRegisterAdapter();
//            string result = adapter.CheckRegisterConnection();
//            Assert.IsTrue(result == TechnoLogica.RegiX.Common.Constants.ConnectionOk || result == TechnoLogica.RegiX.Common.Constants.ConnectionStringNotSet);
//        }

//        [TestMethod]
//        public void SendInfoForTouristRegisterTest_Insert()
//        {
//            TechnoLogica.RegiX.Common.TransportObject.CallContext context = new TechnoLogica.RegiX.Common.TransportObject.CallContext()
//            {
//                AdministrationOId = "https://trust-party-openid.com",
//                LawReason = "Тестване на RegiX",
//                ServiceURI = "1222-200030-12.12.2022",
//                Remark = "Забележки",
//                EmployeeAditionalIdentifier = "Карта номер 3",
//                EmployeeIdentifier = "test@tesactivedirectory.com",
//                EmployeeNames = "Тестов Потребител Потребител",
//                AdministrationName = "Българска агенция за Тестване",
//                EmployeePosition = "Старши експерт Отдел \"Тестване на интеграцията\"",
//                ResponsiblePersonIdentifier = "392309324",
//                ServiceType = "За проверовъчна дейност"
//            };
//            string oldcontext = context.ToString();

//            MVRTouristRegisterAdapter adapter = new MVRTouristRegisterAdapter();

//            var accessMatrix = AccessMatrix.CreateForType(typeof(TouristRegisterRequestType));

//            AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
//            additionalParameters.CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext() { Remark = "RegiXTest" };
//            additionalParameters.CitizenEGN = "8888888888";
//            additionalParameters.ClientIPAddress = "111.111.111.111";
//            additionalParameters.ConsumerCertificateThumbprint = "###";
//            additionalParameters.EIDToken = "token123";
//            additionalParameters.EmployeeEGN = "11111111111111";
//            additionalParameters.OrganizationEIK = "12121212121";
//            additionalParameters.OrganizationUnit = "qqqqqq";
//            additionalParameters.SignResult = false;
//            additionalParameters.ReturnAccessMatrix = false;

//            //var searchCriteria = CreateTouristRegisterRequestType("ОО-ФФФ-ТТТ-ХХ", "cccc6666-66cc-6666-cccc-6666cccc6666", ChangeType.Insert;
//            var searchCriteria = CreateTouristRegisterRequestType("ОО-ФФФ-ТТТ-ХХ", "cccc6666-66cc-6666-cccc-6666cccc6666", ChangeType.Update);

//            var result = adapter.SendInfoForTouristRegister(searchCriteria, accessMatrix, additionalParameters);
//            string xml = result.XmlSerialize();
//            using (StreamWriter outfile = new StreamWriter("SendInfoForAccomodationPlaceTest.xml", false, System.Text.Encoding.UTF8))
//            {
//                outfile.Write(xml);
//            }

//            //XsltUtils.RunXsltAndWriteHtml("MVRTouristRegisterAdapter", "AccomodationPlaceRequest", result.Data.Request.XmlSerialize());
//            //XsltUtils.RunXsltAndWriteHtml("MVRTouristRegisterAdapter", "AccomodationPlaceResponse", result.Data.Response.XmlSerialize());

//            //XmlDocument doc = new XmlDocument();
//            //doc.LoadXml(xml);
//            //if (SigningUtils.HasSignature(doc))
//            //{
//            //    bool isValid = SigningUtils.ValidateXmlDocumentWithX509Certificate(doc.DocumentElement);
//            //    if (isValid)
//            //    {
//            //        Assert.IsTrue(true);
//            //    }
//            //}
//            //else
//            //{
//            //    Assert.IsTrue(true);
//            //}
//        }

//        [TestMethod]
//        public void SendInfoForEstiAccomodationPlace()
//        {
//            TechnoLogica.RegiX.Common.TransportObject.CallContext context = new TechnoLogica.RegiX.Common.TransportObject.CallContext()
//            {
//                AdministrationOId = "https://trust-party-openid.com",
//                LawReason = "Тестване на RegiX",
//                ServiceURI = "1222-200030-12.12.2022",
//                Remark = "Забележки",
//                EmployeeAditionalIdentifier = "Карта номер 3",
//                EmployeeIdentifier = "test@tesactivedirectory.com",
//                EmployeeNames = "Тестов Потребител Потребител",
//                AdministrationName = "Българска агенция за Тестване",
//                EmployeePosition = "Старши експерт Отдел \"Тестване на интеграцията\"",
//                ResponsiblePersonIdentifier = "392309324",
//                ServiceType = "За проверовъчна дейност"
//            };
//            string oldcontext = context.ToString();

//            MVRTouristRegisterAdapter adapter = new MVRTouristRegisterAdapter();

//            var accessMatrix = AccessMatrix.CreateForType(typeof(AccomodationPlaceRequestType));

//            AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
//            additionalParameters.CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext() { Remark = "RegiXTest" };
//            additionalParameters.CitizenEGN = "8888888888";
//            additionalParameters.ClientIPAddress = "111.111.111.111";
//            additionalParameters.ConsumerCertificateThumbprint = "###";
//            additionalParameters.EIDToken = "token123";
//            additionalParameters.EmployeeEGN = "11111111111111";
//            additionalParameters.OrganizationEIK = "12121212121";
//            additionalParameters.OrganizationUnit = "qqqqqq";
//            additionalParameters.SignResult = false;
//            additionalParameters.ReturnAccessMatrix = false;

//            var searchCriteria = CreateAccomodationPlaceRequestType();

//            var result = adapter.SendInfoForEstiAccomodationPlace(searchCriteria, accessMatrix, additionalParameters);
//            string xml = result.XmlSerialize();
//            using (StreamWriter outfile = new StreamWriter("SendInfoForAccomodationPlaceTest.xml", false, System.Text.Encoding.UTF8))
//            {
//                outfile.Write(xml);
//            }

//            //XsltUtils.RunXsltAndWriteHtml("MVRTouristRegisterAdapter", "AccomodationPlaceRequest", result.Data.Request.XmlSerialize());
//            //XsltUtils.RunXsltAndWriteHtml("MVRTouristRegisterAdapter", "AccomodationPlaceResponse", result.Data.Response.XmlSerialize());

//            //XmlDocument doc = new XmlDocument();
//            //doc.LoadXml(xml);
//            //if (SigningUtils.HasSignature(doc))
//            //{
//            //    bool isValid = SigningUtils.ValidateXmlDocumentWithX509Certificate(doc.DocumentElement);
//            //    if (isValid)
//            //    {
//            //        Assert.IsTrue(true);
//            //    }
//            //}
//            //else
//            //{
//            //    Assert.IsTrue(true);
//            //}
//        }

//        private AccomodationPlaceRequestType CreateAccomodationPlaceRequestType()
//        {
//            string xml = File.ReadAllText(@"C:\Users\mdonchev\Desktop\testing.txt");

//            var parameter = XmlDeserialize(xml, typeof(AccomodationPlaceRequestType));
//            return parameter as AccomodationPlaceRequestType;
//        }

//        public object XmlDeserialize(string serializedObject, Type type)
//        {
//            if (string.IsNullOrEmpty(serializedObject))
//            {
//                return null;
//            }
//            using (StringReader sr = new StringReader(serializedObject))
//            {
//                XmlSerializer serializer = new XmlSerializer(type);
//                return serializer.Deserialize(sr);
//            }
//        }

//        private TouristRegisterRequestType CreateTouristRegisterRequestType(string uin, string uid, ChangeType change)
//        {
//            var result = new TouristRegisterRequestType();
//            result.AccomodationPlaceUIN = uin;
//            result.Change = change;

//            result.Person = new TechnoLogica.RegiX.MVRTouristRegisterAdapter.PersonType();
//            result.Person.FirstName = "Иван";
//            result.Person.MiddleName = "Петров";
//            result.Person.FamilyName = "Иванов";
//            result.Person.Sex = GenderType.M;
//            result.Person.BirthDate = new DateTime(1994, 10, 22);
//            result.Person.ForeignNumber = "9410229876";
//            result.Person.IdentityDocumentTypeCode = DocType.PAS;
//            result.Person.IdentityDocumentTypeCodeSpecified = true;
//            result.Person.IdentityDocumentNumber = "234512345";
//            result.Person.IdentityDocumentCountryCode = "GN";

//            result.Registration = new RegistrationType();
//            result.Registration.RegistrationDate = DateTime.Now.AddDays(-5);
//            result.Registration.RegistrationUID = uid;
//            result.Registration.CheckInDate = DateTime.Now.AddDays(-3);
//            result.Registration.CheckOutDate = DateTime.Now.AddDays(-1);
//            result.Registration.Floor = "етаж 4";
//            result.Registration.Room = "ап. 42";
//            result.Registration.TouristPackage = true;
//            result.Registration.AveragePrice = 34;
//            result.Registration.NightsCount = 66;
//            result.Registration.NightsCountSpecified = true;

//            return result;
//        }
//    }
//}
