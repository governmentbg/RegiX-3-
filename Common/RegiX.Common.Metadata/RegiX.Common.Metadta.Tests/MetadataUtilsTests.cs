using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using TechnoLogica.RegiX.Common.Metadata;
using TechnoLogica.RegiX.Common.Metadata.AdapterOperations;
using TechnoLogica.RegiX.Common.Utils;

namespace RegiX.Common.Tests
{
    [TestClass]
    public class MetadataUtilsTests
    {
        [TestMethod]
        public void CreateXMLTest()
        {
            ParameterInfo noiRPAAdapter1 = new ParameterInfo
            {
                ParameterName = "Period",
                IsRequired = false,
                IsXmlElement = true,
                OrderNumber = 2,
                IdentifierType = 5,
                ParameterType = new ParameterType
                {
                    Type = "Complex",

                },
                
            };

            ParameterInfo noiRPAAdapter2 = new ParameterInfo
            {
                ParameterName = "From",
                IsRequired = true,
                IsXmlElement = true,
                OrderNumber = 1,
                IdentifierType = 5,
                Namespace = "http://egov.bg/RegiX/NOI/RP",
                ParameterType = new ParameterType
                {
                    Type = "Complex",

                },

            };

            AdapterOperation adapterOperation = new AdapterOperation()
            {
                OperationName = "TechnoLogica.RegiX.MonStudentsAdapter.APIService.IMonStudentsAPI.GetHigherEduStudentByStatus",
                Code = "GetHigherEduStudentByStatus",
                RequestObjectName = "HigherEduStudentByStatusRequest",
                Namespace = "http://egov.bg/RegiX/MON/HigherEdu/HigherEduStudentByStatusRequest",
                IsActive = true,
                Parameters = new List<Parameter>
                {
                    new Parameter
                    {
                        ParameterInfo = noiRPAAdapter1,
                        ChildParamteters = new List<ParameterParameter>
                        {
                            new ParameterParameter()
                            {
                                ParameterInfo = noiRPAAdapter2,
                            },
                        }
                    },
                },
            };

            var jsonObject = new JsonResponse
            {
                Period = "1918" ,
                JsonChild = new JsonChild { From = "2007"}
            };
            //var result = MetadataUtils.CreateXML((JObject)JToken.FromObject(jsonObject), adapterOperation).OuterXml;
        }

        string adapterOperation = File.ReadAllText("DAEUOperationMetaData.xml");
        string adapterOperationWithArray = File.ReadAllText("SendNotaryDocuments.xml");

        [TestMethod]
        public void Test()
        {
            Mock<IUserContext> uc = new Mock<IUserContext>();
            uc.SetupGet(uc => uc.PublicUserIdentifier).Returns("8309087202");
            uc.SetupGet(uc => uc.PublicUserIdentifierType).Returns("EGN");
            uc.SetupGet(uc => uc.IsPublic).Returns(true);
            var ucObject = uc.Object;
            var xml = MetadataUtils.CreateXML(
                new JObject(
                    new JProperty("DateFrom", "2020-09-21T21:00:00.000Z"),
                    new JProperty("DateTo", "2020-09-23T21:00:00.000Z"),
                    //new JProperty("Identifier", "xxxxx"),
                    new JProperty("IdentifierType", "EGN")
                ),
                adapterOperation.XmlDeserialize<AdapterOperation>(),
                ucObject
            );
            Console.WriteLine(xml.XmlSerialize());
        }

        [TestMethod]
        public void Test3()
        {
            string adapterOperation = File.ReadAllText("GetPensionTypeAndAmountReport.xml");
            Mock<IUserContext> uc = new Mock<IUserContext>();
            uc.SetupGet(uc => uc.PublicUserIdentifier).Returns("8309087202");
            uc.SetupGet(uc => uc.PublicUserIdentifierType).Returns("EGN");
            uc.SetupGet(uc => uc.IsPublic).Returns(true);
            var ucObject = uc.Object;
            var xml = MetadataUtils.CreateXML(
                new Newtonsoft.Json.Linq.JObject(
                    new JProperty("Month",
                        new Newtonsoft.Json.Linq.JObject() {
                                new JProperty("Month", "--01"),
                                new JProperty("Year", "2020")
                            }),
                    new JProperty("Identifier", "8309087202"),
                    new JProperty("IdentifierType", "EGN")
                ),
                adapterOperation.XmlDeserialize<AdapterOperation>(),
                ucObject
            );
            Console.WriteLine(xml.XmlSerialize());
        }

        [TestMethod]
        public void Test2()
        {
            string adapterOperation = File.ReadAllText("GetPensionIncomeAmountReport.xml");
            Mock<IUserContext> uc = new Mock<IUserContext>();
            uc.SetupGet(uc => uc.PublicUserIdentifier).Returns("8309087202");
            uc.SetupGet(uc => uc.PublicUserIdentifierType).Returns("EGN");
            uc.SetupGet(uc => uc.IsPublic).Returns(true);
            var ucObject = uc.Object;
            var xml = MetadataUtils.CreateXML(
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
                    new JProperty("Identifier", "8309087202"),
                    new JProperty("IdentifierType", "EGN")
                ),
                adapterOperation.XmlDeserialize<AdapterOperation>(),
                ucObject
            );
            Console.WriteLine(xml.XmlSerialize());
        }

        [TestMethod]
        public void TestArray()
        {
            Mock<IUserContext> uc = new Mock<IUserContext>();
            uc.SetupGet(uc => uc.PublicUserIdentifier).Returns("8309087202");
            uc.SetupGet(uc => uc.PublicUserIdentifierType).Returns("EGN");
            uc.SetupGet(uc => uc.IsPublic).Returns(true);
            var ucObject = uc.Object;
            var xml = MetadataUtils.CreateXML(
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
                adapterOperationWithArray.XmlDeserialize<AdapterOperation>(),
                ucObject
            );
            Console.WriteLine(xml.XmlSerialize());
        }
    }

    public class JsonResponse
    {
        public string Period { get; set; }
        public JsonChild JsonChild { get; set; }
    }

    public class JsonChild
    {
        public string From { get; set; }
    }
}