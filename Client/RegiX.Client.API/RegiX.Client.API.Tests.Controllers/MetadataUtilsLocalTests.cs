using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TechnoLogica.RegiX.Client.Repositories;
using TechnoLogica.RegiX.Common.Metadata.AdapterOperations;
using TechnoLogica.RegiX.Common.Utils;

namespace TechnoLogica.RegiX.Client.API.Tests.Controllers
{
    [TestClass]
    public class MetadataUtilsLocalTests
    {
        string adapterOperation = File.ReadAllText("DAEUOperationMetaData.xml");
        string adapterOperationWithArray = File.ReadAllText("SendNotaryDocuments.xml");

        [TestMethod]
        public void Test()
        {
            Mock<IUserContext> uc = new Mock<IUserContext>();
            uc.SetupGet(uc => uc.PublicUserIdentifier).Returns("8309081361");
            uc.SetupGet(uc => uc.PublicUserIdentifierType).Returns("EGN");
            uc.SetupGet(uc => uc.IsPublic).Returns(true);
            var ucObject = uc.Object;
            var xml = MetadataUtilsLocal.CreateXML(ucObject,
                new Newtonsoft.Json.Linq.JObject(
                    new JProperty("DateFrom", "2020-09-21T21:00:00.000Z"),
                    new JProperty("DateTo", "2020-09-23T21:00:00.000Z"),
                    //new JProperty("Identifier", "xxxxx"),
                    new JProperty("IdentifierType", "EGN")
                ),
                adapterOperation.XmlDeserialize<AdapterOperation>()
            );
            Console.WriteLine(xml.XmlSerialize());
        }

        [TestMethod]
        public void Test3()
        {
            string adapterOperation = File.ReadAllText("GetPensionTypeAndAmountReport.xml");
            Mock<IUserContext> uc = new Mock<IUserContext>();
            uc.SetupGet(uc => uc.PublicUserIdentifier).Returns("8309081361");
            uc.SetupGet(uc => uc.PublicUserIdentifierType).Returns("EGN");
            uc.SetupGet(uc => uc.IsPublic).Returns(true);
            var ucObject = uc.Object;
            var xml = MetadataUtilsLocal.CreateXML(ucObject,
                new Newtonsoft.Json.Linq.JObject(
                    new JProperty("Month",
                        new Newtonsoft.Json.Linq.JObject() {
                                new JProperty("Month", "--01"),
                                new JProperty("Year", "2020")
                            }),
                    new JProperty("Identifier", "8309081361"),
                    new JProperty("IdentifierType", "EGN")
                ),
                adapterOperation.XmlDeserialize<AdapterOperation>()
            );
            Console.WriteLine(xml.XmlSerialize());
        }

        [TestMethod]
        public void Test2()
        {
            string adapterOperation = File.ReadAllText("GetPensionIncomeAmountReport.xml");
            Mock<IUserContext> uc = new Mock<IUserContext>();
            uc.SetupGet(uc => uc.PublicUserIdentifier).Returns("8309081361");
            uc.SetupGet(uc => uc.PublicUserIdentifierType).Returns("EGN");
            uc.SetupGet(uc => uc.IsPublic).Returns(true);
            var ucObject = uc.Object;
            var xml = MetadataUtilsLocal.CreateXML(ucObject,
                new JObject(
                    new JProperty("Period",
                        new JObject() { 
                            new JProperty(
                            "From", new JObject() {
                                new JProperty("Month", "--01"),
                                new JProperty("Year", "2020")
                            }),
                            new JProperty("To", new JObject() {
                                new JProperty("Month", "--05"),
                                new JProperty("Year", "2020")}
                            )
                        }),
                    new JProperty("Identifier", "8309081361"),
                    new JProperty("IdentifierType", "EGN")
                ),
                adapterOperation.XmlDeserialize<AdapterOperation>()
            );
            Console.WriteLine(xml.XmlSerialize());
        }

        [TestMethod]
        public void TestArray()
        {
            Mock<IUserContext> uc = new Mock<IUserContext>();
            uc.SetupGet(uc => uc.PublicUserIdentifier).Returns("8309081361");
            uc.SetupGet(uc => uc.PublicUserIdentifierType).Returns("EGN");
            uc.SetupGet(uc => uc.IsPublic).Returns(true);
            var ucObject = uc.Object;
            var xml = MetadataUtilsLocal.CreateXML(ucObject,
                new Newtonsoft.Json.Linq.JObject(
                    new JProperty("AuthenticationDate", "2020-09-21T21:00:00.000Z"),
                    new JProperty("AuthenticationNumber", "AuthenticationNumber"),
                    new JProperty("AuthenticationType", "AuthenticationType"),
                    new JProperty("ConsulCode", "ConsulCode"),
                    new JProperty("Documents", 
                        new JObject() { 
                            new JProperty("Document_0",
                                new JObject(){
                                    new JProperty("Content", "UjBsR09EbGhjZ0dTQUxNQUFBUUNBRU1tQ1p0dU1GUXhEUzhi"),
                                    new JProperty("FileName", "FileName.pdf")
                                }
                            ),
                            new JProperty("Document_2",
                                new JObject(){
                                    new JProperty("Content", "UjBsR09EbGhjZ0dTQUxNQUFBUUNBRU1tQ1p0dU1GUXhEUzhi"),
                                    new JProperty("FileName", "FileName.pdf")
                                }
                            )
                        }

                    )
                ),
                adapterOperationWithArray.XmlDeserialize<AdapterOperation>()
            );
            Console.WriteLine(xml.XmlSerialize());
        }
    }
}
