using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegiX.Info.API.Controllers;
using TechnoLogica.RegiX.ASPFosterParentsAdapter.APIService;
using TechnoLogica.RegiX.MtEstiAdapter.APIService;
using TechnoLogica.RegiX.Adapters.TestUtils;
using System.IO;
using System.Xml;
using System;

namespace RegiX.Info.API.Test
{
    [TestClass]
    public class RequestMetaDataTest : APITest<ASPFosterParentsAPI, IASPFosterParentsAPI>
    {
        //[TestMethod]
        //public void Get_AdapterWithMetatadataTest() 
        //{
        //    var service = new RequestMetadataController();
        //    var id =
        //        "TechnoLogica.RegiX.ASPFosterParentsAdapter.APIService.IASPFosterParentsAPI.SendRequestForFosterParents";
        //    var metadata = service.Get(id);
        //    Assert.AreNotEqual("---", metadata);
        //}

    }

    [TestClass]
    public class RequestMetaDataTest2 : APITest<MtEstiAPI, IMtEstiAPI>
    {
        //[TestMethod]
        //public void Get_AdapterWithOutMetatadataTest() 
        //{
        //    var service = new RequestMetadataController();
        //    var id =
        //        "TechnoLogica.RegiX.MtEstiAdapter.APIService.IMtEstiAPI.SendInfoForAccomodationRegister";
        //    var metadata = service.Get(id);

        //    Assert.AreEqual("---", metadata);
        //}
    }

    [TestClass]
    public class APITest
    {
        [TestMethod]
        public void TestStyleSheetAdd()
        {
            var xsdDocument = new XmlDocument();
            xsdDocument.LoadXml(File.ReadAllText(@"XMLSamples\RegiX.ASPFosterParentsAdapter\SendRequestForFosterParentsRequest.xml"));

            string styleSheetReference =
                $"type=\"text/xsl\" href=\"test/api/XSLT/whaterver.xslt\"";
            var styleSheetPI = xsdDocument.CreateProcessingInstruction("xml-stylesheet", styleSheetReference);
            if (xsdDocument.FirstChild is XmlDeclaration)
            {
                xsdDocument.InsertAfter(styleSheetPI, xsdDocument.FirstChild);
            }
            else
            {
                xsdDocument.InsertBefore(styleSheetPI, xsdDocument.FirstChild);
            }
            Console.WriteLine(xsdDocument.OuterXml);
        }
        [TestMethod]
        public void TestStyleSheetAddFirst()
        {
            var xsdDocument = new XmlDocument();
            xsdDocument.LoadXml("<Test></Test>");

            string styleSheetReference =
                $"type=\"text/xsl\" href=\"test/api/XSLT/whaterver.xslt\"";
            var styleSheetPI = xsdDocument.CreateProcessingInstruction("xml-stylesheet", styleSheetReference);
            if (xsdDocument.FirstChild is XmlDeclaration)
            {
                xsdDocument.InsertAfter(styleSheetPI, xsdDocument.FirstChild);
            }
            else
            {
                xsdDocument.InsertBefore(styleSheetPI, xsdDocument.FirstChild);
            }
            Console.WriteLine(xsdDocument.OuterXml);
        }

    }
}



