using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnoLogica.RegiX.Adapters.Common.DataContracts;
using TechnoLogica.RegiX.Adapters.Common.Interfaces;

namespace TechnoLogica.RegiX.Adapters.NetCoreAdapterHost
{
    public class NOPAdapterLogger : IAdapterLogger
    {
        public void LogRecord(string operationFullName, AdapterLogRecordType logRecord)
        {
        }
    }
}
