using System.Collections.Generic;

namespace RegiX.Core.Metadata.Dto
{
    public class AdapterDto
    {

        public string AdapterUrl { get; set; }

        public string Assembly { get; set; }

        public string BindingConfigName { get; set; }

        public string BindingType { get; set; }

        public string Contract { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public int Register { get; set; }

        public IEnumerable<AdapterOperationDto> AdapterOperations { get; set; }

        public IEnumerable<RegisterObjectDto> RegisterObjects { get; set; }


    }
}