using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnoLogica.RegiX.MVRANDAdapter.AdapterService;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.Common.DataContracts;
using System;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.MVRANDAdapter.Tests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class MVRANDAdapterTest : AdapterTest<AdapterService.MVRANDAdapter, IMVRANDAdapter>
    {
     //   [TestMethod]
        public void SendPaymentNotificationExternalTest()
        {
            AdapterService.MVRANDAdapter mVRANDAdapter = new AdapterService.MVRANDAdapter();

            AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters()
            {
                
                OrganizationUnit = "TL",
                EIDToken = "",
                CallContext = new CallContext() 
                { 
                    LawReason = "≈À.‘»ÿ —≈–»ﬂ K 2911837 01.09.2021", 
                    EmployeeIdentifier = "tl_mmarinov", 
                    AdministrationName = "TL_Miro", 
                    AdministrationOId = "2.0.0.0.0.1",
                    EmployeeNames = "Miroslav Marinov",
                    ServiceURI = "TestURI",
                    ServiceType = "For testing purposes"
                },
                SignResult = false,
                ReturnAccessMatrix = true,
                ApiServiceCallId = 191417,
                CallbackURL = "192.168.1.1"
            };

            SendPaymentNotificationRequestType request = new SendPaymentNotificationRequestType
            {
                //AdministrationName = "TechnoLogicaTest",
                DocumentNumber = "21-4134-—000065",
                //DocumentSeries = "K",
                DocumentType = SendNotificationDocumentType.AGREEMENT,
                //PayerPin = "880620****",
                //PayerType =  SendNotificationPayerType.P,
                PaymentAmount = 280.0,
                PaymentDate = DateTime.Now,
                SystemId = 24,
                TransactionNumber = "900100619112",
                PayerTypeSpecified = false,
                SystemIdSpecified = true
            };

            var result = mVRANDAdapter.SendPaymentNotification(request, AccessMatrix.CreateForType(typeof(SendPaymentNotificationResponseType)), additionalParameters);

            Assert.IsTrue(true);
        }

        //private string _serviceurl = "http://172.16.69.13:8078/MVRMockup/MVRMockupService.svc";

        //[TestMethod]
        //public void GetObligationDocumentsTest()
        //{
        //    XmlDocument identityXML = new XmlDocument();
        //    identityXML.Load("../../eID.xml");

        //    MVRANDAdapter mvrandAdapter = new MVRANDAdapter();
        //    //mvrandAdapter.SetParameter("WebServiceUrl", _serviceurl);


        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters()
        //    {
        //        OrganizationUnit = "TL",
        //        EIDToken = identityXML.InnerXml,
        //        CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext() { LawReason = "Regixtest", EmployeeIdentifier = "tl_mmarinov" },
        //        SignResult = false,
        //        ReturnAccessMatrix = true
        //    };

        //    var result = mvrandAdapter.GetObligationDocuments(new ObligationDocumentsRequestType() { documentNumber = "210000", documentSeries = "K", documentType = DocumentType.ACT, initialAmount = 70.00 },
        //                                      AccessMatrix.CreateForType(typeof(ObligationDocumentsResponseType)),
        //                                      additionalParameters);

        //    XsltUtils.RunXsltAndWriteHtml("MVRANDAdapter", "GetObligationDocumentsRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("MVRANDAdapter", "GetObligationDocumentsResponse", result.Data.Response.XmlSerialize());

        //    using (StreamWriter outfile = new StreamWriter("MVRANDObligationDocumentsResponse.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }
        //    Assert.IsTrue(result.Data.Response.Status == 0);
        //}

        //[TestMethod]
        //public void SendPaymentNotificationTest()
        //{
        //    XmlDocument identityXML = new XmlDocument();
        //    identityXML.Load("../../eID.xml");
        //    MVRANDAdapter mvrandAdapter = new MVRANDAdapter();
        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters()
        //    {
        //        OrganizationUnit = "TL",
        //        EIDToken = identityXML.InnerXml,
        //        CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext() { LawReason = "Regixtest", EmployeeIdentifier = "tl_mmarinov" },
        //        SignResult = false,
        //        ReturnAccessMatrix = true
        //    };

        //    var result = mvrandAdapter.SendPaymentNotification(new SendPaymentNotificationRequestType() { TransactionNumber = "65456465", DocumentNumber = "210000", DocumentSeries = "K", DocumentType = SendNotificationDocumentType.TICKET, PaymentAmount = 70.00, PaymentDate = DateTime.Now },
        //                                      AccessMatrix.CreateForType(typeof(SendPaymentNotificationRequestType)),
        //                                      additionalParameters);

        //    XsltUtils.RunXsltAndWriteHtml("MVRANDAdapter", "SendPaymentNotificationRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("MVRANDAdapter", "SendPaymentNotificationResponse", result.Data.Response.XmlSerialize());

        //    using (StreamWriter outfile = new StreamWriter("MVRANDSendPaymentNotificationResponse.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }
        //    Assert.IsTrue(result.Data.Response.Status == 0);
        //}

        //[TestMethod]
        //public void GetObligationDocumentsByEGNTest()
        //{
        //    XmlDocument identityXML = new XmlDocument();
        //    identityXML.Load("../../eID.xml");
        //    MVRANDAdapter mvrandAdapter = new MVRANDAdapter();
        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters()
        //    {
        //        OrganizationUnit = "TL",
        //        EIDToken = identityXML.InnerXml,
        //        CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext() { LawReason = "Regixtest", EmployeeIdentifier = "tl_mmarinov" },
        //        SignResult = false,
        //        ReturnAccessMatrix = true
        //    };

        //    var result = mvrandAdapter.GetObligationDocumentsByEGN(new GetObligationDocumentsByEGNRequestType() { EGN = "9703047087" },
        //                                      AccessMatrix.CreateForType(typeof(GetObligationDocumentsByEGNResponseType)),
        //                                      additionalParameters);

        //    XsltUtils.RunXsltAndWriteHtml("MVRANDAdapter", "GetObligationDocumentsByEGNRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("MVRANDAdapter", "GetObligationDocumentsByEGNResponse", result.Data.Response.XmlSerialize());

        //    using (StreamWriter outfile = new StreamWriter("MVRANDGetObligationDocumentsByEGNResponse.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }
        //    Assert.IsTrue(result.Data.Response.Status == 0);
        //}

        //[TestMethod]
        //public void GetObligationDocumentsByLicenceNumTest()
        //{
        //    XmlDocument identityXML = new XmlDocument();
        //    identityXML.Load("../../eID.xml");
        //    MVRANDAdapter mvrandAdapter = new MVRANDAdapter();
        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters()
        //    {
        //        OrganizationUnit = "TL",
        //        EIDToken = identityXML.InnerXml,
        //        CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext() { LawReason = "Regixtest", EmployeeIdentifier = "tl_mmarinov" },
        //        SignResult = false,
        //        ReturnAccessMatrix = true
        //    };

        //    var result = mvrandAdapter.GetObligationDocumentsByLicenceNum(new GetObligationDocumentsByLicenceNumRequestType() { EGN = "1111111110", LicenceNum = "580415742" },
        //                                      AccessMatrix.CreateForType(typeof(GetObligationDocumentsByLicenceNumResponseType)),
        //                                      additionalParameters);

        //    XsltUtils.RunXsltAndWriteHtml("MVRANDAdapter", "GetObligationDocumentsByLicenceNumRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("MVRANDAdapter", "GetObligationDocumentsByLicenceNumResponse", result.Data.Response.XmlSerialize());

        //    using (StreamWriter outfile = new StreamWriter("MVRANDGetObligationDocumentsByLicenceNum.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }
        //    Assert.IsTrue(result.Data.Response.Status == 0);
        //}
    }
}


