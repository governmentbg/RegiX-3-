using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoLogica.RegiX.Common.Utils;

namespace TechnoLogica.RegiX.Core
{
    public class AdapterResult<R> : IAdapterResult
        where R : class
    {
        public R Result { get; set; }
        public string Error { get; set; }
        public bool HasError { get; set; }

        public string Serialize()
        {
            return Result.XmlSerialize();
        }
    }
}
