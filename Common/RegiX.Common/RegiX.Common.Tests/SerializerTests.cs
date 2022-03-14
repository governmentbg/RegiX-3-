using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.Utils;
using TechnoLogica.RegiX.GraoBRAdapter;

namespace RegiX.Common.Tests
{
    [TestClass]
    public class SerializerTests
    { 
        [TestMethod]
        public void DataContractTests()
        {
            string response = File.ReadAllText("Response.txt");

            var input = new CommonSignedResponse<MarriageRequestType, MarriageResponseType>() { 
            Data = new DataContainer<MarriageRequestType, MarriageResponseType>()
            {
                Request = new MarriageRequestType() {  EGN = "asdfadf"},
                Response = new MarriageResponseType()
                {
                    DivorceDate =DateTime.Now,
                    DivorceDateSpecified = true
                }
            }
            };
            //{     Data = new DataContainer<string, string>()
            //     {
            //         Request = "request",
            //         Response = "resposne",
            //         Matrix = new DataAccessMatrix(AccessMatrix.CreateForType(typeof(string)), typeof(string))
            //     }, IsReady = false,
            //     VerificationCode = "something"
            // };
            var serialized = input.Serialize();

            //// serialized = serialized.Replace("TechnoLogica.RegiX.Common.DataContracts", "TechnoLogica.RegiX.Common.TransportObjects");

            var output = response.Deserialize<CommonSignedResponse<MarriageRequestType, MarriageResponseType>>();
        }
        [TestMethod]
        public void AdapterAdditionalParametersOldTest()
        {
            string response = File.ReadAllText("AdapterAdditionalParametersOld.xml");

            var restul = response.Deserialize<AdapterAdditionalParameters>();
        }
    }
}
