using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoLogica.RegiX.Core
{
    public interface IAdapterResult
    {
        string Error { get; set; }
        bool HasError { get; set; }
        string Serialize();
    }
}
