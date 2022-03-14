using System.IO;
using System.Xml;
using System.Xml.Xsl;

namespace TechnoLogica.RegiX.Client.API.Utils
{
    public class XsltUtils
    {
        public static string TransformXml(string xml, string xslt)
        {
            var transformation = new XslCompiledTransform();
            using (var xmlReader = XmlReader.Create(new StringReader(xslt)))
            {
                transformation.Load(xmlReader);
            }

            using (var xmlReader = XmlReader.Create(new StringReader(xml)))
            using (Stream stream = new MemoryStream())
            {
                transformation.Transform(xmlReader, new XsltArgumentList(), stream);
                stream.Position = 0;

                using (var reader = new StreamReader(stream))
                {
                    string transformedResult = reader.ReadToEnd();
                    return transformedResult;
                }
            }
        }
    }
}
