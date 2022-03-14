using System.Linq;
using System.Xml.Linq;
using TechnoLogica.RegiX.AdapterConsole.DataContracts.DTO;

namespace TechnoLogica.RegiX.AdapterConsole.API.Controllers.Helpers
{
    public static class XmlToDic
    {
        public static ParamsValues[] ConvertXmlToDic(string xml)
        {
            if (xml == null) return new ParamsValues[0];
            var doc = XDocument.Parse(xml);
            var result = TransformXmlToDic(doc.Root);

            return result;
        }

        private static ParamsValues[] TransformXmlToDic(XElement element)
        {
            var result = element.Elements().Select(
                e => new ParamsValues
                {
                    Name = e.Name.LocalName.ToString(),
                    Value = e.Value.ToString()
                }
            ).ToArray();
            return result;
        }
    }
}
