using System.Collections.Generic;

namespace TechnoLogica.RegiX.Core.Data.Interfaces.Models
{
    public class Administration
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string IdentificationCode { get; set; }
        public string DisplayName { get; set; }
        public string Acronym { get; set; }
        public string OID { get; set; }
        public IEnumerable<Register> Registers { get; set; }
    }
}