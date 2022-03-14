using System.IO;
using System.Text;

namespace RegiX.Info.API.Helpers
{
    public class ZipItem
    {
        public string Name { get; set; }
        public Stream Content { get; set; }
        public string Extension { get; set; }

        public ZipItem(string name, Stream content)
        {
            this.Name = name;
            this.Content = content;
        }
        public ZipItem(string name, string contentStr, string Extension, Encoding encoding)
        {
            // convert string to stream
            var byteArray = encoding.GetBytes(contentStr);
            var memoryStream = new MemoryStream(byteArray);
            this.Name = name;
            this.Content = memoryStream;
            this.Extension = Extension;
        }
    }


}
