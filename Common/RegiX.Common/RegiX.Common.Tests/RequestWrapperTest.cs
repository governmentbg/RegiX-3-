using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Common.Utils;

namespace RegiX.Common.Tests
{
    [TestClass]
    public class RequestWrapperTest
    {
        [TestMethod]
        public void Serialize()
        {
            var result = 
                (new ReqWrap()
                {
                }).XmlSerialize();
        }
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void SerializeFail()
        {
            var result =
                (new ReqWrapFail()
                {
                }).XmlSerialize();
        }
    }

    [XmlRoot("ReqWrap", Namespace = "http://egov.bg/RegiX/DataContracts/RequestWrapper")]
    [XmlType(Namespace = "http://egov.bg/RegiX/DataContracts/RequestWrapper")]
    public class ReqWrap
    {
        [XmlElement]
        public ServReq ServReq { get; set; }
        
        [XmlElement]
        public XmlElement AddParams { get; set; }
    }
    [XmlRoot("ReqWrapFail", Namespace = "http://egov.bg/RegiX/DataContracts/RequestWrapper")]
    [XmlType(Namespace = "http://egov.bg/RegiX/DataContracts/RequestWrapper")]
    public class ReqWrapFail
    {
        [XmlElement]
        public ServReq ServReq { get; set; }

        [XmlElement]
        public AddParams AddParams { get; set; }
    }

    [Serializable]
    public class AddParams
    {
        public AddParams()
        {
        }

        public ResponseProcessing ResponseProcessing { get; set; }
    }

    /// <summary>
    /// Обект за заявяка за изпълнение на операция
    /// </summary>
    [XmlRoot("ServReq", Namespace = "http://egov.bg/RegiX/SignedData")]
    [XmlType(Namespace = "http://egov.bg/RegiX/SignedData")]
    [Serializable]
    public class ServReq
    {

        /// <summary>
        /// Начин на обработка на резултата
        /// </summary>
        [XmlElement]
        public ResponseProcessing ResponseProcessing { get; set; }
    }
    }
