using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoLogica.RegiX.MtEstiAdapter.Helpers
{
    internal class LidoLink
    {
        // Id на много-много връзката
        public object Id { get; set; }

        // Id на типа
        public object TypeId { get; set; }

        // Id на основния обект - ако съществува в select-a
        public object PrimaryId { get; set; }

        public bool IsUpdated { get; set; }
    }
}
