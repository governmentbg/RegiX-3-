using System;
using System.Collections.Generic;
using System.Text;
using TechnoLogica.API.DataContracts;

namespace RegiX.Info.DataContracts.DTO.RegisterObjectElement
{
    public class RegisterObjectElementOutDto
    {
        public decimal Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PathToRoot { get; set; }
        public DisplayValue RegisterObject { get; set; }
    }
}
