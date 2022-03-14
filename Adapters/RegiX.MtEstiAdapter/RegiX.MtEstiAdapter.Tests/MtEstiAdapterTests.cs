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
//using TechnoLogica.RegiX.MtEstiAdapter.AdapterService;

//namespace RegiX.MtEstiAdapterTests
//{
//    [TestClass]
//    public class MtEstiAdapterTests
//    {
//        // При промяна на параметрите в web.config-a на адаптера трябва да се променят и тук, понеже при тестване се взимат от app.configa на тестовете

//        [TestMethod]
//        public void MtEstiAdapter_CheckHealthCheckAndParamеtersTest()
//        {
//            MtEstiAdapter adapter = new MtEstiAdapter();
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
//        public void MtEstiAdapter_CheckRegisterConnection()
//        {
//            MtEstiAdapter adapter = new MtEstiAdapter();
//            string result = adapter.CheckRegisterConnection();
//            Assert.IsTrue(result == TechnoLogica.RegiX.Common.Constants.ConnectionOk || result == TechnoLogica.RegiX.Common.Constants.ConnectionStringNotSet);
//        }

//        /// <summary>
//        /// Ново МН и Ново Лидо
//        /// </summary>
//        //[TestMethod]
//        //public void SendInfoForAccomodationPlaceTest_Insert_NewPerson()
//        //{
//        //    TechnoLogica.RegiX.Common.TransportObject.CallContext context = new TechnoLogica.RegiX.Common.TransportObject.CallContext()
//        //    {
//        //        AdministrationOId = "https://trust-party-openid.com",
//        //        LawReason = "Тестване на RegiX",
//        //        ServiceURI = "1222-200030-12.12.2022",
//        //        Remark = "Забележки",
//        //        EmployeeAditionalIdentifier = "Карта номер 3",
//        //        EmployeeIdentifier = "test@tesactivedirectory.com",
//        //        EmployeeNames = "Тестов Потребител Потребител",
//        //        AdministrationName = "Българска агенция за Тестване",
//        //        EmployeePosition = "Старши експерт Отдел \"Тестване на интеграцията\"",
//        //        ResponsiblePersonIdentifier = "392309324",
//        //        ServiceType = "За проверовъчна дейност"
//        //    };
//        //    string oldcontext = context.ToString();

//        //    MtEstiAdapter adapter = new MtEstiAdapter();

//        //    var accessMatrix = AccessMatrix.CreateForType(typeof(AccomodationPlaceRequestType));

//        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
//        //    additionalParameters.CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext() { Remark = "RegiXTest" };
//        //    additionalParameters.CitizenEGN = "8888888888";
//        //    additionalParameters.ClientIPAddress = "111.111.111.111";
//        //    additionalParameters.ConsumerCertificateThumbprint = "###";
//        //    additionalParameters.EIDToken = "token123";
//        //    additionalParameters.EmployeeEGN = "11111111111111";
//        //    additionalParameters.OrganizationEIK = "12121212121";
//        //    additionalParameters.OrganizationUnit = "qqqqqq";
//        //    additionalParameters.SignResult = false;
//        //    additionalParameters.ReturnAccessMatrix = false;

//        //    var searchCriteria = CreateAccomodationPlaceRequestType("ОО-ККК-ЛЛЛ-ХХ");

//        //    var result = adapter.SendInfoForAccomodationPlace(searchCriteria, accessMatrix, additionalParameters);
//        //    string xml = result.XmlSerialize();
//        //    using (StreamWriter outfile = new StreamWriter("SendInfoForAccomodationPlaceTest.xml", false, System.Text.Encoding.UTF8))
//        //    {
//        //        outfile.Write(xml);
//        //    }

//        //    //XsltUtils.RunXsltAndWriteHtml("MtEstiAdapter", "AccomodationPlaceRequest", result.Data.Request.XmlSerialize());
//        //    //XsltUtils.RunXsltAndWriteHtml("MtEstiAdapter", "AccomodationPlaceResponse", result.Data.Response.XmlSerialize());

