using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.Utils;

namespace RegiX.Common.Tests
{
    [TestClass]
    public class AdapterAdditionalParametersTests
    {
        [TestMethod]
        public void ProcessingDataPropertyTest()
        {
            var ap = new AdapterAdditionalParameters();
            
            ap.ProcessingData.Add(
                new ProcessingDataEntry()
                {
                    Key = "Processor_key",
                    Value = new SomeObject() { SomeProp = "value" }.XmlSerialize().ToXmlElement()
                }
            );
            var serialized = ap.XmlSerialize();
            var deserialized = serialized.XmlDeserialize<AdapterAdditionalParameters>();
            Assert.IsTrue(deserialized.ProcessingData[0].Key == "Processor_key");
            Assert.IsTrue(deserialized.ProcessingData[0].Value.OuterXml.XmlDeserialize<SomeObject>().SomeProp == "value");
        }

        [TestMethod]
        public void ProcessingDataNotExistantPropertyTest()
        {
           var input = 
                @"<?xml version=""1.0""?>
                <AdapterAdditionalParameters xmlns:xsi =""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
                    <SignResult>false</SignResult>
                    <ReturnAccessMatrix>false</ReturnAccessMatrix>
                    <ApiServiceCallId>0</ApiServiceCallId>
                    <RequestProcessing/>
                    <ResponseProcessing/>
                    <ProcessingData1>
                        <ProcessingDataEntry>
                        <Key>Processor_key</Key>
                        <Value>
                            <SomeObject xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">          
                                <SomeProp>value</SomeProp>
                                </SomeObject>
                            </Value>
                            </ProcessingDataEntry>
                    </ProcessingData1>
                </AdapterAdditionalParameters>";
            var deserialized = input.XmlDeserialize<AdapterAdditionalParameters>();
            Assert.IsTrue(deserialized.ProcessingData.Count == 0);
        }

    }

    public class SomeObject
    {
        public string SomeProp { get; set; }
    }
}
