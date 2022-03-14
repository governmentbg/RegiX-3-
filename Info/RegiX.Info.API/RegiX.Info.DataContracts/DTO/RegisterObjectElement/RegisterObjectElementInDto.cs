using System;
using System.Collections.Generic;
using System.Text;

namespace RegiX.Info.DataContracts.DTO.RegisterObjectElement
{
    public class RegisterObjectElementInDto
    {
        public decimal? RegisterObjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PathToRoot { get; set; }
    }
}
