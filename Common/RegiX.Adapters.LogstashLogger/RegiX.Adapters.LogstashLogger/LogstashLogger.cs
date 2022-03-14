using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks.Dataflow;
using TechnoLogica.RegiX.Adapters.Common.DataContracts;
using TechnoLogica.RegiX.Adapters.Common.Interfaces;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.Utils;

namespace TechnoLogica.RegiX.Adapters.LogstashLogger
{
    [Export(typeof(IAdapterLogger))]
    public class LogstashAdapterLogger : IAdapterLogger
    {
        private static readonly log4net.ILog Logger =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private string loggingAddress = String.Empty;

        public LogstashAdapterLogger()
        {
            loggingAddress = ConfigurationManager.AppSettings["LoggingAddress"];
            if (string.IsNullOrEmpty(loggingAddress))
            {
                Logger.Warn("Logging address not set!");
            }
        }

        public void LogRecord(string operationFullName, AdapterLogRecordType logRecord)
        {
            try
            {
                if (!string.IsNullOrEmpty(loggingAddress))
                {
                    UPLOAD_DATA.Post(new Tuple<string, AdapterLogRecordType>(loggingAddress + operationFullName, logRecord));
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Error while sending data to logstash:" + ex.Message);
                Logger.Error("Logstash - not logged entry:" + Environment.NewLine + logRecord.XmlSerialize());
            }
        }

        private static ActionBlock<Tuple<string, AdapterLogRecordType>> UPLOAD_DATA =
           new ActionBlock<Tuple<string, AdapterLogRecordType>>(
               async (data) =>
               {
                   bool error = false;
                   try
                   {
                       using ( HttpClient client = new HttpClient())
                       {
                           string serializedLog = data.Item2.XmlSerialize();
                           string address = data.Item1;
                           var content = new StringContent(serializedLog, Encoding.UTF8, "application/xml");
                           var response = await client.PostAsync(address, content);

                           if (!response.IsSuccessStatusCode)
                           {
                               Logger.Error("Logstash - status code:" + response.StatusCode);
                               error = true;
                           }
                       }
                   }
                   catch (Exception ex)
                   {
                       Logger.Error("Logstash - error: " + ex.Message);
                       error = true;
                   }
                   finally
                   {
                       if (error)
                       {
                           Logger.Error("Logstash - not logged entry:" + Environment.NewLine + data.Item2.XmlSerialize());
                       }
                   }
               }, new ExecutionDataflowBlockOptions
               {
                   MaxDegreeOfParallelism = 1
               }
           );
    }
}
