using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TechnoLogica.Common
{
    /// <summary>
    /// Helper utility for managing xml documents. Should be used as string extension methods.
    /// </summary>
    public class XmlUtils
    {
        /// <summary>
        /// Serialize object to XML
        /// </summary>
        /// <typeparam name="T">Type of the object to serialize</typeparam>
        /// <param name="model">Object to serialize</param>
        /// <param name="ns">XML namespaces</param>
        /// <returns>Serialized object</returns>
        public static string SerializeToXml<T>(T model, XmlSerializerNamespaces ns = null)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            StringBuilder builder = new StringBuilder();

            using (Utf8StringWriter writer = new Utf8StringWriter(builder))
            {
                serializer.Serialize(writer, model, ns);
            }

            string result = builder.ToString();
            return result;
        }

        /// <summary>
        /// Deserialize object from xml
        /// </summary>
        /// <typeparam name="T">Type of the object</typeparam>
        /// <param name="xml">XML serialized object</param>
        /// <returns>Deserialized object</returns>
        public static T DeserializeXml<T>(string xml) where T : class
        {
            if (string.IsNullOrEmpty(xml))
            {
                return null;
            }

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StringReader reader = new StringReader(xml))
            {
                T element = (T)serializer.Deserialize(reader);
                return element;
            }
        }

        /// <summary>
        /// Creates XMLElement from the provided xml string
        /// </summary>
        /// <param name="input">XML string</param>
        /// <param name="preserveWhitespaces">If whitespaces should be preserved</param>
        /// <param name="removeXmlTag">If the document tag should be removed</param>
        /// <returns>Result xml element</returns>
        public static XmlElement ToXmlElement(string input, bool preserveWhitespaces = false, bool removeXmlTag = true)
        {
            if (string.IsNullOrEmpty(input))
            {
                return null;
            }

            XmlDocument document = new XmlDocument();
            document.PreserveWhitespace = preserveWhitespaces;
            document.LoadXml(input);

            if (removeXmlTag && document.ChildNodes.Count > 1)
            {
                XmlElement element = document.ChildNodes[1] as XmlElement;
                return element;
            }

            return document.DocumentElement;
        }

        /// <summary>
        /// Beautifies the provided xml string
        /// </summary>
        /// <param name="xml">Source xml string to beautify</param>
        /// <param name="indentCharsCount">Number of ident chars</param>
        /// <returns>Beautified string</returns>
        public static string Beautify(string xml, int indentCharsCount = 4)
        {
            if (string.IsNullOrEmpty(xml))
            {
                return xml;
            }

            try
            {
                var newLine = Environment.NewLine;
                var doc = new XmlDocument();
                doc.LoadXml(xml);

                var sb = new StringBuilder();
                var settings = new XmlWriterSettings
                {
                    Indent = true,
                    IndentChars = new string(' ', indentCharsCount),
                    NewLineChars = newLine,
                    NewLineHandling = NewLineHandling.Replace,
                    OmitXmlDeclaration = true
                };

                using (XmlWriter writer = XmlWriter.Create(sb, settings))
                {
                    doc.Save(writer);
                }

                if (doc.FirstChild.NodeType == XmlNodeType.XmlDeclaration)
                {
                    // If contains xml tag, add it to result
                    sb.Insert(0, doc.FirstChild.OuterXml + newLine);
                }

                var result = sb.ToString();
                return result;
            }
            catch (Exception)
            {
                return xml;
            }
        }

        /// <summary>
        /// Checks the provided string for xml validity
        /// </summary>
        /// <param name="xml">XML string to check for validity</param>
        /// <returns>If the provided string is valid xml</returns>
        public static bool IsValidXml(string xml)
        {
            if (string.IsNullOrEmpty(xml))
            {
                return false;
            }

            try
            {
                XmlDocument document = new XmlDocument();
                document.LoadXml(xml);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
