#region Namespaces
using System;
using System.Threading;
using System.Resources;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Runtime.Serialization;
using System.Reflection;
using System.Diagnostics;
#endregion

namespace Technologica.WcfCustom
{
    /// <summary>
    /// Thread safe storage of the XElement
    /// </summary>
    public class XmlDocumentationCache : Dictionary<string, XElement>
    {
        public ReaderWriterLock rwl = new ReaderWriterLock();
    }

    /// <summary>
    /// Helper class for handling C# Xml Documentation
    /// </summary>
    public class XmlDocumentation
    {
        static XmlDocumentationCache _storage = new XmlDocumentationCache();

        #region Load

        public static string Load(XmlElement wsdlDocumentElement, Type clrType, DocumentationAttribute wsdlDocumentation)
        {
            if (wsdlDocumentation != null)
            {
                if (wsdlDocumentElement != null )//&& wsdlDocumentation.ExportXmlDoc)
                {
                    XElement element = Load(string.Concat("T:", clrType.FullName), clrType);
                    if (element != null)
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(element.ToString());
                        foreach (XmlNode node in doc.DocumentElement.ChildNodes)
                        {
                            wsdlDocumentElement.AppendChild(wsdlDocumentElement.OwnerDocument.ImportNode(node, true));
                        }
                    }
                }
                return wsdlDocumentation.Documentation;
            }
            return null;
        }

        public static string Load(XmlElement wsdlDocumentElement, MemberInfo memberInfo, DocumentationAttribute wsdlDocumentation)
        {
            if (wsdlDocumentation != null)
            {
                if (wsdlDocumentElement != null)// && wsdlDocumentation.ExportXmlDoc)
                {
                    XElement element = Load(CreateMemberName(memberInfo), memberInfo.DeclaringType);
                    if (element != null)
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(element.ToString());
                        foreach (XmlNode node in doc.DocumentElement.ChildNodes)
                        {
                            wsdlDocumentElement.AppendChild(wsdlDocumentElement.OwnerDocument.ImportNode(node, true));
                        }
                    }
                }
                return wsdlDocumentation.Documentation;
            }
            return null;
        }

        public static XElement Load(string memberName, Type type)
        {
            XElement member = null;
            try
            {
                if (!string.IsNullOrEmpty(memberName) && type != null)
                {
                    XElement doc = GetXmlDocument(type);
                    if (doc != null)
                    {
                        member = doc.Descendants("member").FirstOrDefault(e => e.Attribute("name").Value == memberName);
                        Trace.WriteLine(string.Format("memberName={0}, type={1}, member=\r\n{2}", memberName, type.FullName, member));
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(string.Format("Failed for memberName={0}, type={1}; error={2}", memberName, type.FullName, ex.Message));
            }
            if (member != null)
            {
                // copy and remove attribute 'name'
                XElement memberclone = new XElement(member);
                memberclone.Attribute("name").Remove();
                return memberclone;
            }
            return member;
        }

        public static XElement LoadStartsWith(object schemaElement, string compleXTypeName)//string name, Type type)
        {
            string elementName = string.Format(".{0}", ((XmlSchemaElement)schemaElement).QualifiedName.Name); ;
            if (!string.IsNullOrEmpty(compleXTypeName))
            {
                elementName = string.Format(".{0}{1}", compleXTypeName, elementName);
            }
            XElement member = null;
            try
            {
                if (!string.IsNullOrEmpty(elementName))
                {
                    XElement doc = GetXmlDocument();
                    if (doc != null)
                    {
                        string prefix = string.Empty;
                        if (schemaElement is XmlSchemaElement)
                        {
                            prefix = "P:";
                        }
                        if (schemaElement is XmlSchemaComplexType)
                        {
                            prefix = "T:";
                        }
                        member = doc.Descendants("member").FirstOrDefault(e => e.Attribute("name").Value.StartsWith(prefix) && e.Attribute("name").Value.EndsWith(elementName));

                        Trace.WriteLine(string.Format("memberName={0},  member=\r\n{2}", elementName, compleXTypeName, member));
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(string.Format("Failed for memberName={0}, type={1}; error={2}", elementName, compleXTypeName, ex.Message));
            }
            if (member != null)
            {
                // copy and remove attribute 'name'
                XElement memberclone = new XElement(member);
                memberclone.Attribute("name").Remove();
                return memberclone;
            }
            return member;
        }

        #endregion

        #region GetXmlDocument

        private static XElement GetXmlDocument()
        {
            return _storage.FirstOrDefault().Value;
        }

        private static XElement GetXmlDocument(Type type)
        {
            XElement doc = null;
            string xmldocpath = Path.ChangeExtension(type.Assembly.CodeBase, "XML");

            try
            {
                _storage.rwl.AcquireReaderLock(TimeSpan.FromSeconds(10));
                doc = _storage.FirstOrDefault(e => e.Key == xmldocpath).Value;
                if (doc == null)
                {
                    try
                    {
                        _storage.rwl.UpgradeToWriterLock(TimeSpan.FromSeconds(10));
                        doc = XElement.Load(xmldocpath);
                        _storage.Add(xmldocpath, doc);
                        Trace.WriteLine(xmldocpath);
                    }
                    catch
                    {

                    }
                }
            }
            finally
            {
                _storage.rwl.ReleaseLock();
            }
            return doc;
        }
        #endregion

        #region CreateMemberName

        public static string CreateMemberName(MemberInfo mi)
        {
            string memberName = string.Empty;
            switch (mi.MemberType)
            {
                case MemberTypes.TypeInfo:
                case MemberTypes.NestedType:
                    memberName = string.Format("T:{0}", ((Type)mi).FullName);
                    break;

                case MemberTypes.Property:
                    memberName = string.Format("P:{0}.{1}", mi.ReflectedType.FullName, mi.Name);
                    break;

                case MemberTypes.Field:
                    memberName = string.Format("F:{0}.{1}", mi.ReflectedType.FullName, mi.Name);
                    break;

                case MemberTypes.Method:
                    MethodInfo methodInfo = mi as MethodInfo;
                    ParameterInfo[] parameters = methodInfo.GetParameters();
                    List<string> parms = new List<string>();
                    foreach (ParameterInfo pi in parameters)
                    {
                        parms.Add(pi.ParameterType.ToString().Replace('&', '@'));
                    }
                    memberName = string.Format("M:{0}.{1}({2})", mi.DeclaringType.FullName, mi.Name, String.Join(",", parms.ToArray()));
                    break;
            }
            return memberName;
        }

        #endregion
    }
}