//        //    //XmlDocument doc = new XmlDocument();
//        //    //doc.LoadXml(xml);
//        //    //if (SigningUtils.HasSignature(doc))
//        //    //{
//        //    //    bool isValid = SigningUtils.ValidateXmlDocumentWithX509Certificate(doc.DocumentElement);
//        //    //    if (isValid)
//        //    //    {
//        //    //        Assert.IsTrue(true);
//        //    //    }
//        //    //}
//        //    //else
//        //    //{
//        //    //    Assert.IsTrue(true);
//        //    //}
//        //}

//        /// <summary>
//        /// Ново МН и Съществуващо Лидо
//        /// </summary>
//        [TestMethod]
//        public void SendInfoForAccomodationPlaceTest_Insert_ExistingPerson()
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

//            MtEstiAdapter adapter = new MtEstiAdapter();

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

//            //var searchCriteria = CreateAccomodationPlaceRequestType("ОО-ККК-НОВ-ХХ");
//            //PersonType lido = searchCriteria.LidoData[0].LidoPerson;
//            //lido.Address.RemoveAt(0);
//            //lido.Phone.RemoveAt(0);
//            //lido.Email.RemoveAt(0);
//            //lido.MiddleName = "Petrov2";
//            //lido.Address[0].CityArea = "ново село Панчарево";
//            //searchCriteria.Name = "тест 2";
//            //string xmlTest = searchCriteria.XmlSerialize();

//            var searchCriteria = this.CreateAccomodationPlaceRequestType();

//            //var text = File.ReadAllText(@"D:\Projects\RegiX\RegiX.Tests\RegiX.MtEstiAdapterTests\bin\Debug\testing.txt");
//            //var searchCriteria = (AccomodationPlaceRequestType)text.XmlDeserialize(typeof(AccomodationPlaceRequestType));

//            var result = adapter.SendInfoForAccomodationPlace(searchCriteria, accessMatrix, additionalParameters);
//            string xml = result.XmlSerialize();
//            using (StreamWriter outfile = new StreamWriter("SendInfoForAccomodationPlaceTest.xml", false, System.Text.Encoding.UTF8))
//            {
//                outfile.Write(xml);
//            }

//            //XsltUtils.RunXsltAndWriteHtml("MtEstiAdapter", "AccomodationPlaceRequest", result.Data.Request.XmlSerialize());
//            //XsltUtils.RunXsltAndWriteHtml("MtEstiAdapter", "AccomodationPlaceResponse", result.Data.Response.XmlSerialize());

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

//        /// <summary>
//        /// Съществуващо МН и Ново Лидо
//        /// </summary>
//        //[TestMethod]
//        //public void SendInfoForAccomodationPlaceTest_Update_NewPerson()
//        //{
//        //    TechnoLogica.RegiX.Common.TransportObject.CallContext context = new TechnoLogica.RegiX.Common.TransportObject.CallContext()
//        //    {
//        //        AdministrationOId = "https://trust-party-openid.com",
//        //        LawReason = "Тестване на RegiX",
//        //        ServiceURI = "1222-200030-12.12.2022",
//        //        Remark = "Забележки",
//        //        EmployeeAditionalIdentifier = "Карта номер 3",
//        //        EmployeeIdentifier = "test@tesactivedirectory.com",
//        //        EmployeeNames = "Тестов Потребител Потребител",
//        //        AdministrationName = "Българска агенция за Тестване",
//        //        EmployeePosition = "Старши експерт Отдел \"Тестване на интеграцията\"",
//        //        ResponsiblePersonIdentifier = "392309324",
//        //        ServiceType = "За проверовъчна дейност"
//        //    };
//        //    string oldcontext = context.ToString();

//        //    MtEstiAdapter adapter = new MtEstiAdapter();

//        //    var accessMatrix = AccessMatrix.CreateForType(typeof(AccomodationPlaceRequestType));

//        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
//        //    additionalParameters.CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext() { Remark = "RegiXTest" };
//        //    additionalParameters.CitizenEGN = "8888888888";
//        //    additionalParameters.ClientIPAddress = "111.111.111.111";
//        //    additionalParameters.ConsumerCertificateThumbprint = "###";
//        //    additionalParameters.EIDToken = "token123";
//        //    additionalParameters.EmployeeEGN = "11111111111111";
//        //    additionalParameters.OrganizationEIK = "12121212121";
//        //    additionalParameters.OrganizationUnit = "qqqqqq";
//        //    additionalParameters.SignResult = false;
//        //    additionalParameters.ReturnAccessMatrix = false;

