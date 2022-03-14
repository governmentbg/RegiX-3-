using System.Xml;

namespace TechnoLogica.RegiX.MFANotariesAdapter.Helpers
{
    public class StringHelper
    {
        public static string RemoveXmlDeclaration(string xml, bool preserveWhitespace = false)
        {
            if (string.IsNullOrEmpty(xml))
            {
                return null;
            }

            XmlDocument doc = new XmlDocument();
            doc.PreserveWhitespace = preserveWhitespace;
            doc.LoadXml(xml);

            foreach (XmlNode node in doc)
            {
                if (node.NodeType == XmlNodeType.XmlDeclaration)
                {
                    doc.RemoveChild(node);
                    break;
                }
            }

            var result = doc.OuterXml.Trim();
            return result;
        }
    }
}
