using System.Collections.Generic;

namespace TechnoLogica.RegiX.Core.Data.Interfaces.Models
{
    public class Parameter
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Parameter> Children { get; set; }
    }
}