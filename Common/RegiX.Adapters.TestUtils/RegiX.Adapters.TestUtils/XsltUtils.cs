using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace TechnoLogica.RegiX.Common.Utils
{
    public static class XsltUtils
    {
        /// <summary>
        /// Прилага xslt трансформация върху подадения xml и записва резултата като html файл.
        /// </summary>
        /// <param name="adapterProjectName">Име на проектната папка на адаптера (без префикса RegiX.)</param>
        /// <param name="xsltFileName">Име на xslt файла от ../XmlSchemas/Transformations директорията</param>
        /// <param name="xml">xml, който ще се трансформира</param>
        public static void RunXsltAndWriteHtml(string adapterProjectName, string xsltFileName, string xml)
        {
            string adapterTransformationFolder = GetAdapterFolderName(adapterProjectName);
            string xslt = ReadFileContent(Path.Combine(adapterTransformationFolder, xsltFileName + ".xslt"));
            string html = XmlTransform(xslt, xml);
            html = GetHtmlBody(html);

            string htmlContainerTemplate = "<html><head></head><body><div>{0}</div></body></html>";
            html = String.Format(htmlContainerTemplate, html);

            WriteFile(html, xsltFileName + ".html");
            WriteFile(xml, xsltFileName + ".xml");
        }

        public static string GetAdapterFolderName(string adapterProjectName)
        {
            var folderName = "RegiX." + adapterProjectName;
            string testDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string regixDirectory = Path.Combine(testDirectory, "..\\..\\");
            string result = Path.Combine(regixDirectory, folderName, "XMLSchemas", folderName, "Transformations");
            return result;
        }

        public static string GetHtmlBody(string html)
        {
            string htmlBody = html;

            RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.Singleline;
            Regex regx = new Regex("<body>(?<theBody>.*)</body>", options);

            Match match = regx.Match(html);

            if (match.Success)
            {
                htmlBody = match.Groups["theBody"].Value;
            }

            return htmlBody;
        }

        public static string ReadFileContent(string path)
        {
            string fileTextContent = string.Empty;
            using (StreamReader streamReader = new StreamReader(path, Encoding.UTF8))
            {
                fileTextContent = streamReader.ReadToEnd();
            }
            return fileTextContent;
        }

        public static void WriteFile(string content, string fileName)
        {
            using (StreamWriter outfile = new StreamWriter(fileName, false, System.Text.Encoding.UTF8))
            {
                outfile.Write(content);
            }
        }

        public static string XmlTransform(string transformationContent, string documentToTransform)
        {
            StringBuilder resultSb;
            XslCompiledTransform xslt = new XslCompiledTransform();


            using (var stringReader = new StringReader(transformationContent))
            using (var reader = XmlReader.Create(stringReader))
            {
                xslt.Load(reader);
            }

            XPathNavigator xmlDocumentToTransform;
            using (var stringReader = new StringReader(documentToTransform))
            {
                xmlDocumentToTransform = new XPathDocument(stringReader).CreateNavigator();
            }

            resultSb = new StringBuilder();
            using (var sw = new StringWriter(resultSb))
            using (var writer = new XmlTextWriter(sw))
            {
                writer.Formatting = Formatting.None;
                xslt.Transform(xmlDocumentToTransform, null, writer, null);
            }

            return resultSb.ToString();
        }
    }
}
