using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechnoLogica.RegiX.Adapters.Common.DataContracts;
using TechnoLogica.RegiX.Adapters.Common.Interfaces;

namespace TechnoLogica.RegiX.Adapters.WCFAdapterHost.MessageInspector
{
    public class NOPLogger : IAdapterLogger
    {
        public void LogRecord(string operationFullName, AdapterLogRecordType logRecord)
        {
        }
    }
}