//        //    var searchCriteria = CreateAccomodationPlaceRequestType("ОО-ККК-НОВ-ХХ");
//        //    PersonType lido = (PersonType)searchCriteria.Lido.Item;
//        //    lido.Address.RemoveAt(0);
//        //    lido.Phone.RemoveAt(0);
//        //    lido.Email.RemoveAt(0);
//        //    lido.FirstName = "Иван";
//        //    lido.MiddleName = "Иванов";
//        //    lido.LastName = "Асенов";
//        //    lido.IdentityNumber = "9705059099";
//        //    lido.Address[0].CityArea = "ново село Панчарево 3";
//        //    searchCriteria.Name = "тест 3";

//        //    var result = adapter.SendInfoForAccomodationPlace(searchCriteria, accessMatrix, additionalParameters);
//        //    string xml = result.XmlSerialize();
//        //    using (StreamWriter outfile = new StreamWriter("SendInfoForAccomodationPlaceTest.xml", false, System.Text.Encoding.UTF8))
//        //    {
//        //        outfile.Write(xml);
//        //    }

//        //    //XsltUtils.RunXsltAndWriteHtml("MtEstiAdapter", "AccomodationPlaceRequest", result.Data.Request.XmlSerialize());
//        //    //XsltUtils.RunXsltAndWriteHtml("MtEstiAdapter", "AccomodationPlaceResponse", result.Data.Response.XmlSerialize());

//        //    //XmlDocument doc = new XmlDocument();
//        //    //doc.LoadXml(xml);
//        //    //if (SigningUtils.HasSignature(doc))
//        //    //{
//        //    //    bool isValid = SigningUtils.ValidateXmlDocumentWithX509Certificate(doc.DocumentElement);
//        //    //    if (isValid)
//        //    //    {
//        //    //        Assert.IsTrue(true);
//        //    //    }
//        //    //}
//        //    //else
//        //    //{
//        //    //    Assert.IsTrue(true);
//        //    //}
//        //}

//        /// <summary>
//        /// Ново МН и Ново Лидо Юридическо лице
//        /// </summary>
//        //[TestMethod]
//        //public void SendInfoForAccomodationPlaceTest_Insert_NewLegalPerson()
//        //{
//        //    TechnoLogica.RegiX.Common.TransportObject.CallContext context = new TechnoLogica.RegiX.Common.TransportObject.CallContext()
//        //    {
//        //        AdministrationOId = "https://trust-party-openid.com",
//        //        LawReason = "Тестване на RegiX",
//        //        ServiceURI = "1222-200030-12.12.2022",
//        //        Remark = "Забележки",
//        //        EmployeeAditionalIdentifier = "Карта номер 3",
//        //        EmployeeIdentifier = "test@tesactivedirectory.com",
//        //        EmployeeNames = "Тестов Потребител Потребител",
//        //        AdministrationName = "Българска агенция за Тестване",
//        //        EmployeePosition = "Старши експерт Отдел \"Тестване на интеграцията\"",
//        //        ResponsiblePersonIdentifier = "392309324",
//        //        ServiceType = "За проверовъчна дейност"
//        //    };
//        //    string oldcontext = context.ToString();

//        //    MtEstiAdapter adapter = new MtEstiAdapter();

//        //    var accessMatrix = AccessMatrix.CreateForType(typeof(AccomodationPlaceRequestType));

//        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
//        //    additionalParameters.CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext() { Remark = "RegiXTest" };
//        //    additionalParameters.CitizenEGN = "8888888888";
//        //    additionalParameters.ClientIPAddress = "111.111.111.111";
//        //    additionalParameters.ConsumerCertificateThumbprint = "###";
//        //    additionalParameters.EIDToken = "token123";
//        //    additionalParameters.EmployeeEGN = "11111111111111";
//        //    additionalParameters.OrganizationEIK = "12121212121";
//        //    additionalParameters.OrganizationUnit = "qqqqqq";
//        //    additionalParameters.SignResult = false;
//        //    additionalParameters.ReturnAccessMatrix = false;

//        //    var searchCriteria = CreateAccomodationPlaceRequestType("ОО-ФФФ-ЛЛЛ-ХХ", isPerson: false);
//        //    string xmlTest = searchCriteria.XmlSerialize();

