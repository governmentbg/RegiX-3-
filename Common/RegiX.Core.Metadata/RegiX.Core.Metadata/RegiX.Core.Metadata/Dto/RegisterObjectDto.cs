using System.Collections.Generic;

namespace RegiX.Core.Metadata.Dto
{
    public class RegisterObjectDto
    {
        public string Name { get; set; }

        public string FullName { get; set; }

        public string Description { get; set; }

        public IEnumerable<RegisterObjectElementDto> RegisterObjectElements { get; set; }
    }
}