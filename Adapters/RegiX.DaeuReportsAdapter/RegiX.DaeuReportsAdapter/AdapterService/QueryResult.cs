using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoLogica.RegiX.DaeuReportsAdapter.AdapterService
{
    public class QueryResult
    {
        public APIServiceCall[] ApiServiceCalls { get; set; }
        public int MaxAllowedResults { get; set; }
        public long TotalResults { get; set; }
    }
}
