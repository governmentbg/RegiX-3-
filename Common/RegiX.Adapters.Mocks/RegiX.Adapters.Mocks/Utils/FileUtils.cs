using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace RegiX.Adapters.Mocks.Utils
{
    public static class FileUtils
    {
        /// <summary>
        /// Serializes string and convert it to object of given type
        /// </summary>
        /// <param name="filename">name of the file which will be read from</param>
        /// <param name="type">the type to which you want to serialize</param>
        /// <returns>the result object parsed from the file</returns>
        public static object ReadXml(string filename, Type type)
        {
            string xml = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + filename);
            using (XmlReader reader = XmlReader.Create(new StringReader(xml)))
            {
                reader.MoveToContent();
                var obj = new XmlSerializer(type).Deserialize(reader);
                return obj;
            }
        }
    }
}
