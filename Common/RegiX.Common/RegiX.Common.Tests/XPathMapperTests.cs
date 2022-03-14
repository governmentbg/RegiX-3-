//using System;
//using System.Collections.Generic;
//using System.Globalization;
//using System.Linq;
//using System.Text;
//using System.Xml;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using TechnoLogica.RegiX.Common.ObjectMapping;
//using TechnoLogica.RegiX.NoiROAdapter;

//namespace RegiX.CommonTests
//{
//    [TestClass]
//    public class XPathMapperTests
//    {
//        [TestMethod]
//        public void Test()
//        {
//            var accessMatrix = AccessMatrix.CreateForType(typeof(POVNVEDResponseType));
//            var mapper = new XPathMapper<POVNVEDResponseType>(accessMatrix);

//            mapper.AddPropertyMap(p => p.Identifier, "/root/egn");
//            mapper.AddPropertyMap(p => p.IdentifierType, "/root/flag_egn");
//            mapper.AddPropertyMap(p => p.Names, "/root/egn_names");
//            mapper.AddPropertyMap(p => p.MissingData, "/root/MissingData");            
//            mapper.AddCollectionMap(p => p.PaymentData, "/root/paymenta_data/benefit");
//            mapper.AddPropertyMap(p => p.PaymentData[0].BenefitAmount, "./benefit_amount", (o)=> Convert.ToDecimal(o, CultureInfo.InvariantCulture));
//            mapper.AddPropertyMap(p => p.PaymentData[0].BenefitDatePayment, "./benefit_date_payment", (o)=> DateTime.ParseExact(o.ToString(), "dd-mm-yyyy", null));
//            mapper.AddPropertyMap(p => p.PaymentData[0].BenefitMonth, "./benefit_month");
//            mapper.AddPropertyMap(p => p.PaymentData[0].BenefitType, "./benefit_type");
//            mapper.AddPropertyMap(p => p.PaymentData[0].BenefitYear, "./benefit_year");

//            POVNVEDResponseType result = new POVNVEDResponseType();
//            XmlDocument xmlDocument = new XmlDocument();
//            xmlDocument.Load("GetPOVNForPeriod.xml");
//            mapper.Map(xmlDocument, result);
//            Assert.IsNotNull(result);
//        }
//    }
//}