//        //    var result = adapter.SendInfoForAccomodationPlace(searchCriteria, accessMatrix, additionalParameters);
//        //    string xml = result.XmlSerialize();
//        //    using (StreamWriter outfile = new StreamWriter("SendInfoForAccomodationPlaceTest.xml", false, System.Text.Encoding.UTF8))
//        //    {
//        //        outfile.Write(xml);
//        //    }

//        //    //XsltUtils.RunXsltAndWriteHtml("MtEstiAdapter", "AccomodationPlaceRequest", result.Data.Request.XmlSerialize());
//        //    //XsltUtils.RunXsltAndWriteHtml("MtEstiAdapter", "AccomodationPlaceResponse", result.Data.Response.XmlSerialize());

//        //    //XmlDocument doc = new XmlDocument();
//        //    //doc.LoadXml(xml);
//        //    //if (SigningUtils.HasSignature(doc))
//        //    //{
//        //    //    bool isValid = SigningUtils.ValidateXmlDocumentWithX509Certificate(doc.DocumentElement);
//        //    //    if (isValid)
//        //    //    {
//        //    //        Assert.IsTrue(true);
//        //    //    }
//        //    //}
//        //    //else
//        //    //{
//        //    //    Assert.IsTrue(true);
//        //    //}
//        //}

//        /// <summary>
//        /// Съществуващо МН и Ново Лидо Юридическо лице
//        /// </summary>
//        //[TestMethod]
//        //public void SendInfoForAccomodationPlaceTest_Update_NewLegalPerson()
//        //{
//        //    TechnoLogica.RegiX.Common.TransportObject.CallContext context = new TechnoLogica.RegiX.Common.TransportObject.CallContext()
//        //    {
//        //        AdministrationOId = "https://trust-party-openid.com",
//        //        LawReason = "Тестване на RegiX",
//        //        ServiceURI = "1222-200030-12.12.2022",
//        //        Remark = "Забележки",
//        //        EmployeeAditionalIdentifier = "Карта номер 3",
//        //        EmployeeIdentifier = "test@tesactivedirectory.com",
//        //        EmployeeNames = "Тестов Потребител Потребител",
//        //        AdministrationName = "Българска агенция за Тестване",
//        //        EmployeePosition = "Старши експерт Отдел \"Тестване на интеграцията\"",
//        //        ResponsiblePersonIdentifier = "392309324",
//        //        ServiceType = "За проверовъчна дейност"
//        //    };
//        //    string oldcontext = context.ToString();

//        //    MtEstiAdapter adapter = new MtEstiAdapter();

//        //    var accessMatrix = AccessMatrix.CreateForType(typeof(AccomodationPlaceRequestType));

//        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
//        //    additionalParameters.CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext() { Remark = "RegiXTest" };
//        //    additionalParameters.CitizenEGN = "8888888888";
//        //    additionalParameters.ClientIPAddress = "111.111.111.111";
//        //    additionalParameters.ConsumerCertificateThumbprint = "###";
//        //    additionalParameters.EIDToken = "token123";
//        //    additionalParameters.EmployeeEGN = "11111111111111";
//        //    additionalParameters.OrganizationEIK = "12121212121";
//        //    additionalParameters.OrganizationUnit = "qqqqqq";
//        //    additionalParameters.SignResult = false;
//        //    additionalParameters.ReturnAccessMatrix = false;

//        //    var searchCriteria = CreateAccomodationPlaceRequestType("ОО-ФФФ-ТТТ-ХХ", isPerson: false);

//        //    var result = adapter.SendInfoForAccomodationPlace(searchCriteria, accessMatrix, additionalParameters);
//        //    string xml = result.XmlSerialize();
//        //    using (StreamWriter outfile = new StreamWriter("SendInfoForAccomodationPlaceTest.xml", false, System.Text.Encoding.UTF8))
//        //    {
//        //        outfile.Write(xml);
//        //    }

//        //    //XsltUtils.RunXsltAndWriteHtml("MtEstiAdapter", "AccomodationPlaceRequest", result.Data.Request.XmlSerialize());
//        //    //XsltUtils.RunXsltAndWriteHtml("MtEstiAdapter", "AccomodationPlaceResponse", result.Data.Response.XmlSerialize());

