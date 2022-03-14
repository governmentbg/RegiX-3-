using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.Metadata;
using TechnoLogica.RegiX.Common.Metadata.AdapterOperations;
using TechnoLogica.RegiX.Common.Utils;

namespace TechnoLogica.RegiX.Adapters.TestUtils
{
    public abstract class APITest<T, I>
        where T : class
        where I : IAPIService
    {
        public APITest()
        {
            AggregateCatalog catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(T).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(APITest<,>).Assembly));
            CompositionContainer result = new CompositionContainer(catalog, true);
            result.ComposeExportedValue(result);
            Composition.CompositionContainer = result;
        }

        private static IAPIService GetAPIService()
        {
            return Composition.
                   CompositionContainer.
                   GetExportedValue<IAPIService>(typeof(I).FullName);
        }

        public static IEnumerable<object[]> GetOperations()
        {
            return typeof(I).GetMethods().Select(m => new object[] { m.Name });
        }

        [DataTestMethod]
        [DynamicData(nameof(GetOperations), DynamicDataSourceType.Method)]
        public void GetRequestXSDTest(string operationName)
        {
            Assert.IsFalse(string.IsNullOrEmpty(GetAPIService().GetRequestXSD(operationName)));
        }

        void MatchSampleAndXSD(string operationName, Func<IAPIService, string, string> xsdFunc, Func<IAPIService, string, string> sampleFunc)
        {
            string xsd = xsdFunc.Invoke(GetAPIService(), operationName);
            string sampleXML = sampleFunc.Invoke(GetAPIService(), operationName);

            XmlSchemaSet schemas = new XmlSchemaSet();
            foreach (string commonSchemaXSD in GetAPIService().GetCommonXSD(operationName))
            {
                XmlTextReader commonReader = new XmlTextReader(new System.IO.StringReader(commonSchemaXSD));
                XmlSchema commonSchema = XmlSchema.Read(commonReader, ValidationCallback);
                schemas.Add(commonSchema);
            }
            XmlDocument document = new XmlDocument();
            document.LoadXml(sampleXML);
            string namesapceUI = document.DocumentElement.NamespaceURI;

            XmlTextReader xsdReader = new XmlTextReader(new System.IO.StringReader(xsd));
            schemas.Add(namesapceUI, xsdReader);
            schemas.Compile();
            document.Schemas = schemas;

            string msg = "";
            document.Validate((o, e) => {
                msg += e.Message + Environment.NewLine;
            });
            Assert.IsTrue(string.IsNullOrEmpty(msg), msg);
        }

        static void ValidationCallback(object sender, ValidationEventArgs args)
        {
            if (args.Severity == XmlSeverityType.Warning)
            {
                Assert.Fail($"Warning while processing XSD: {args.Message}");
            }
            else if (args.Severity == XmlSeverityType.Error)
            {
                Assert.Fail($"Error while processing XSD: {args.Message}");
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(GetOperations), DynamicDataSourceType.Method)]
        public void MatchSampleRequestAndXSDTest(string operationName)
        {
            MatchSampleAndXSD(operationName, (i, op) => i.GetRequestXSD(op), (i, op) => i.GetSampleRequest(op));
        }

        [DataTestMethod]
        [DynamicData(nameof(GetOperations), DynamicDataSourceType.Method)]
        public void MatchSampleResponseAndXSDTest(string operationName)
        {
            MatchSampleAndXSD(operationName, (i, op) => i.GetResponseXSD(op), (i, op) => i.GetSampleResponse(op));
        }

        [DataTestMethod]
        [DynamicData(nameof(GetOperations), DynamicDataSourceType.Method)]
        public void GetResponseXSDTest(string operationName)
        {
            Assert.IsFalse(string.IsNullOrEmpty(GetAPIService().GetResponseXSD(operationName)));
        }

        [DataTestMethod]
        [DynamicData(nameof(GetOperations), DynamicDataSourceType.Method)]
        public virtual void GetMetaDataXMLTest(string operationName)
        {
            Assert.IsFalse(string.IsNullOrEmpty(GetAPIService().GetMetaDataXML(operationName)));
        }

        [DataTestMethod]
        [DynamicData(nameof(GetOperations), DynamicDataSourceType.Method)]
        public void GetSampleRequestTest(string operationName)
        {
            Assert.IsFalse(string.IsNullOrEmpty(GetAPIService().GetSampleRequest(operationName)));
        }

        [DataTestMethod]
        [DynamicData(nameof(GetOperations), DynamicDataSourceType.Method)]
        public void GetSampleResponseTest(string operationName)
        {
            Assert.IsFalse(string.IsNullOrEmpty(GetAPIService().GetSampleResponse(operationName)));
        }

        [DataTestMethod]
        [DynamicData(nameof(GetOperations), DynamicDataSourceType.Method)]
        public virtual void GetRequestXsltTest(string operationName)
        {
            Assert.IsFalse(string.IsNullOrEmpty(GetAPIService().GetRequestXslt(operationName)));
        }
        [DataTestMethod]
        [DynamicData(nameof(GetOperations), DynamicDataSourceType.Method)]
        public virtual void GetResponseXsltTest(string operationName)
        {
            Assert.IsFalse(string.IsNullOrEmpty(GetAPIService().GetResponseXslt(operationName)));

        }

        [DataTestMethod]
        [DynamicData(nameof(GetOperations), DynamicDataSourceType.Method)]
        public virtual void CreateSampleRequestUsingMetadataTest(string operationName)
        {
            string metadata = GetAPIService().GetMetaDataXML(operationName);
            //if there is operation with no metadata GetMetaDataXML will return "---"
            if (metadata == "---")
            {
                Assert.IsTrue(true);
                return;
            }
            string sampleRequest = GetAPIService().GetSampleRequest(operationName);
           
            //Prepare for comparison
            var sampleRequestElement = PrepareForComparison(sampleRequest);

            var serializer = new XmlSerializer(typeof(AdapterOperation));

            AdapterOperation operationMetaData = new AdapterOperation();
            using (var reader = new StringReader(metadata))
            {
                operationMetaData = (AdapterOperation)serializer.Deserialize(reader);
            }

            var requestType = GetAPIService().GetType().GetMethod(operationName).ReturnType.GetGenericArguments()[0];

            List<PropertyInfo> dateTimeProperties = requestType.GetProperties()
                .Where(x => x.PropertyType == typeof(DateTime) || x.PropertyType == typeof(DateTime?)).ToList();
            var dateTimePropertyNames = dateTimeProperties.Select(x => x.Name).ToList();

            bool isDateTimePropertiesFound = false;
            if (dateTimeProperties.Count > 0 )
            {
                //"T00:00:00" is removed from "2017-06-06T00:00:00" for deserilization
                sampleRequestElement = ChangedDateTypesForComparison(sampleRequestElement, dateTimeProperties);
                isDateTimePropertiesFound = true;
            }

            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.Converters.Add(new StringEnumConverter());

            var dataObject = sampleRequestElement.XmlDeserialize(requestType);
            var jsonObject = JObject.FromObject(dataObject, JsonSerializer.Create(serializerSettings));
           
            string result = MetadataUtils.CreateXML(jsonObject, operationMetaData).OuterXml;

            if (isDateTimePropertiesFound)
            {
                //"T00:00:00" is removed for comparison of the sampleRequestElement and result
                result = ChangedDateTypesForComparison(result, dateTimeProperties);
            }

            Assert.AreEqual(sampleRequestElement, result);
            //TODO: T00:00:00 is not included in the comparison
        }

        /// <summary>
        /// Changes all dates in the xml document from "2017-06-06T00:00:00" to this "2017-06-06" in order to pass the assert method
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="dateTimeProperties"></param>
        /// <returns></returns>
        private string ChangedDateTypesForComparison(string xml, List<PropertyInfo> dateTimeProperties)
        {
            if (string.IsNullOrEmpty(xml))
            {
                return xml;
            }

            var document = new XmlDocument();
            document.LoadXml(xml);

            foreach (var dateTimeProp in dateTimeProperties)
            {
                
                var elements = document.GetElementsByTagName(dateTimeProp.Name).Cast<XmlNode>();
                foreach (var item in elements)
                {
                    try
                    {
                        //2007-08-07 yyyy-MM-dd
                        var date = item.InnerText.Substring(0, 10);
                        item.InnerText = date;
                    }
                    catch (Exception e)
                    {
                      
                    }
                    
                }
            }

            var result = document.OuterXml;
            return result;
        }
        private string PrepareForComparison(string xml)
        {
            if (string.IsNullOrEmpty(xml))
            {
                return xml;
            }
            
            var document = new XmlDocument();
            document.LoadXml(xml);

            //removes xml declerations like <?xml version="1.0" encoding="UTF-8"?>, <?xml version="1.0"?>
            if (document.FirstChild.NodeType == XmlNodeType.XmlDeclaration)
            {
                document.RemoveChild(document.FirstChild);
            }

            //removes attributes from root element 
            document.DocumentElement.RemoveAttribute("xmlns:xsd");
            document.DocumentElement.RemoveAttribute("xmlns:xsi");
            document.DocumentElement.RemoveAttribute("xsi:schemaLocation");

            //removes comments
            XmlNodeList list = document.SelectNodes("//comment()");

            foreach (XmlNode node in list)
            {
                node.ParentNode.RemoveChild(node);
            }

            var result = document.OuterXml;
            return result;
        }
    }
}