//        //    //XmlDocument doc = new XmlDocument();
//        //    //doc.LoadXml(xml);
//        //    //if (SigningUtils.HasSignature(doc))
//        //    //{
//        //    //    bool isValid = SigningUtils.ValidateXmlDocumentWithX509Certificate(doc.DocumentElement);
//        //    //    if (isValid)
//        //    //    {
//        //    //        Assert.IsTrue(true);
//        //    //    }
//        //    //}
//        //    //else
//        //    //{
//        //    //    Assert.IsTrue(true);
//        //    //}
//        //}

//        /// <summary>
//        /// Валидации
//        /// </summary>
//        //[TestMethod]
//        //[ExpectedException(typeof(ArgumentException))]
//        //public void SendInfoForAccomodationPlaceTest_Validations()
//        //{
//        //    TechnoLogica.RegiX.Common.TransportObject.CallContext context = new TechnoLogica.RegiX.Common.TransportObject.CallContext()
//        //    {
//        //        AdministrationOId = "https://trust-party-openid.com",
//        //        LawReason = "Тестване на RegiX",
//        //        ServiceURI = "1222-200030-12.12.2022",
//        //        Remark = "Забележки",
//        //        EmployeeAditionalIdentifier = "Карта номер 3",
//        //        EmployeeIdentifier = "test@tesactivedirectory.com",
//        //        EmployeeNames = "Тестов Потребител Потребител",
//        //        AdministrationName = "Българска агенция за Тестване",
//        //        EmployeePosition = "Старши експерт Отдел \"Тестване на интеграцията\"",
//        //        ResponsiblePersonIdentifier = "392309324",
//        //        ServiceType = "За проверовъчна дейност"
//        //    };
//        //    string oldcontext = context.ToString();

//        //    MtEstiAdapter adapter = new MtEstiAdapter();

//        //    var accessMatrix = AccessMatrix.CreateForType(typeof(AccomodationPlaceRequestType));

//        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
//        //    additionalParameters.CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext() { Remark = "RegiXTest" };
//        //    additionalParameters.CitizenEGN = "8888888888";
//        //    additionalParameters.ClientIPAddress = "111.111.111.111";
//        //    additionalParameters.ConsumerCertificateThumbprint = "###";
//        //    additionalParameters.EIDToken = "token123";
//        //    additionalParameters.EmployeeEGN = "11111111111111";
//        //    additionalParameters.OrganizationEIK = "12121212121";
//        //    additionalParameters.OrganizationUnit = "qqqqqq";
//        //    additionalParameters.SignResult = false;
//        //    additionalParameters.ReturnAccessMatrix = false;

//        //    var searchCriteria = CreateAccomodationPlaceRequestType("ОО-ФФФ-ТТТ-ХХ", isPerson: false);
//        //    LegalPersonType lido = (LegalPersonType)searchCriteria.Lido.Item;
//        //    lido.Address.RemoveAt(0); // Removes second address
//        //    //lido.Address[0].EKATTE = "99999";
//        //    //searchCriteria.Address.EKATTE = "99998";
//        //    searchCriteria.Address.CountryCode = "DD";


//        //    var result = adapter.SendInfoForAccomodationPlace(searchCriteria, accessMatrix, additionalParameters);
//        //    string xml = result.XmlSerialize();
//        //    using (StreamWriter outfile = new StreamWriter("SendInfoForAccomodationPlaceTest.xml", false, System.Text.Encoding.UTF8))
//        //    {
//        //        outfile.Write(xml);
//        //    }

//        //    //XsltUtils.RunXsltAndWriteHtml("MtEstiAdapter", "AccomodationPlaceRequest", result.Data.Request.XmlSerialize());
//        //    //XsltUtils.RunXsltAndWriteHtml("MtEstiAdapter", "AccomodationPlaceResponse", result.Data.Response.XmlSerialize());

//        //    //XmlDocument doc = new XmlDocument();
//        //    //doc.LoadXml(xml);
//        //    //if (SigningUtils.HasSignature(doc))
//        //    //{
//        //    //    bool isValid = SigningUtils.ValidateXmlDocumentWithX509Certificate(doc.DocumentElement);
//        //    //    if (isValid)
//        //    //    {
//        //    //        Assert.IsTrue(true);
//        //    //    }
//        //    //}
//        //    //else
//        //    //{
//        //    //    Assert.IsTrue(true);
//        //    //}
//        //}

//        
//}
